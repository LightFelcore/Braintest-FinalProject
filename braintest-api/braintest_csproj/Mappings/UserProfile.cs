using AutoMapper;
using webapi.DTOs;
using webapi.Models;

namespace webapi.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // mappen voor het lezen en schrijven een gebruiker in / uit de databank
            CreateMap<User, UserReadDTO>();
            CreateMap<UserWriteDTO, User>();
        }
    }
}