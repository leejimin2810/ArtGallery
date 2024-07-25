using ArtGallery.Data;
using ArtGallery.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ArtGallery.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AdminController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (role == "Artist")
            {
                return RedirectToAction("Admin", "Artwork");
            }
            if(role == "Admin")
            {
                return RedirectToAction("Admin", "Auction");
            }
            return View();
        }
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
