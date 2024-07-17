using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery.Models
{
    public class AuctionView
    {
        
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public double StartingPrice { get; set; }
        public double CurrentBid { get; set; }
        public int CustomerId { get; set; }
    
}
}
