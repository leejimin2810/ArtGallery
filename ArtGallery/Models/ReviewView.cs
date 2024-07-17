using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery.Models
{
    public class ReviewView
    {
        public int CustomerId { get; set; }
        public int ArtworkId { get; set; }
        public double Rating { get; set; }
        public string ReviewText { get; set; }
        public string ReviewDate { get; set; }
    }
}
