using AutoMapper;
using Core.ApiModels;
using DataAccess.Data.Entities;

namespace Core.Helpers
{
    public class MapperConfigs : Profile
    {
        public MapperConfigs()
        {
            //Maps for Car model
            CreateMap<SurveyDto, Survey>().ReverseMap();
        }
    }
}
