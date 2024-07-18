using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Controllers
{
    public class ExhibitionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
