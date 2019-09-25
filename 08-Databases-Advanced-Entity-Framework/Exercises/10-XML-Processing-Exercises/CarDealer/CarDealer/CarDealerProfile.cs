namespace CarDealer
{
    using AutoMapper;

    using Dtos.Import;
    using Models;

    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();

            this.CreateMap<ImportCustomerDto, Customer>();
        }
    }
}
