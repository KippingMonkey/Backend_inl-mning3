using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Musik_Affär.Data;
using Musik_Affär.Models;

namespace Musik_Affär.Pages.Products
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

        public IList<Product> Products { get; set; }

        public Product Product { get; set; }

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

        public bool LoggedIn { get; set; }

        public async Task OnGetAsync()
        {
            //get all products
            var query = _context.Products.Select(p => p).AsNoTracking();

            //filter on below values
            if (Color != null) query = query.Where(q => q.Color == Enum.GetName(typeof(Product.Style), int.Parse(Color))).AsNoTracking();
            if (Category != null) query = query.Where(q => q.Category == Enum.GetName(typeof(Product.Type), int.Parse(Category))).AsNoTracking();
            if (Brand != null) query = query.Where(q => q.Brand == Enum.GetName(typeof(Product.Manufacturer), int.Parse(Brand))).AsNoTracking();

            //fill the selectlists for sorting with options
            SortColumnList = new SelectList(sortColumns);
            DirectionList = new SelectList(directions);

            //searches for the entered searchterm in the input
            if (SearchTerm != null)
            {
                query = query.Where(c =>
                    c.Name.ToLower().Contains(SearchTerm.ToLower()) ||
                    c.Category.ToLower().Contains(SearchTerm.ToLower()) ||
                    c.Color.ToLower().Contains(SearchTerm.ToLower()) ||
                    c.Brand.ToLower().Contains(SearchTerm.ToLower())
                );
            }

            //if the sorting selectlists have values, sort according to that value
            if (SortColumn != null)
            {
                if (SortColumn == nameColumn)
                {
                    query = (Direction == "Fallande") ? query.OrderByDescending(c => c.Name) : query.OrderBy(c => c.Name);
                }
                else if (SortColumn == categoryColumn)
                {
                    query = (Direction == "Fallande") ? query.OrderByDescending(c => c.Category) : query.OrderBy(c => c.Category);
                }
                else if (SortColumn == colorColumn)
                {
                    query = (Direction == "Fallande") ? query.OrderByDescending(c => c.Color) : query.OrderBy(c => c.Color);
                }
                else if (SortColumn == brandColumn)
                {
                    query = (Direction == "Fallande") ? query.OrderByDescending(c => c.Brand) : query.OrderBy(c => c.Brand);
                }
                else if (SortColumn == priceColumn)
                {
                    query = (Direction == "Fallande") ? query.OrderByDescending(c => c.Price) : query.OrderBy(c => c.Price);
                }
                else if (SortColumn == scoreColumn)
                {
                    query = (Direction == "Fallande") ? query.OrderByDescending(c => c.Score) : query.OrderBy(c => c.Score);
                }
            }
            Products = await query.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            //find the desired product
            var dbProduct = await _context.Products.FirstAsync(p => p.ID == id);

            //and the current user
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);

            //if the user has a cart already
            if (_context.Carts.Where(c => c.User == user).Any())
            {
                //find the users cart and check if there is another of the same product in the cart
                var myCart = await _context.Carts.FirstAsync(p => p.UserID == user.Id);
                var cartItems = await _context.CartItems.Where(ci => ci.CartID == myCart.ID).ToListAsync();
               //if there are, update that cartItems quantity by 1
                if (cartItems.Where(ci => ci.ProductID == dbProduct.ID).Any())
                {
                    var myCartItem = cartItems.Where(ci => ci.ProductID == dbProduct.ID).Single();
                    myCartItem.Quantity += 1;
                }
                else //if not, just add it to the cart
                {
                    CartItem newItem = new()
                    {
                        CartID = myCart.ID,
                        ProductID = dbProduct.ID,
                        Quantity = 1
                    };
                    _context.CartItems.Add(newItem);
                }
            }
            else //if the user do not have cart, create one and the add a new cartItem
            {
                Cart newCart = new()
                {
                    User = user,
                    UserID = user.Id,
                };
                _context.Carts.Add(newCart);
                await _context.SaveChangesAsync();
                int newId = await _context.Carts.Select(c => c.ID).SingleAsync();
                CartItem newItem = new()
                {
                    CartID = newId,
                    ProductID = dbProduct.ID,
                    Quantity = 1
                };
                _context.CartItems.Add(newItem);
            }
            await _context.SaveChangesAsync();

            await OnGetAsync();
            return RedirectToPage("Index");
        }
    }
}
