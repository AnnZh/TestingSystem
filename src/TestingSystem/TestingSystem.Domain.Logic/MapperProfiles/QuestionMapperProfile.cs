using AutoMapper;
using TestingSystem.Domain.Logic.Models.Tests.Questions;
using TestingSystem.Domain.Tests.Questions;

namespace TestingSystem.Domain.Logic.MapperProfiles
{
    class QuestionMapperProfile : Profile
    {
        public QuestionMapperProfile()
        {
            CreateMap<QuestionDTO, Question>()
                .ForPath(dest => dest.Test.Title, opt => opt.MapFrom(src => src.Test));
            CreateMap<Question, QuestionDTO>()
                .ForMember(dest => dest.Test, opt => opt.MapFrom(src => src.Test.Title));
        }
    }
}
