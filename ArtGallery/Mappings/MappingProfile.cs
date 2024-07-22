using ArtGallery.Models;
using AutoMapper;

namespace ArtGallery.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Artist, ArtistView>().ReverseMap();
            CreateMap<Artwork, ArtworkView>().ReverseMap();
            CreateMap<Auction, AuctionView>().ReverseMap();
            CreateMap<Customer, CustomerView>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Account.UserName));
            CreateMap<CustomerEdit, Customer>();
            CreateMap<CustomerCreate, Customer>();
            CreateMap<CustomerCreate, Account>();
            CreateMap<Review, ReviewView>().ReverseMap();
            CreateMap<Transaction, TransactionView>().ReverseMap();
            CreateMap<Exhibition, ExhibitionView>().ReverseMap();
            //CreateMap<ExhibitionView, Exhibition>();
        }
    }
}
