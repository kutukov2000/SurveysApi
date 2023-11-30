using Core.ApiModels;
using Infrastructure.Data.Entities;

namespace Core.Interfaces
{
    public interface IVariantsService
    {
        Task<List<Variant>>? Get();
        Task<Variant?> GetById(int id);
        Task<List<Variant>>? GetByQuestionId(int questionId);
        Task Create(CreateVariantModel variant);
        Task Edit(Variant variant);
        Task Delete(int id);
        Task DeleteByQuestionId(int questionId);
    }
}
