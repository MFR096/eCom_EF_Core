using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using eCom_EF_Core.Data;
using eCom_EF_Core.Models;

namespace eCom_EF_Core.Pages_Cart
{
    public class IndexModel : PageModel
    {
        private readonly eCom_EF_Core.Data.eComContext _context;

        public IndexModel(eCom_EF_Core.Data.eComContext context)
        {
            _context = context;
        }

        public IList<Cart> Cart { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Carts != null)
            {
                Cart = await _context.Carts
                .Include(c => c.Customer).ToListAsync();
            }
        }
    }
}
