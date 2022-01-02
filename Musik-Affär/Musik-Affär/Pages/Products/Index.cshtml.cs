using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Musik_Affär.Data;
using Musik_Affär.Models;

namespace Musik_Affär.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Musik_Affär.Data.ApplicationDbContext _context;

        public IndexModel(Musik_Affär.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }
        public double Score { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                //.Select(
                //p => p.Score = _context.Reviews.Include(r => r.Product)
                //                               .GroupBy(p => p.Product)
                //                               .Select(group => new { P = group.Key, Avg = group.Average(p => p.Grade) })
                //                               .Where(result => result.P.ID == p.ID)
                //                               .Select(result => result.Avg)
                //                               .FirstOrDefault()
                //)
                .ToListAsync();
        }

    }
}
