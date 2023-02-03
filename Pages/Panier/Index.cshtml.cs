using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ecommerce_dotnet.Data;
using ecommerce_dotnet.Models;
using NuGet.Versioning;

namespace ecommerce_dotnet.Pages.Panier
{
    public class PanierModel : PageModel
    {
        private readonly ecommerce_dotnet.Data.ApplicationDbContext _context;

        public PanierModel(ecommerce_dotnet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CartItem> CartItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var session = HttpContext.Session;
            var userId = session.GetString("UserId") ?? Guid.NewGuid().ToString();
            session.SetString("UserId", userId);

            if (_context.Cart != null)
            {
                var cart = await _context.Cart.Include(c => c.Products).FirstOrDefaultAsync(c => c != null && c.Products != null && c.UserId == userId);
                if(cart != null && cart.Products != null)
                {
                var cartItems = _context.CartItem.Include(c => c.Product).Where(c => c != null && cart.Products.Contains(c)).ToList();
                CartItem =  cartItems;
               }
                else
                {
                CartItem = new List<CartItem>();
                }
            }
        }
    }
}
