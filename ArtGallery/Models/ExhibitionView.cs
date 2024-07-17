namespace ArtGallery.Models
{
    public class ExhibitionView
    {
        public string ExhibitionName { get; set; }
        public string Venue { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Description { get; set; }
    }
}
