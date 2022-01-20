using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Musik_Affär.Data;
using Musik_Affär.Models;

namespace Musik_Affär.Pages.Carts
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [BindProperty]
        public Cart Cart { get;set; }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public CartItem CartItem{ get; set; }
        public bool hasCart { get; set; }

        public int TotalProductQty { get; set; } = 5;
        public IList<decimal> TotalProductPrices { get; set; }
        public decimal TotalOrderPrice { get; set; } = 0;

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
            
            //checks if the current user has a cart.
            hasCart = _context.Carts.Include(c => c.User).Where(c => c.UserID == user.Id).Any();

            //if the user does display all cartItems in their cart
            if (hasCart)
            {
                Cart = await _context.Carts.Include(c => c.User)
                                           .Where(c => c.UserID == user.Id)
                                           .FirstOrDefaultAsync();
                
                CartItems = await _context.CartItems.Include(ci => ci.Product).Where(ci => ci.CartID == Cart.ID).ToListAsync();

                TotalProductPrices = CartItems.Select(ci => ci.Quantity * ci.Product.Price).ToList();
                TotalProductQty = CartItems.Sum(ci => ci.Quantity);
                TotalOrderPrice = TotalProductPrices.Sum();
            }
            else //otherwise create a cart for them
            {
                Cart newCart = new()
                {
                    User = user,
                    UserID = user.Id,
                };
                _context.Carts.Add(newCart);
                 await _context.SaveChangesAsync();
            }

            //all query-related below is to do with search, filter and sort
            var query = CartItems;

            //check if there are values in the selectlists
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
            CartItems = query;
        }

        //if the "+"-button is clicked add another of that product to the cart
        public async Task<IActionResult> OnPostPlus(int id)
        {
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);

            CartItem = await _context.CartItems.Include(ci => ci.Product)
                                               .Include(ci => ci.Cart)
                                               .Where(ci => ci.ProductID == id && ci.Cart.UserID == user.Id)
                                               .FirstOrDefaultAsync();

            CartItem.Quantity += 1;
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }

        //if the "-"-button is clicked subtract one 
        public async Task<IActionResult> OnPostMinus(int id)
        {
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);

            CartItem = await _context.CartItems.Include(ci => ci.Product)
                                               .Include(ci => ci.Cart)
                                               .Where(ci => ci.ProductID == id && ci.Cart.UserID == user.Id)
                                               .FirstOrDefaultAsync();
            if (CartItem.Quantity == 1)
            {
                _context.CartItems.Remove(CartItem);
                await _context.SaveChangesAsync();
            }
            else
            {
            CartItem.Quantity -= 1;
            await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);

            CartItem = await _context.CartItems.Include(ci => ci.Product)
                                               .Include(ci => ci.Cart)
                                               .Where(ci => ci.ProductID == id && ci.Cart.UserID == user.Id)
                                               .FirstOrDefaultAsync();

            _context.CartItems.Remove(CartItem);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
