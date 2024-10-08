﻿using Azure.Data.Tables;
using Microsoft.Extensions.Configuration;
using ST10393673_CLDV6212_POE.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ST10393673_CLDV6212_POE.Services
{
    public class TableService
    {
        private readonly TableClient _userTableClient;
        private readonly TableClient _productTableClient;

        public TableService(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("AzureStorage");

            // Initialize TableClient for Users
            _userTableClient = new TableClient(connectionString, "UserProfiles");

            // Initialize TableClient for Products
            _productTableClient = new TableClient(connectionString, "Products");
        }

        // Method to add a user to Azure Table Storage
        public async Task AddUserAsync(RegisterViewModel userModel)
        {
            // Validate userModel before proceeding
            if (userModel == null || string.IsNullOrEmpty(userModel.Username))
            {
                throw new ArgumentException("Invalid user model");
            }

            var entity = new TableEntity("UserProfiles", userModel.Username)
            {
                { "Name", userModel.Name },
                { "Surname", userModel.Surname },
                { "Email", userModel.Email },
                { "Password", userModel.Password } // Ensure passwords are securely hashed in production
            };

            await _userTableClient.AddEntityAsync(entity);
        }

        // Method to add a product to Azure Table Storage
        public async Task AddProductAsync(ProductViewModel productModel)
        {
            // Validate productModel before proceeding
            if (productModel == null || string.IsNullOrEmpty(productModel.ProductId))
            {
                throw new ArgumentException("Invalid product model");
            }

            var entity = new TableEntity("Products", productModel.ProductId)
            {
                { "Name", productModel.ProductName },
                { "Description", productModel.ProductDescription },
                { "Price", productModel.ProductPrice.ToString() }, // Convert decimal to string
                { "ImageUrl", productModel.ProductImageUrl ?? string.Empty } // Use empty string if null
            };

            await _productTableClient.AddEntityAsync(entity);
        }

        // Method to retrieve all products from Azure Table Storage
        public async Task<IEnumerable<ProductViewModel>> GetProductsAsync()
        {
            var products = new List<ProductViewModel>();

            await foreach (var entity in _productTableClient.QueryAsync<TableEntity>())
            {
                var product = new ProductViewModel
                {
                    ProductId = entity.RowKey, // Assuming ProductId is stored as RowKey
                    ProductName = entity.GetString("Name"),
                    ProductDescription = entity.GetString("Description"),
                    ProductPrice = decimal.Parse(entity.GetString("Price")), // Convert string to decimal
                    ProductImageUrl = entity.GetString("ImageUrl") // Retrieve image URL if available
                };

                products.Add(product);
            }

            return products;
        }
    }
}
