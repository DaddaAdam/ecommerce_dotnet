using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ecommerce_dotnet.Data;
using ecommerce_dotnet.Models;

namespace ecommerce_dotnet.Pages.Products
{
    public class ProduitsModel : PageModel
    {
        private readonly ecommerce_dotnet.Data.ApplicationDbContext _context;

        public ProduitsModel(ecommerce_dotnet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Product != null)
            {
                Product = await _context.Product.ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostAsync(string ProductId)
        {
            var session = HttpContext.Session;
            var userId = session.GetString("userId") ?? Guid.NewGuid().ToString();
            session.SetString("UserId", userId);

            var cart = await _context.Cart.FirstOrDefaultAsync(c => c.UserId == userId);
     
            if (cart == null)
            {
                cart = new Cart()
                {
                    UserId = userId,
                    CartId = Guid.NewGuid().ToString(),
                    CreatedAt = DateTime.Now,
                    Total = decimal.Zero,
                    Products = new List<Models.CartItem>(),
                };

                await _context.Cart.AddAsync(cart);
                await _context.SaveChangesAsync();    
            }

            Console.WriteLine("ProductId: " + ProductId);

            var product = await _context.Product.FirstOrDefaultAsync(p => p.ProductId == ProductId);

            if (product != null)
            {
                var cartItem = cart.Products.FirstOrDefault(p => p.Product == product);
                if (cartItem == null)
                {
                    cartItem = new CartItem()
                    {
                        CartItemId = Guid.NewGuid().ToString(),
                        CreatedAt = DateTime.Now,
                        Product = product,
                        Quantity = 1,
                        Subtotal = product.Price
                    };

                    cart.Products.Add(cartItem);
                }
                else
                {
                    cartItem.Subtotal += product.Price;
                    cartItem.Quantity++;
                }
                cart.Total += product.Price;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
