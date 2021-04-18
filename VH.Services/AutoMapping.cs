// AutoMapping.cs
using AutoMapper;
using VH.Core.Transport;
using VH.Data.EFCore;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<Customer, CustomerDTO>().ReverseMap();
        CreateMap<Order, OrderDTO>().ReverseMap();
        //CreateMap<Location, LocationDTO>().ReverseMap();
        CreateMap<Payment, PaymentDTO>().ReverseMap();
        CreateMap<Asset, AssetDTO>().ReverseMap();
    }
}
