using ArtGallery.Data;
using ArtGallery.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> Index()
        {
            var artists = await _context.Artists.ToListAsync();
            //var customers = await _context.Customers.ToListAsync();

            var artistViews = _mapper.Map<List<ArtistView>>(artists);
            //var customerViews = _mapper.Map<List<CustomerView>>(customers);

            ViewBag.Artists = artistViews;
            //ViewBag.Customers = customerViews;

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
