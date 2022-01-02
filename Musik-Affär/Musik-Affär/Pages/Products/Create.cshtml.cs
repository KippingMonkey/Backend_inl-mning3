using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Musik_Affär.Data;
using Musik_Affär.Models;

namespace Musik_Affär.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            //uses the product variable(forminput) to set the new object.
            
            Product.Name = product.Name;
            Product.Category = Enum.GetName(typeof(Product.Type), int.Parse(product.Category));
            //uses two parameters typeof(enum),numeric value of enum
            Product.Color = Enum.GetName(typeof(Product.Style), int.Parse(product.Color));
            Product.Price = product.Price;
            Product.Weight = product.Weight;
            Product.Brand = Enum.GetName(typeof(Product.Manufacturer), int.Parse(product.Brand));



            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
