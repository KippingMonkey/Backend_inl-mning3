using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Musik_Affär.Data;
using Musik_Affär.Models;

namespace Musik_Affär.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }
        [BindProperty]
        public string SelectedColor { get; set; }
        public string SelectedCategory { get; set; }
        public string SelectedBrand { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FirstOrDefaultAsync(p => p.ID == id);

            SelectedBrand = Product.Brand;
            SelectedColor = Product.Color;
            SelectedCategory = Product.Category;

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null)
            {
                return NotFound();
            }
            try
            {
                dbProduct.Name = Product.Name;
                dbProduct.Price = Product.Price;
                dbProduct.Brand = Product.Brand.GetType() != typeof(Product.Manufacturer) ? Product.Brand.ToString() : Enum.GetName(typeof(Product.Manufacturer), int.Parse(Product.Brand));
                dbProduct.Brand = Product.Color.GetType() != typeof(Product.Style) ? Product.Color.ToString() : Enum.GetName(typeof(Product.Style), int.Parse(Product.Color));
                dbProduct.Brand = Product.Brand.GetType() != typeof(Product.Type) ? Product.Category.ToString() : Enum.GetName(typeof(Product.Type), int.Parse(Product.Category));
                
                //dbProduct.Category = Enum.GetName(typeof(Product.Type), int.Parse(Product.Category));
                //dbProduct.Color = Enum.GetName(typeof(Product.Style), int.Parse(Product.Color));


                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}
