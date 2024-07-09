using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery.Models
{
    public class ArtWork
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
        public DateOnly CreateAt { get; set; }
        public DateOnly UpdateAt { get; set; }
        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }
    }
}
