using AutoMapper;
using ProductService.Api.Dtos;
using ProductService.Api.Models;

namespace ProductService.Api.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductListItemDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.ColorOptions, opt => opt.MapFrom(src => src.ColorOptions));

            CreateMap<ProductCreateDto, Product>()
               .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => new Rating { Stars = src.Stars, Reviews = src.Reviews }));


            CreateMap<ColorOption, ColorOptionDto>().ReverseMap();
        }
    }
}
