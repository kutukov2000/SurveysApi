using DataAccess.Data.Entities;

namespace Core.Interfaces
{
    public interface ISurveysService
    {
        Task<List<Survey>>? Get();
        Task<Survey?> GetById(int id);
        Task Create(Survey survey);
        Task Edit(Survey survey);
        Task Delete(int id);
    }
}
