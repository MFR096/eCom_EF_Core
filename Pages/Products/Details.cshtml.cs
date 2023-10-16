using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using eCom_EF_Core.Data;
using eCom_EF_Core.Models;
using eCom_EF_Core.Services;

namespace eCom_EF_Core.Pages_Products
{
    public class DetailsModel : PageModel
    {
        private readonly eCom_EF_Core.Data.eComContext _context;
        private readonly CartService _cartService;

        public DetailsModel(eCom_EF_Core.Data.eComContext context, CartService cartService)
        {
            _context = context;
            _cartService = cartService;
        }

      public Product Product { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string action)
        {
            if (action == "addToCart")
            {
                // Get the product ID (you can retrieve it from the model or route data)
                int productId = Product.Id;

                // Call the CartService to add the product to the cart
                bool success = await _cartService.AddProductToCart(productId, quantity: 1);

                if (success)
                {
                    // Redirect to a success page or display a success message
                    return RedirectToPage("CartSuccess");
                }
                else
                {
                    // Handle the case where adding to the cart was not successful
                    return Page();
                }
            }

            return Page();
        }
    }
}
