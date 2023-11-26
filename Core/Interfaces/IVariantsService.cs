using Infrastructure.Data.Entities;

namespace Core.Interfaces
{
    public interface IVariantsService
    {
        Task<List<Variant>>? Get();
        Task<Variant?> GetById(int id);
        Task Create(Variant question);
        Task Edit(Variant question);
        Task Delete(int id);
    }
}
