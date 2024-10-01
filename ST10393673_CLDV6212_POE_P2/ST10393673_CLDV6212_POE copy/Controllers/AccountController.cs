using Microsoft.AspNetCore.Mvc;

namespace ST10393673_CLDV6212_POE.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string email, string password)
        {
            // Handle registration logic here
            // e.g., save user to database, validate input, etc.
            return RedirectToAction("Index", "Home");
        }
    }
}
