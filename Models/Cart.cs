using System.ComponentModel.DataAnnotations;

namespace ecommerce_dotnet.Models
{
    public class Cart
    {
        [Key]
        public string CartId { get; set; }

        public string UserId { get; set; }

        public List<CartItem> Products { get; set; }

        public decimal Total { get; set; } = decimal.Zero;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
