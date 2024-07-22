using ArtGallery.Models;
using AutoMapper;

namespace ArtGallery.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Artist, ArtistView>();
            CreateMap<Artwork, ArtworkView>();
            CreateMap<Auction, AuctionView>();
            CreateMap<Customer, CustomerView>();
            CreateMap<Review, ReviewView>();
            CreateMap<Transaction, TransactionView>();
            CreateMap<Exhibition, ExhibitionView>().ReverseMap();
            //CreateMap<ExhibitionView, Exhibition>();
        }
    }
}
