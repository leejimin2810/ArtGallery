using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery.Models
{
    public class Artwork
    {
        [Key]
        public int ArtworkId { get; set; }
        [Required]
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }
    }
    public enum Category
    {
        ForSale,
        Auction
    }
    public enum Status
    {
        OnSale,
        Auction,
        Sold
    }
}
