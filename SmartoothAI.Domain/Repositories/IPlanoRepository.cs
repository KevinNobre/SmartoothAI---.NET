using SmartoothAI.Domain.Entities;

namespace SmartoothAI.Domain.Repositories
{
    public interface IPlanoRepository
    {
        Task<Plano> GetByIdAsync(int id);
        Task<IEnumerable<Plano>> GetAllAsync();
        Task AddAsync(Plano plano);
        Task UpdateAsync(Plano plano);
        Task DeleteAsync(int id);
    }
}
