using AutoMapper;
using TestingSystem.Domain.Logic.Models.Tests;
using TestingSystem.Domain.Tests;

namespace TestingSystem.Domain.Logic.MapperProfiles
{
    public class TestMapperProfile : Profile
    {
        public TestMapperProfile()
        {
            CreateMap<TestDTO, Test>()
                .ForPath(dest => dest.Author.Login, opt => opt.MapFrom(src => src.Author));
            CreateMap<Test, TestDTO>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Login));

            CreateMap<TestDTO, Test>()
                .ForPath(dest => dest.GroupOfTests.Name, opt => opt.MapFrom(src => src.GroupOfTests));
            CreateMap<Test, TestDTO>()
                .ForMember(dest => dest.GroupOfTests, opt => opt.MapFrom(src => src.GroupOfTests.Name));
        }
    }
}
