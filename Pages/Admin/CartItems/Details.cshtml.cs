using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ecommerce_dotnet.Data;
using ecommerce_dotnet.Models;

namespace ecommerce_dotnet.Pages.Admin.CartItems
{
    public class DetailsModel : PageModel
    {
        private readonly ecommerce_dotnet.Data.ApplicationDbContext _context;

        public DetailsModel(ecommerce_dotnet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public CartItem CartItem { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.CartItem == null)
            {
                return NotFound();
            }

            var cartitem = await _context.CartItem.FirstOrDefaultAsync(m => m.CartItemId == id);
            if (cartitem == null)
            {
                return NotFound();
            }
            else 
            {
                CartItem = cartitem;
            }
            return Page();
        }
    }
}
