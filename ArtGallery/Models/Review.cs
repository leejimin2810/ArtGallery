using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public int ArtworkId { get; set; }
        public double Rating { get; set; }
        public string ReviewText { get; set; }
        public string ReviewDate { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        [ForeignKey("ArtworkId")]
        public ArtWork Artwork { get; set; }   
    }
}
