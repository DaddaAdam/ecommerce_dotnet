using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ecommerce_dotnet.Data;
using ecommerce_dotnet.Models;

namespace ecommerce_dotnet.Pages.Admin.Carts
{
    public class DetailsModel : PageModel
    {
        private readonly ecommerce_dotnet.Data.ApplicationDbContext _context;

        public DetailsModel(ecommerce_dotnet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Cart Cart { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Cart == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.FirstOrDefaultAsync(m => m.CartId == id);
            if (cart == null)
            {
                return NotFound();
            }
            else 
            {
                Cart = cart;
            }
            return Page();
        }
    }
}
