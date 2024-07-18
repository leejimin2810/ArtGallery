using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
