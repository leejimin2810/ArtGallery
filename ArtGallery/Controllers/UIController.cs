using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Controllers
{
    public class UIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Artwork()
        {
            return View();
        }
        public IActionResult ArtworkDetail()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult Tetimonial()
        {
            return View();
        }
        public IActionResult Page404()
        {
            return View();
        }
        public IActionResult Exhibition()
        {
            return View();
        }
    }
}
