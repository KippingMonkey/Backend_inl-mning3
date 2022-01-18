using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public Review Review { get; set; }
        public Product Product { get; set; }
        public double NewScore { get; set; }

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

        public bool LoggedIn { get; set; }

        [FromQuery]
        public string SortColumn { get; set; }
        [FromQuery]
        public string Direction { get; set; }

        public SelectList SortColumnList { get; set; }
        public SelectList DirectionList { get; set; }

        public async Task OnGetAsync()
        {
            SortColumnList = new SelectList(sortColumns);
            DirectionList = new SelectList(directions);

            var query = _context.Products.Select( p => p ).AsNoTracking();
            int reviewQty = 0;

            //foreach (var product in query)
            //{
            //    reviewQty = await _context.Reviews.Where(r => r.ProductID == product.ID).CountAsync();
            //    NewScore = Math.Round((double)_context.Reviews.Where(r => r.ProductID == product.ID).Sum(p => p.Grade) / reviewQty, 1);
            //    Product = await _context.Products.Where(p => p.ID == product.ID).FirstOrDefaultAsync();
            //    product.Score = NewScore;
            //    await _context.SaveChangesAsync();
            //}

            query = _context.Products.Select(p => p).AsNoTracking();

            if (SearchTerm != null)
            {
                query = query.Where(c =>
                    c.Name.ToLower().Contains(SearchTerm.ToLower()) ||
                    c.Category.ToLower().Contains(SearchTerm.ToLower()) ||
                    c.Color.ToLower().Contains(SearchTerm.ToLower()) ||
                    c.Brand.ToLower().Contains(SearchTerm.ToLower())
                );
            }
             
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
            var dbProduct = await _context.Products.FirstAsync(p => p.ID == id);

            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);

            if(_context.Carts.Where(c => c.User == user).Any())
            {
                var myCart = await _context.Carts.FirstAsync(p => p.UserID == user.Id);
                var cartItems = await _context.CartItems.Where(ci => ci.CartID == myCart.ID).ToListAsync();
                if (cartItems.Where(ci => ci.ProductID == dbProduct.ID).Any())
                {
                    var myCartItem = cartItems.Where(ci => ci.ProductID == dbProduct.ID).Single();
                    myCartItem.Quantity += 1;
                }
                else
                {
                    CartItem newItem = new()
                    {
                        CartID = myCart.ID,
                        ProductID = dbProduct.ID,
                        Quantity = 1
                    };
                    _context.CartItems.Add(newItem);
                }
                //var myItem = await _context.CartItem.Where(i => i.CartId == myCart.ID && i.ProductId == dbProduct.ID).SingleAsync();
                //myItem.Qty++;
            }
            else
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

            //await OnGetAsync();
            return RedirectToPage("Index");
        }
    }
}
