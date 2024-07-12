using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }
        public IActionResult LoginManagement()
        {
            return View();
        }
        public IActionResult Authorization()
        {
            return View();
        }
        public IActionResult Artwork()
        {
            return View();
        }
        public IActionResult Auction()
        {
            return View();
        }
        public IActionResult Exhibition()
        {
            return View();
        }
        public IActionResult Payment()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Blank()
        {
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

    }
}
