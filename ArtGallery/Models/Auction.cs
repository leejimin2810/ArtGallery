using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery.Models
{
    public class Auction
    {
        public int AuctionId { get; set; }
        public int ArtworkId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public double StartingPrice { get; set; }
        public double CurrentBid { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("ArtworkId")]
        public Artwork Artwork { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }  
    }
}
