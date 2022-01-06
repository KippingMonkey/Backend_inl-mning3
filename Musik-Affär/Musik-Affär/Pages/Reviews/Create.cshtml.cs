using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Musik_Affär.Data;
using Musik_Affär.Models;

namespace Musik_Affär.Pages.Reviews
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public Product Product { get; set; }
        public double NewScore { get; set; }

        [BindProperty]
        public Review Review { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
            Product =  _context.Products.FirstOrDefault(m => m.ID == id);
            IdentityUser user = await _userManager.GetUserAsync(User);

            ////NewScore = _context.Reviews.Where(r => r.ID == id).Average(g => g.Grade);
            //NewScore = 3.4;

            //ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id, Review review)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Review.Grade = review.Grade;
            Review.UserID = review.UserID;
            Review.Product.ID = review.Product.ID;
            //Product.Score = NewScore;
            //Test för att ändra score i products men det funkar inte för mig
            //_context.Products.Attach(Product).Property(p => p.Score).IsModified = true;
            //_context.Products.Add(Product);
            _context.Reviews.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("Products/Index");
        }
    }
}
