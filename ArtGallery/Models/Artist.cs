using System.ComponentModel.DataAnnotations;

namespace ArtGallery.Models
{
    public class Artist
    {
        public Artist() { }
        [Key]
        public int ArtistId { get; set; }
        [Required]
        public string ArtistName { get; set; }
        public string Nationality { get; set; }
        public string Biography { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
    }
}
