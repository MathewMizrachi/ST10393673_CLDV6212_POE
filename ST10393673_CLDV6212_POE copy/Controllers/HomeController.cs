using Microsoft.AspNetCore.Mvc;
using ST10393673_CLDV6212_POE.Models;
using ST10393673_CLDV6212_POE.Services;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ST10393673_CLDV6212_POE.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlobService _blobService;
        private readonly TableService _tableService; // Added for user management

        public HomeController(BlobService blobService, TableService tableService)
        {
            _blobService = blobService;
            _tableService = tableService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult SpecialOffers()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadProduct(ProductViewModel model, IFormFile productImage)
        {
            if (ModelState.IsValid && productImage != null)
            {
                using var stream = productImage.OpenReadStream();
                await _blobService.UploadBlobAsync("products-images", productImage.FileName, stream);
                ViewData["Message"] = "Product uploaded successfully!";
                return RedirectToAction("Products");
            }
            else
            {
                ViewData["Message"] = "Please select a valid file to upload.";
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _tableService.AddUserAsync(model); // Correct service call for user management
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while registering. Please try again.");
                }
            }
            return View(model);
        }
    }
}
