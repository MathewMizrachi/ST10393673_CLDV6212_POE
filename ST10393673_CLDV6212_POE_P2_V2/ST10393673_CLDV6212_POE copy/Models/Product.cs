using Azure;
using Azure.Data.Tables;

namespace ST10393673_CLDV6212_POE.Models
{
    public class Product : ITableEntity
    {
        // ITableEntity properties
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        // Product-specific properties
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        // Parameterless constructor for TableEntity
        public Product() { }

        // Constructor with parameters
        public Product(string partitionKey, string rowKey, string name, decimal price, string description, string imageUrl)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
            Name = name;
            Price = price;
            Description = description;
            ImageUrl = imageUrl;
        }
    }
}
