using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using eCom_EF_Core.Data;
using eCom_EF_Core.Models;

namespace eCom_EF_Core.Pages_Products
{
    public class IndexModel : PageModel
    {
        private readonly eCom_EF_Core.Data.eComContext _context;

        public IndexModel(eCom_EF_Core.Data.eComContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {
                Product = await _context.Products.ToListAsync();
            }
        }
    }
}
