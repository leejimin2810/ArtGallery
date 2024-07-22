using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtGallery.Data;
using ArtGallery.Models;

namespace ArtGallery.Controllers
{
    public class ExhibitionDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExhibitionDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExhibitionDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ExhibitionDetail.Include(e => e.ArtWork).Include(e => e.Exhibition);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ExhibitionDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibitionDetail = await _context.ExhibitionDetail
                .Include(e => e.ArtWork)
                .Include(e => e.Exhibition)
                .FirstOrDefaultAsync(m => m.ExhibitionDetailId == id);
            if (exhibitionDetail == null)
            {
                return NotFound();
            }

            return View(exhibitionDetail);
        }

        // GET: ExhibitionDetails/Create
        public IActionResult Create()
        {
            ViewData["ArtworkId"] = new SelectList(_context.Artworks, "ArtworkId", "ArtworkId");
            ViewData["ExhibitionId"] = new SelectList(_context.Exhibitions, "ExhibitionId", "ExhibitionName");
            return View();
        }

        // POST: ExhibitionDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExhibitionDetailId,ExhibitionId,ArtworkId")] ExhibitionDetail exhibitionDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exhibitionDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtworkId"] = new SelectList(_context.Artworks, "ArtworkId", "ArtworkId", exhibitionDetail.ArtworkId);
            ViewData["ExhibitionId"] = new SelectList(_context.Exhibitions, "ExhibitionId", "ExhibitionName", exhibitionDetail.ExhibitionId);
            return View(exhibitionDetail);
        }

        // GET: ExhibitionDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibitionDetail = await _context.ExhibitionDetail.FindAsync(id);
            if (exhibitionDetail == null)
            {
                return NotFound();
            }
            ViewData["ArtworkId"] = new SelectList(_context.Artworks, "ArtworkId", "ArtworkId", exhibitionDetail.ArtworkId);
            ViewData["ExhibitionId"] = new SelectList(_context.Exhibitions, "ExhibitionId", "ExhibitionName", exhibitionDetail.ExhibitionId);
            return View(exhibitionDetail);
        }

        // POST: ExhibitionDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExhibitionDetailId,ExhibitionId,ArtworkId")] ExhibitionDetail exhibitionDetail)
        {
            if (id != exhibitionDetail.ExhibitionDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exhibitionDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExhibitionDetailExists(exhibitionDetail.ExhibitionDetailId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtworkId"] = new SelectList(_context.Artworks, "ArtworkId", "ArtworkId", exhibitionDetail.ArtworkId);
            ViewData["ExhibitionId"] = new SelectList(_context.Exhibitions, "ExhibitionId", "ExhibitionName", exhibitionDetail.ExhibitionId);
            return View(exhibitionDetail);
        }

        // GET: ExhibitionDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibitionDetail = await _context.ExhibitionDetail
                .Include(e => e.ArtWork)
                .Include(e => e.Exhibition)
                .FirstOrDefaultAsync(m => m.ExhibitionDetailId == id);
            if (exhibitionDetail == null)
            {
                return NotFound();
            }

            return View(exhibitionDetail);
        }

        // POST: ExhibitionDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exhibitionDetail = await _context.ExhibitionDetail.FindAsync(id);
            if (exhibitionDetail != null)
            {
                _context.ExhibitionDetail.Remove(exhibitionDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExhibitionDetailExists(int id)
        {
            return _context.ExhibitionDetail.Any(e => e.ExhibitionDetailId == id);
        }
    }
}
