using ArtGallery.Data;
using ArtGallery.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.CodeDom;

namespace ArtGallery.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> Index1()
        {
            var artworks = await _context.Artworks.ToListAsync();
            var artworkViews = _mapper.Map<List<ArtworkView>>(artworks);
            return View(artworkViews);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var artwork = await _context.Artworks.FindAsync(id);
            if (artwork == null)
            {
                return NotFound();
            }
            var artworkView = _mapper.Map<ArtworkView>(artwork);
            return View(artworkView);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArtworkView artworkView)
        {
            if (ModelState.IsValid)
            {
                var artwork = _mapper.Map<Artwork>(artworkView);
                _context.Add(artwork);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index1");
            }
            return View(artworkView);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var artwork = await _context.Artworks.FindAsync(id);
            if (artwork == null)
            {
                return NotFound();
            }
            var artworkView = _mapper.Map<ArtworkView>(artwork);
            return View(artworkView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArtworkView artworkView)
        {
            if (id != artworkView.ArtworkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var artwork = _mapper.Map<Artwork>(artworkView);
                _context.Update(artwork);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index1");
            }
            return View(artworkView);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var artwork = await _context.Artworks.FindAsync(id);
            if (artwork == null)
            {
                return NotFound();
            }
            var artworkView = _mapper.Map<ArtworkView>(artwork);
            return View(artworkView);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artwork = await _context.Artworks.FindAsync(id);
            _context.Artworks.Remove(artwork);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index1");
        }

        private bool ArtworkExists(int id)
        {
            return _context.Artworks.Any(e => e.ArtworkId == id);
        }
        //private readonly ApplicationDbContext _context;
        //private readonly IMapper _mapper;
        //public ArtworkController(ApplicationDbContext context, IMapper mapper)
        //{
        //    _context = context;
        //    _mapper = mapper;
        //}
        //public async Task<IActionResult> Index()
        //{
        //    var artworks = await _context.Artworks.ToListAsync();
        //    var artworkViews = _mapper.Map<List<ArtworkView>>(artworks);
        //    return View(artworkViews);
        //}
        //public async Task<IActionResult> Detail()
        //{          
        //    return View();
        //}

        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Artwork artWork)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        _context.Add(artWork);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("index");
        //    }
        //    return View();
        //}
    }
}
