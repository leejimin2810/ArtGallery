using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
