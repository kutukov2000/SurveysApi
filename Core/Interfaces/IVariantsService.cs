using Core.ApiModels;
using Infrastructure.Data.Entities;

namespace Core.Interfaces
{
    public interface IVariantsService
    {
        Task<List<Variant>>? Get();
        Task<Variant?> GetById(int id);
        Task Create(CreateVariantModel variant);
        Task Edit(Variant variant);
        Task Delete(int id);
    }
}
