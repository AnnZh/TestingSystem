using AutoMapper;
using TestingSystem.Domain.Logic.Models.Users;
using TestingSystem.Domain.Users;

namespace TestingSystem.Domain.Logic.MapperProfiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserDTO, User>()
                .ForPath(dest => dest.Role.Name, opt => opt.MapFrom(src => src.Role));
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name));
        }
    }
}
