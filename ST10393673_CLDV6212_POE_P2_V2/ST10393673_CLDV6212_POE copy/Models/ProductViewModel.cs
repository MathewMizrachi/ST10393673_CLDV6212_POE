namespace ST10393673_CLDV6212_POE.Models
{
    public class ProductViewModel
    {
        public string ProductId { get; set; } // Unique identifier for the product
        public string ProductName { get; set; } // Name of the product
        public string ProductDescription { get; set; } // Description of the product
        public IFormFile ProductImage { get; set; } // File for the product image
        public decimal ProductPrice { get; set; } // Price of the product
        public string ProductImageUrl { get; set; } // URL of the product image
    }
}
