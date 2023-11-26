using AutoMapper;
using Core.ApiModels;
using DataAccess.Data.Entities;

namespace Core.Helpers
{
    public class MapperConfigs : Profile
    {
        public MapperConfigs()
        {
            CreateMap<SurveyDto, Survey>().ReverseMap();

            CreateMap<QuestionDto, Question>().ReverseMap();
            CreateMap<CreateQuestionModel, Question>().ReverseMap();
        }
    }
}
