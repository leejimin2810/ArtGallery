using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery.Models
{
    public class ArtworkView
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
    }
}
