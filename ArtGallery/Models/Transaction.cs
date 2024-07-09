using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtGallery.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public int ArtworkId { get; set; }
        public DateOnly TransactionDate { get; set; }
        public int Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionStatus { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        [ForeignKey("ArtworkId")]
        public ArtWork ArtWork { get; set; }
    }
}
