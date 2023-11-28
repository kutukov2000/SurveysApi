using Core.ApiModels;
using DataAccess.Data.Entities;

namespace Core.Interfaces
{
    public interface ISurveysService
    {
        Task<List<Survey>>? Get();
        Task<Survey?> GetById(int id);
        Task Create(SurveyModel survey);
        Task Edit(int id, SurveyModel survey);
        Task Delete(int id);
    }
}
