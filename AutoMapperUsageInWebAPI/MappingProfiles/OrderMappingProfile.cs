using AutoMapper;
using AutoMapperUsageInWebAPI.Models;
using AutoMapperUsageInWebAPI.Models.DTOs;

namespace AutoMapperUsageInWebAPI.MappingProfiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile() {

            //CreateMap : It is used to create a mapping between the Order and OrderDTO classes
            //ForMember : It is used to map the properties of the Order class to the OrderDTO class


            //Mapping the properties of the Order class to the OrderDTO class
            //Maps the Order entity to the OrderDTO for Data Transfer purposes

            CreateMap<Order, OrderDTO>()
                //Map the OrderId property of the Order class to the Id property of the OrderDTO class
                .ForMember(dest=> dest.Id, opt=>opt.MapFrom(src => src.OrderId))
                // Mapping the properties of the Order class to the OrderDTO class
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
                // Mapping the properties of the Customer class to the OrderDTO class
                .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.Customer.Email))
                .ForMember(dest => dest.CustomerPhoneNumber, opt => opt.MapFrom(src => src.Customer.PhoneNumber))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Customer.Address))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));

            CreateMap<OrderItem,OrderItemDTO>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Quantity * src.ProductPrice ));

            CreateMap<Address, AddressDTO>();
            
            CreateMap<CreateOrderItemDTO, OrderItem>();
            
            CreateMap<CreateOrderDTO, Order>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
        }
    }
}
