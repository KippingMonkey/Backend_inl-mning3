using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        

        public async Task<IActionResult> OnGet(int? id)
        {
            Product =  await _context.Products.SingleAsync(m => m.ID == id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id, Review review)
        {
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);

            review.Product = await _context.Products.FindAsync(id);
            Product = await _context.Products.FindAsync(id);
          
            if (Product.Score != 0)
            {    
                int reviewQty = _context.Reviews.Where(r => r.ProductID == id).Count() + 1;
                NewScore = Math.Round((double)(_context.Reviews.Where(r => r.ProductID == id).Sum(p => p.Grade) + review.Grade) / reviewQty, 1);
                Product.Score = NewScore;
            }
            else
            {
                Product.Score = review.Grade; 
            }
            review.UserID = user.Id;
            review.User = user;
            review.ProductID = id;

            Review.Grade = review.Grade;
            Review.UserID = review.UserID;
            Review.User = review.User;
            Review.ProductID = review.ProductID;
            Review.Product = review.Product;

            Product.Reviews = new();
            //Product.Reviews.Add(review);

            //_context.Products.Attach(Product).Property(p => p.Score).IsModified = true;
            _context.Reviews.Add(Review);
            await _context.SaveChangesAsync();

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
           
            return RedirectToPage("../Products/Index");
        }
    }
}
