using Microsoft.AspNetCore.Mvc;
using ST10393673_CLDV6212_POE.Models;
using ST10393673_CLDV6212_POE.Services;
using System.Threading.Tasks;

namespace ST10393673_CLDV6212_POE.Controllers
{
    public class ProductsController : Controller
    {
        private readonly TableService _tableService;
        private readonly BlobService _blobService;

        public ProductsController(TableService tableService, BlobService blobService)
        {
            _tableService = tableService;
            _blobService = blobService;
        }

        // GET: Products/ProductList
        public async Task<IActionResult> ProductList()
        {
            // Retrieve list of products from Table Storage
            var products = await _tableService.GetProductsAsync();
            return View(products);
        }

        // GET: Products/UploadProduct
        public IActionResult UploadProduct()
        {
            return View();
        }

        // POST: Products/UploadProduct
        [HttpPost]
        public async Task<IActionResult> UploadProduct(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string imageUrl = null;

                    // Upload product image to Blob Storage
                    if (model.ProductImage != null)
                    {
                        imageUrl = await _blobService.UploadBlobAsync(model.ProductImage, "product-images");
                    }

                    // Add product to Table Storage
                    var productEntity = new ProductViewModel
                    {
                        ProductId = Guid.NewGuid().ToString(),
                        ProductName = model.ProductName,
                        ProductDescription = model.ProductDescription,
                        ProductPrice = model.ProductPrice,
                        ProductImageUrl = imageUrl
                    };

                    await _tableService.AddProductAsync(productEntity);

                    TempData["SuccessMessage"] = "Product uploaded successfully!";

                    // Clear the form fields by redirecting to a clean upload form
                    return RedirectToAction("UploadProduct");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error uploading product: {ex.Message}";
                }
            }

            // If we got this far, something failed; redisplay the form with validation messages
            return View(model);
        }
    }
}
