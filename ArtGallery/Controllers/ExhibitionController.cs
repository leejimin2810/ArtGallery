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

        public ExhibitionController(ApplicationDbContext context, IMapper mapper )
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
    }
}
