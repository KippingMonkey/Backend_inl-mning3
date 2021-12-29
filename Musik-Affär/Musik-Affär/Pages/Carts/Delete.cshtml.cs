using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Musik_Affär.Data;
using Musik_Affär.Models;

namespace Musik_Affär.Pages.Carts
{
    public class DeleteModel : PageModel
    {
        private readonly Musik_Affär.Data.ApplicationDbContext _context;

        public DeleteModel(Musik_Affär.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cart Cart { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cart = await _context.Carts
                .Include(c => c.User).FirstOrDefaultAsync(m => m.ID == id);

            if (Cart == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cart = await _context.Carts.FindAsync(id);

            if (Cart != null)
            {
                _context.Carts.Remove(Cart);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
