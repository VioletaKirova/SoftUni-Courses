namespace ProductShop
{
    using AutoMapper;

    using Dto.Export;
    using Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<Product, SoldProductDto>()
                .ForMember(x => x.BuyerFirstName, y => y.MapFrom(s => s.Buyer.FirstName))
                .ForMember(x => x.BuyerLastName, y => y.MapFrom(s => s.Buyer.LastName));

            this.CreateMap<User, SellerDto>()
                .ForMember(x => x.SoldProducts, y => y.MapFrom(s => s.ProductsSold));
        }
    }
}
