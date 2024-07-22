using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArtGallery.Validations;
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
        [Required]
        [CategoryValidation]
        public Category Category { get; set; }
        public double? Price { get; set; }
        [Required]
        public Status Status { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
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
