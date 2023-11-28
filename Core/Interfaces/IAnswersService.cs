using Core.ApiModels;
using DataAccess.Data.Entities;

namespace Core.Interfaces
{
    public interface IAnswersService
    {
        Task<List<CreateAnswerModel>>? Get();
        Task<Answer?> GetById(int id);
        Task Create(CreateAnswerModel answer);
        Task Edit(Answer answer);
        Task Delete(int id);
    }
}
