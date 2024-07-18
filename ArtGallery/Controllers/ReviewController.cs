using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
