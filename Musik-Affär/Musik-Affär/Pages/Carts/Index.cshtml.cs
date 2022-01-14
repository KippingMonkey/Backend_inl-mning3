using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
       
        public Cart Cart { get;set; }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public IList<CartItem> CartItems{ get; set; }

        //public int ProductQty { get; set; } = 1;
        public int TotalProductQty { get; set; } = 5;
        public IList<decimal> TotalProductPrices { get; set; }
        public decimal TotalOrderPrice { get; set; } = 0;

        public List<Product> OrderedProducts { get; set; }


        public async Task OnGetAsync()
        {
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);

            
            Cart = await _context.Carts.Include(c => c.User)
                                       .Where(c => c.UserID == user.Id)
                                       .FirstOrDefaultAsync();

            CartItems = await _context.CartItems.Include(ci => ci.Product).Where(ci => ci.CartID == Cart.ID).ToListAsync();

            TotalProductPrices = CartItems.Select(ci => ci.Quantity * ci.Product.Price).ToList();
            TotalProductQty = CartItems.Sum(ci => ci.Quantity);
            TotalOrderPrice = TotalProductPrices.Sum();





            //OrderedProducts = Cart.Products.OrderBy(p => p.Name).ToList();
            //Om man vill lista produkterna i bokstavsordning, glöm inte att byta i cshtml-filen



        }
    }
}
