using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        //public IList<Product> Product { get;set; }


        //public async Task OnGetAsync()
        //{
        //    Product = await _context.Products.ToListAsync();
        //}
        public IList<Product> Products { get; set; }
        [FromQuery]
        public string SearchTerm { get; set; }

        private const string nameColumn = "Namn";
        private const string categoryColumn = "Kategori";
        private const string colorColumn = "Färg";
        private const string priceColumn = "Pris";
        private const string weightColumn = "Vikt";
        private const string brandColumn = "Märke";
        private const string scoreColumn = "Betyg";

        private const string ascendingColumn = "Stigande";
        private const string descendingColumn = "Fallande";

        private string[] sortColumns = { nameColumn, categoryColumn, colorColumn, priceColumn, weightColumn, brandColumn, scoreColumn };
        private string[] directions = { ascendingColumn, descendingColumn };

        [FromQuery]
        public string SortColumn { get; set; }
        public string Direction { get; set; }
        public SelectList SortColumnList { get; set; }
        public SelectList DirectionList { get; set; }

        public async Task OnGetAsync()
        {
            SortColumnList = new SelectList(sortColumns);
            DirectionList = new SelectList(directions);

            // Start by filtering for only contacts belonging to the logged-in user.
            //var query = _context.Products.Where(c => c.User.Id == accessControl.LoggedInUserID).AsNoTracking();
            var query = _context.Products.Select(p=>p);

            if (SearchTerm != null)
            {
                query.Where(c =>
                    c.Name.ToLower().Contains(SearchTerm.ToLower()) ||
                    c.Category.ToLower().Contains(SearchTerm.ToLower()) ||
                    c.Color.ToLower().Contains(SearchTerm.ToLower()) ||
                    c.Brand.ToLower().Contains(SearchTerm.ToLower())
                );
            }

            if (SortColumn != null)
            {
                if (SortColumn == nameColumn)
                {
                    query = query.OrderByDescending(c => c.Name);
                }
                else if (SortColumn == categoryColumn)
                {
                    query.OrderBy(c => c.Category);
                }
                else if (SortColumn == colorColumn)
                {
                    query.OrderBy(c => c.Color);
                }
                else if (SortColumn == brandColumn)
                {
                    query.OrderBy(c => c.Brand);
                }
            }

            Products = await query.ToListAsync();
        }

    }
}
