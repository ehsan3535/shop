using AutoMapper;
using Shop.Models;
using Users.Entities;

namespace Shop.Entities.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UsersDto>().ReverseMap();
        }
    }
}
