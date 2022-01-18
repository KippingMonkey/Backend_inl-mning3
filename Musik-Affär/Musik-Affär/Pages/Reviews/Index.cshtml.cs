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

namespace Musik_Affär.Pages.Reviews
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

        public IList<Review> Reviews { get;set; }

        [BindProperty]
        public Review Review { get;set; }
        [BindProperty]
        public byte Grade { get;set; }

        public async Task OnGetAsync()
        {
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);

            Reviews = await _context.Reviews.Include(r => r.User)
                                            .Include(r => r.Product)
                                            .Where(r => r.User == user)
                                            .ToListAsync();
          
        }

        public async Task<IActionResult> OnPostAsync(int id, byte grade)
        {
            Review = await _context.Reviews.Where(r => r.ID == id).FirstOrDefaultAsync();

            Review.Grade = grade;
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
