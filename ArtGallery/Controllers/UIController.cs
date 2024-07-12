using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Controllers
{
    public class UIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
