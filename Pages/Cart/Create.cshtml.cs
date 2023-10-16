using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using eCom_EF_Core.Data;
using eCom_EF_Core.Models;

namespace eCom_EF_Core.Pages_Cart
{
    public class CreateModel : PageModel
    {
        private readonly eCom_EF_Core.Data.eComContext _context;

        public CreateModel(eCom_EF_Core.Data.eComContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerID"] = new SelectList(_context.Customers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Cart Cart { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Carts == null || Cart == null)
            {
                return Page();
            }

            _context.Carts.Add(Cart);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
