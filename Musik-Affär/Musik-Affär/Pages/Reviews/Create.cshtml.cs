using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Musik_Affär.Data;
using Musik_Affär.Models;

namespace Musik_Affär.Pages.Reviews
{
    public class CreateModel : PageModel
    {
        private readonly Musik_Affär.Data.ApplicationDbContext _context;

        public CreateModel(Musik_Affär.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Review Review { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reviews.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
