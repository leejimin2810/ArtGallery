﻿using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Controllers
{
    public class AuctionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
