using System.ComponentModel.DataAnnotations;

namespace ArtGallery.Models
{
    public class Exhibition
    {
        [Key]
        public int ExhibitionId { get; set; }
        [Required]
        public string ExhibitionName { get; set; }
        public string Venue { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Description { get; set; }
    }
}
