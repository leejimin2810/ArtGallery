using ArtGallery.Data;
using ArtGallery.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ArtGallery.Services
{
    public class CartService
    {
        private readonly ApplicationDbContext _context;
        public CartService(ApplicationDbContext context)
        {
        _context = context; 
        }
        //public async Task AddToCart(int artworkId int userId)
        //{
        //    var artwork = await _context.Artworks.FindAsync(artworkId);

        //    if (artwork == null || artwork.Category == Models.Category.Auction)
        //    {
        //        throw new InvalidOperationException("Artwork cannot be added to cart.");  
        //    }

        //    var cartItem = await _context.Carts.FirstOrDefaultAsync(c => c.ArtworkId == artworkId);
        //    if (cartItem == null)
        //    {
        //        cartItem = new Cart
        //        {
        //        ArtworkId = artworkId,
        //        };
        //        _context.CartItems.Add(cartItem);
        //    }
        //    else
        //    {
        //        cartItem.Quantity += quantity;
        //        _context.CartItems.Update(cartItem);
        //    }
        //    await _context.SaveChangesAsync();
        //}
        //public async Task RemoveFromCart(int cartItemId)
        //{
        //    var cartItem = await _context.CartItems.FindAsync(cartItemId);
        //    if (cartItem != null)
        //    {
        //        _context.CartItems.Remove(cartItem);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        //public async Task<List<Cart>> GetCartItems()
        //{
        //    var query = from cartItem in _context.CartItems
        //                join artwork in _context.Artworks on cartItem.ArtworkId equals artwork.ArtworkId
        //                select new Cart
        //                {
        //                    CartItemId = cartItem.CartItemId,
        //                    ArtworkId = artwork.ArtworkId,
        //                    Quantity = cartItem.Quantity,
        //                };

        //    return await query.ToListAsync();

        //}
        ////public async Task<List<CartItem>> GetCartItems()
        //{
        //    return await _context.CartItems.Include(c => c.ArtworkId).ToListAsync();
        //}
    }
}
