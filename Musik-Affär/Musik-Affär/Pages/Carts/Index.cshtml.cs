using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public int ProductQty { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<Product> UniqueProducts { get; set; }

        public async Task OnGetAsync()
        {
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);
            

            Cart = await _context.Carts.Include(c => c.User)
                                       .Include(c => c.Products)
                                       .Where(c => c.UserID == user.Id)
                                       .FirstOrDefaultAsync();

            UniqueProducts = Cart.Products.Distinct();

        }
    }
}
