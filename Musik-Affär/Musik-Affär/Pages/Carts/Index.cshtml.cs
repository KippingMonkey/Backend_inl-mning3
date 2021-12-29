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
    public class IndexModel : PageModel
    {
        private readonly Musik_Affär.Data.ApplicationDbContext _context;

        public IndexModel(Musik_Affär.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Cart> Cart { get;set; }

        public async Task OnGetAsync()
        {
            Cart = await _context.Carts
                .Include(c => c.User).ToListAsync();
        }
    }
}
