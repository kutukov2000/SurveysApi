using AutoMapper;
using Core.ApiModels;
using DataAccess.Data.Entities;
using Infrastructure.Data.Entities;

namespace Core.Helpers
{
    public class MapperConfigs : Profile
    {
        public MapperConfigs()
        {
            CreateMap<SurveyDto, Survey>().ReverseMap();
            CreateMap<SurveyModel, Survey>().ReverseMap();

            CreateMap<QuestionDto, Question>().ReverseMap();
            CreateMap<CreateQuestionModel, Question>().ReverseMap();

            CreateMap<CreateVariantModel, Variant>().ReverseMap();
        }
    }
}
