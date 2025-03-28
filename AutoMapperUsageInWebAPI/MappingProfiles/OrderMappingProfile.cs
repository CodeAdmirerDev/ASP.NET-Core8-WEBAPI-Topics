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
                .ForMember(dest => dest.ProductName, act=> act.NullSubstitute("P123565"))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Quantity * src.ProductPrice ));

            CreateMap<Address, AddressDTO>();
            
            
            CreateMap<CreateOrderDTO, Order>()
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));

            // Complex --> Primitive (Address -> PrimitiveAddressDTO)
            // Map the Customer to separate primitive properties in the AddressDTO
            // Mapping from Address (with Complex Customer) to PrimitiveAddressDTO(With Primivite types)

            CreateMap<Address, PrimitiveAddressDTO>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer.CustomerId))

                 //check a pre- condition before reading the source value
                 .ForMember(dest => dest.PhoneNumber, opt =>
                 {
                     opt.PreCondition(src => src.Customer != null);
                     opt.MapFrom(src => src.Customer.PhoneNumber);

                 } )
                  .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Customer.Email))
                   .ForMember(dest => dest.LastName, opt => { 
                   opt.PreCondition(src => src.Customer.LastName.Length>4);
                       opt.MapFrom(src => src.Customer.LastName);

                   })
                   .ForMember(dest => dest.FirstName, opt => opt.Ignore());//It will ignore the first name while mapping

            // Primitive --> Complex (PrimitiveAddressDTO -> Address)
            // Map the separate primitive properties in the PrimitiveAddressDTO to the Customer
            // Mapping from PrimitiveAddressDTO(With Primivite types) to Address (with Complex Customer)

            CreateMap<PrimitiveAddressDTO, Address>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => new Customer
                {
                    CustomerId = src.CustomerId,
                    PhoneNumber = src.PhoneNumber,
                    Email = src.Email,
                    LastName = src.LastName,
                    FirstName = src.FirstName
                }));

            //Reverse mapping in AutoMapper
            CreateMap<CreateOrderItemDTO, OrderItem>().ReverseMap();


        }
    }
}
