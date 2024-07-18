using ArtGallery.Data;
using ArtGallery.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.CodeDom;

namespace ArtGallery.Controllers
{
    public class ArtworkController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ArtworkController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var artworks = await _context.Artworks.ToListAsync();
            var artworkViews = _mapper.Map<List<ArtworkView>>(artworks);
            return View(artworkViews);
        }
        public async Task<IActionResult> Detail()
        {
            //var artworks = await _context.Artworks.ToListAsync();
            //var artworkViews = _mapper.Map<List<ArtworkView>>(artworks);
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Artwork artWork)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(artWork);
                await _context.SaveChangesAsync();
                return RedirectToAction("index");
            }
            return View();
        }
    }
}
