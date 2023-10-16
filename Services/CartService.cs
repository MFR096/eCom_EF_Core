using eCom_EF_Core.Data;
using eCom_EF_Core.Models;
using System.Security.Claims;

namespace eCom_EF_Core.Services
{
    public class CartService
    {
        private readonly eComContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(eComContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> AddProductToCart(int productId, int quantity)
        {
            // Get the current customer's cart (you may need to identify the customer somehow)
            Customer customer = GetCurrentCustomer(); // Implement a method to get the current customer

            if (customer == null)
            {
                // Customer not found, handle accordingly (e.g., create a new customer or require login).
                return false;
            }

            // Check if the product is already in the cart
            CartItem existingCartItem = customer.Cart.CartItems
                .SingleOrDefault(item => item.ProductID == productId);

            if (existingCartItem != null)
            {
                // The product is already in the cart, increase the quantity
                existingCartItem.Quantity += quantity;
            }
            else
            {
                // The product is not in the cart, create a new CartItem
                CartItem newCartItem = new CartItem
                {
                    Cart = customer.Cart,
                    ProductID = productId,
                    Quantity = quantity
                };
                customer.Cart.CartItems.Add(newCartItem);

                _context.Carts.Add(customer.Cart);
            }

            await _context.SaveChangesAsync();

            return true;
        }

        // Helper method to get the current customer based on the user's session or authentication
        private Customer GetCurrentCustomer()
        {
            // Implement logic to retrieve the current customer based on session or authentication.
            // For example, you might use the HttpContext to identify the customer.
            // You can replace this with your authentication and session management logic.

            // Example: Get the current user's ID
            //string userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Example: Retrieve the customer based on the user's ID
            /*Customer customer = _context.Customers
                .Include(c => c.Cart)
                .ThenInclude(cart => cart.CartItems)
                .SingleOrDefault(c => c.UserId == userId);

            return customer;*/
            return null;
        }
    }
}
