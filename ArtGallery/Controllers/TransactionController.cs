using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
