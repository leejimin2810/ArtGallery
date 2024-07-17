namespace ArtGallery.Models
{
    public class TransactionView
    {
        public int TransactionId { get; set; }
        public int CustomerId { get; set; }
        public int ArtworkId { get; set; }
        public DateOnly TransactionDate { get; set; }
        public int Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionStatus { get; set; }
    }
}
