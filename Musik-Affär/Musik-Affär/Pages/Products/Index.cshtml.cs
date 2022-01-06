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
        private readonly AccessControl _accessControl;

        public IndexModel(ApplicationDbContext context, AccessControl accessControl)
        {
            _context = context;
            _accessControl = accessControl;
        }

        public IList<Product> Products { get; set; }

        [FromQuery]
        public string SearchTerm { get; set; }

        private const string nameColumn = "Namn";
        private const string categoryColumn = "Kategori";
        private const string colorColumn = "Färg";
        private const string priceColumn = "Pris";
        private const string brandColumn = "Märke";
        private const string scoreColumn = "Betyg";

        private const string ascendingColumn = "Stigande";
        private const string descendingColumn = "Fallande";

        private string[] sortColumns = { nameColumn, categoryColumn, colorColumn, priceColumn, brandColumn, scoreColumn };
        private string[] directions = { ascendingColumn, descendingColumn };

        public bool LoggedIn { get; set; }

        [FromQuery]
        public string SortColumn { get; set; }
        [FromQuery]
        public string Direction { get; set; }

        public SelectList SortColumnList { get; set; }
        public SelectList DirectionList { get; set; }

        public async Task OnGetAsync()
        {
            if (_accessControl.LoggedIn)
            {
                LoggedIn = true;
            }
            
            SortColumnList = new SelectList(sortColumns);
            DirectionList = new SelectList(directions);

            var query = _context.Products.Select( p => p ).AsNoTracking();

            if (SearchTerm != null)
            {
                query = query.Where(c =>
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
                    query = (Direction == "Fallande") ? query.OrderByDescending(c => c.Name) : query.OrderBy(c => c.Name);
                }
                else if (SortColumn == categoryColumn)
                {
                    query = (Direction == "Fallande") ? query.OrderByDescending(c => c.Category) : query.OrderBy(c => c.Category);
                }
                else if (SortColumn == colorColumn)
                {
                    query = (Direction == "Fallande") ? query.OrderByDescending(c => c.Color) : query.OrderBy(c => c.Color);
                }
                else if (SortColumn == brandColumn)
                {
                    query = (Direction == "Fallande") ? query.OrderByDescending(c => c.Brand) : query.OrderBy(c => c.Brand);
                }
                else if (SortColumn == priceColumn)
                {
                    query = (Direction == "Fallande") ? query.OrderByDescending(c => c.Price) : query.OrderBy(c => c.Price);
                }
                else if (SortColumn == scoreColumn)
                {
                    query = (Direction == "Fallande") ? query.OrderByDescending(c => c.Score) : query.OrderBy(c => c.Score);
                }
            }
            Products = await query.ToListAsync();
        }
        public async Task OnPostAsync()
        {

        }
    }
}
