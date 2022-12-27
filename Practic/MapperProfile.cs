using AutoMapper;
using Shop.Images;
using Shop.Models;
using Users.Entities;

internal class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Test, TestDto>().ReverseMap();
        CreateMap<User, UsersDto>().ReverseMap();
    }
}