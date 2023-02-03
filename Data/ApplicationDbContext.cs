using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ecommerce_dotnet.Models;

namespace ecommerce_dotnet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ecommerce_dotnet.Models.Product> Product { get; set; } = default!;
        public DbSet<ecommerce_dotnet.Models.CartItem> CartItem { get; set; } = default!;
        public DbSet<ecommerce_dotnet.Models.Cart> Cart { get; set; } = default!;
    }
}