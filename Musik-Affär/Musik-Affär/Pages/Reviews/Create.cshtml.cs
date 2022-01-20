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
        public IList<Review> Reviews { get; set; }

        public bool AlreadyReviewed { get; set; } = false;

        public async Task<IActionResult> OnGet(int? id)
        {
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);
            Reviews = await _context.Reviews.Include(r => r.Product).Include(r => r.UserID).ToListAsync();
            Product = await _context.Products.SingleAsync(m => m.ID == id);

            //check if this user has given this product a grade previously
            if (Reviews.Where(r => r.ProductID == Product.ID && r.UserID == user.Id).Any())
            {
                AlreadyReviewed = true; //if they have, hide fields to make a new one
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id, Review review)
        {
            //get current user
            IdentityUser user = await _userManager.GetUserAsync(HttpContext.User);

            //set both modelProduct and formProduct to the product chosen
            //done because the form does not hold any data for product and is null
            review.Product = await _context.Products.FindAsync(id);
            Product = await _context.Products.FindAsync(id);
          
            //if the product has an average score
            if (Product.Score != 0)
            {    
                //get the number of reviews (add one to account for this one)
                //get the sum of all review (add this one) and calculate the average value with one decimal
                //product score is set to the new value
                int reviewQty = _context.Reviews.Where(r => r.ProductID == id).Count() + 1;
                NewScore = Math.Round((double)(_context.Reviews.Where(r => r.ProductID == id).Sum(p => p.Grade) + review.Grade) / reviewQty, 1);
                Product.Score = NewScore;
            }
            else
            {
                //if there are no previous reviews, just set the score to the value of this review
                Product.Score = review.Grade; 
            }

            //set all the values and save the new review to database
            review.UserID = user.Id;
            review.User = user;
            review.ProductID = id;

            Review.Grade = review.Grade;
            Review.UserID = review.UserID;
            Review.User = review.User;
            Review.ProductID = review.ProductID;
            Review.Product = review.Product;

            Product.Reviews = new();
            
            _context.Reviews.Add(Review);
            await _context.SaveChangesAsync();
           
            return RedirectToPage("../Products/Index");
        }
    }
}
