using System.ComponentModel.DataAnnotations;

namespace ecommerce_dotnet.Models
{
    public class Product
    {
        [Key]
        public string ProductId { get; set; }

        public string ProductName { get; set; }
        [Required]

        public string ProductDescription { get; set; }

        public string ProductImageUrl { get; set; }

        public decimal Price { get; set; }  = decimal.Zero;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
