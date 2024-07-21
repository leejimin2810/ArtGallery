using Microsoft.AspNetCore.Authorization;
using ArtGallery.Data;
using ArtGallery.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Controllers
{
    [Authorize]
    public class AuctionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuctionController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var auctions = await _context.Auctions
                .Include(a => a.Artwork)
                .Include(a => a.Customer)
                .ToListAsync();

            var auctionViews = _mapper.Map<List<AuctionView>>(auctions);

            return View(auctionViews);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceBid(AuctionView model)
        {
            var auction = await _context.Auctions.FindAsync(model.AuctionId);

            if (auction == null)
            {
                return NotFound();
            }

            if (model.NewBid <= auction.CurrentBid)
            {
                ModelState.AddModelError("", "Your bid must be higher than the current bid.");
                var auctions = await _context.Auctions
                    .Include(a => a.Artwork)
                    .ToListAsync();
                var auctionViews = _mapper.Map<List<AuctionView>>(auctions);
                return View("Index", auctionViews);
                //ModelState.AddModelError("", "Your bid must be higher than the current bid.");
                //return View("Index", model);
            }

            auction.CurrentBid = model.NewBid;
            _context.Auctions.Update(auction);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var auction = await _context.Auctions.FindAsync(id);

            if (auction == null)
            {
                return NotFound();
            }

            var auctionViewModel = _mapper.Map<AuctionView>(auction);
            return View(auctionViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AuctionView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var auction = _mapper.Map<Auction>(model);
            _context.Auctions.Update(auction);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var auction = await _context.Auctions.FindAsync(id);

            if (auction == null)
            {
                return NotFound();
            }

            return View(auction);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auction = await _context.Auctions.FindAsync(id);
            if (auction == null)
            {
                return NotFound();
            }

            _context.Auctions.Remove(auction);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
