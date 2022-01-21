using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Musik_Affär.Data;
using Musik_Affär.Models;

namespace Musik_Affär.Pages.Reviews
{
    [Authorize]//redirects to log in if a non-logged-in user trys to access the page
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Review> Reviews { get;set; }

        [BindProperty]
        public Review Review { get;set; }
        [BindProperty]
        public byte Grade { get;set; } 

        public double NewScore { get;set; }
        public Product Product { get;set; }

        //from here to OnGet are the variables todo with search, filter and sort.
        [FromQuery]
        public string SearchTerm { get; set; }

        private const string nameColumn = "Namn";
        private const string categoryColumn = "Kategori";
        private const string colorColumn = "Färg";
        private const string priceColumn = "Pris";
        private const string brandColumn = "Märke";
        private const string scoreColumn = "Betyg";

        private const string ascendingColumn = "Stigande";
        private const string descendingColumn = "Fallande";

        private string[] sortColumns = { nameColumn, categoryColumn, colorColumn, priceColumn, brandColumn, scoreColumn };
        private string[] directions = { ascendingColumn, descendingColumn };

        [FromQuery]
        public string SortColumn { get; set; }
        [FromQuery]
        public string Direction { get; set; }
        [FromQuery]
        public string Brand { get; set; }
        [FromQuery]
        public string Category { get; set; }
        [FromQuery]
        public string Color { get; set; }

        public SelectList SortColumnList { get; set; }
        public SelectList DirectionList { get; set; }


        public async Task OnGetAsync()
        {
            //gets current user
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);

            //get the review that belong to the current user, include the products attached to the reviews
            Reviews = await _context.Reviews.Include(r => r.User)
                                            .Include(r => r.Product)
                                            .Where(r => r.User == user)
                                            .ToListAsync();

            var query = Reviews;

            //filter on below values
            if (Color != null) query = query.Where(q => q.Product.Color == Enum.GetName(typeof(Product.Style), int.Parse(Color))).ToList();
            if (Category != null) query = query.Where(q => q.Product.Category == Enum.GetName(typeof(Product.Type), int.Parse(Category))).ToList();
            if (Brand != null) query = query.Where(q => q.Product.Brand == Enum.GetName(typeof(Product.Manufacturer), int.Parse(Brand))).ToList();

            //fill the selectlists for sorting with options
            SortColumnList = new SelectList(sortColumns);
            DirectionList = new SelectList(directions);

            //searches for the entered searchterm in the input
            if (SearchTerm != null)
            {
                query = query.Where(c =>
                    c.Product.Name.ToLower().Contains(SearchTerm.ToLower()) ||
                    c.Product.Category.ToLower().Contains(SearchTerm.ToLower()) ||
                    c.Product.Color.ToLower().Contains(SearchTerm.ToLower()) ||
                    c.Product.Brand.ToLower().Contains(SearchTerm.ToLower())
                ).ToList();
            }

            //if the sorting selectlists have values, sort according to that value
            if (SortColumn != null)
            {
                if (SortColumn == nameColumn)
                {
                    query = (Direction == "Fallande") ? query.OrderByDescending(c => c.Product.Name).ToList() : query.OrderBy(c => c.Product.Name).ToList();
                }
                else if (SortColumn == categoryColumn)
                {
                    query = (Direction == "Fallande") ? query.OrderByDescending(c => c.Product.Category).ToList() : query.OrderBy(c => c.Product.Category).ToList();
                }
                else if (SortColumn == colorColumn)
                {
                    query = (Direction == "Fallande") ? query.OrderByDescending(c => c.Product.Color).ToList() : query.OrderBy(c => c.Product.Color).ToList();
                }
                else if (SortColumn == brandColumn)
                {
                    query = (Direction == "Fallande") ? query.OrderByDescending(c => c.Product.Brand).ToList() : query.OrderBy(c => c.Product.Brand).ToList();
                }
                else if (SortColumn == priceColumn)
                {
                    query = (Direction == "Fallande") ? query.OrderByDescending(c => c.Product.Price).ToList() : query.OrderBy(c => c.Product.Price).ToList();
                }
                else if (SortColumn == scoreColumn)
                {
                    query = (Direction == "Fallande") ? query.OrderByDescending(c => c.Product.Score).ToList() : query.OrderBy(c => c.Product.Score).ToList();
                }
            }
            Reviews = query;

        }
        
        public async Task<IActionResult> OnPostChange(int id, byte grade)
        {
            //changes the grade for a product and saves to database
            Review = await _context.Reviews.Include(r => r.Product).Where(r => r.ID == id).FirstOrDefaultAsync();
            Review.Grade = grade;
            await _context.SaveChangesAsync();

            //calculate and update the average grade after change and set it to the product.score
            Reviews = await _context.Reviews.Include( r => r.Product).Where(r => r.ProductID == Review.ProductID).ToListAsync();
            int reviewQty = Reviews.Count();
            NewScore = Math.Round((double)Reviews.Sum(p => p.Grade) / reviewQty, 1);
            Review.Product.Score = NewScore;
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            //delete the review from database
            Review = await _context.Reviews.Where(r => r.ID == id).FirstOrDefaultAsync();

            _context.Reviews.Remove(Review);
            await _context.SaveChangesAsync();

            //calculate and update the average grade after delete and set it to the product.score
            Reviews = await _context.Reviews.Include(r => r.Product).Where(r => r.ProductID == Review.ProductID).ToListAsync();
            int reviewQty = Reviews.Count();
            NewScore = Math.Round((double)Reviews.Sum(p => p.Grade) / reviewQty, 1);
            Review = Reviews.FirstOrDefault(); 
            Review.Product.Score = NewScore;
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
