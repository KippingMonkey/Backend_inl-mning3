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
        public async Task<IActionResult> OnPostAsync(Product product) //product with small p have the form-values
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            Product.Name = product.Name;
            Product.Category = Enum.GetName(typeof(Product.Type), int.Parse(product.Category));
            //uses two parameters typeof(enum),numeric value of enum. Returns the enum value as a string
            Product.Color = Enum.GetName(typeof(Product.Style), int.Parse(product.Color));
            Product.Price = product.Price;
            Product.Brand = Enum.GetName(typeof(Product.Manufacturer), int.Parse(product.Brand));

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
