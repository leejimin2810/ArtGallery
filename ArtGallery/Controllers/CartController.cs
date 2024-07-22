using ArtGallery.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Controllers
{
    [Authorize]
    [Route("Cart")]
    public class CartController : Controller
    {
        private readonly CartService _cartService;
        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }
        //public async Task<IActionResult> Index()
        //{
        //    var cartItems = await _cartService.GetCartItems();
        //    return View();
        //}
        //public async Task<IActionResult> AddToCart(int id)
        //{
        //    try
        //    {
        //        await _cartService.AddToCart(id);
        //        return RedirectToAction("Index");
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        // Xu ly loi
        //        ViewBag.ErrorMessage = ex.Message;
        //        return RedirectToAction("Index", "Artwork", new { id });
        //    }
        //}
        //public async Task<IActionResult> RemoveFromCart(int id)
        //{
        //    await _cartService.RemoveFromCart(id);
        //    return RedirectToAction("Index");
        //}
    }
}
