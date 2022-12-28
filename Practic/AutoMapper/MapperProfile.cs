using AutoMapper;
using Shop.Entities.Product;
using Shop.Images;
using Shop.Models;
using Shop.Models.ProductsDto;
using Users.Entities;

namespace AutoMapper.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Test, TestDto>().ReverseMap();
            CreateMap<User, UsersDto>().ReverseMap();
            CreateMap<Products, ProductDto>().ReverseMap();
        }
    }
}