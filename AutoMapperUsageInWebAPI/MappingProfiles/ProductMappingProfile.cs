using AutoMapper;

namespace AutoMapperUsageInWebAPI.MappingProfiles
{
    public class ProductMappingProfile :Profile
    {
        public ProductMappingProfile()
        {
            // CreateMap method is used to map the source object to the destination object
            // eg : Product -> ProductDTO
            //This configuration is used to map the Product object to the ProductDTO object

            //CreateMap<Source, Destination>();

            //When we fetch the data from DB
            CreateMap<Models.Product, Models.DTOs.ProductDTO>()
                .ForMember(

                destinationMember => destinationMember.ProductName, //Destination member : ProductDTOProductDTO.ProductName
                memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.Name)
                //Here mapping logic : Take the Name from Product and map it to ProductName in ProductDTO
                ).ForMember(

                destinationMember => destinationMember.ProductDescription,
                memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.Description)
                ).ForMember(dest=> dest.CreatedDateTime, act=> act.NullSubstitute(System.DateTime.Now))//Using AutoMapper to set the default value using NullSubstitute 
                ;

            //This mapping is used when a new prodcut is being created from the data provided by an admin or any api user

            //When we insert the data into DB
            CreateMap<Models.DTOs.CreateProductDTO, Models.Product>();
        }

    }
}
