using AutoMapper;
using Shop.Images;
using Shop.Models;
using Users.Entities;

namespace AutoMapper.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Test, TestDto>().ReverseMap();
            CreateMap<User, UsersDto>().ReverseMap();
        }
    }
}