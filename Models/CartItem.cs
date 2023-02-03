using System.ComponentModel.DataAnnotations;

namespace ecommerce_dotnet.Models
{
    public class CartItem
    {
        [Key]
        public string CartItemId { get; set; }
        
        public Product Product { get; set; }

        public int Quantity { get; set; } = 1;

        public decimal Subtotal { get; set; } = decimal.Zero;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
