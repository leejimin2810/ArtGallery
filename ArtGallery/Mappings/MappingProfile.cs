using ArtGallery.Models;
using AutoMapper;

namespace ArtGallery.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Artist, ArtistView>();
            CreateMap<ArtWork, ArtworkView>();
            CreateMap<Auction, AuctionView>();
            CreateMap<Customer, CustomerView>();
            CreateMap<Exhibition, ExhibitionView>();
            CreateMap<Review, ReviewView>();
            CreateMap<Transaction, TransactionView>();
        }
    }
}
