using ArtGallery.Data;
using ArtGallery.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Controllers
{
    public class ExhibitionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ExhibitionController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var exhibitions = await _context.Exhibitions.ToListAsync();
            var exhibitionViews = _mapper.Map<List<ExhibitionView>>(exhibitions);
            return View(exhibitionViews);
        }
        public async Task<IActionResult> Index1()
        {
            var exhibitions = await _context.Exhibitions.ToListAsync();
            var exhibitionViews = _mapper.Map<List<ExhibitionView>>(exhibitions);
            return View(exhibitionViews);
        }
        public async Task<IActionResult> Detail(int id)
        {
            var exhibition = await _context.Exhibitions.FirstOrDefaultAsync(e => e.ExhibitionId == id);
            if (exhibition == null)
            {
                return NotFound();
            }
            var exhibitionView = _mapper.Map<ExhibitionView>(exhibition);
            return View(exhibitionView);
        }
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exhibition/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExhibitionView exhibitionView)
        {
            if (ModelState.IsValid)
            {
                var exhibition = _mapper.Map<Exhibition>(exhibitionView);
                _context.Add(exhibition);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(exhibitionView);
        }

        //GET: Exhibition/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var exhibition = await _context.Exhibitions.FindAsync(id);
            if (exhibition == null)
            {
                return NotFound();
            }
            var exhibitionView = _mapper.Map<ExhibitionView>(exhibition);
            return View(exhibitionView);
        }

        //POST: Exhibition/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ExhibitionView exhibitionView)
        {
            if (id != exhibitionView.ExhibitionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var exhibition = _mapper.Map<Exhibition>(exhibitionView);
                    _context.Update(exhibition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) 
                {
                    if (!ExhibitionExists(exhibitionView.ExhibitionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(exhibitionView);
        }

        //GET: Exhibition/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var exhibition = await _context.Exhibitions.FindAsync(id);
            if (exhibition == null)
            {
                return NotFound();
            }
            var exhibitionView = _mapper.Map<ExhibitionView>(exhibition);
            return View(exhibitionView);
        }

        //POST: Exhibition/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exhibition = await _context.Exhibitions.FindAsync(id);
            _context.Exhibitions.Remove(exhibition);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        private bool ExhibitionExists(int id)
        {
            return _context.Exhibitions.Any(e => e.ExhibitionId == id);
        }
    }
}
