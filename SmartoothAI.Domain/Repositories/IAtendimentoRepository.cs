using SmartoothAI.Domain.Entities;

namespace SmartoothAI.Domain.Repositories
{
    public interface IAtendimentoRepository
    {
        Task<Atendimento> GetByIdAsync(int id);
        Task<IEnumerable<Atendimento>> GetAllAsync();
        Task AddAsync(Atendimento atendimento);
        Task UpdateAsync(Atendimento atendimento);
        Task DeleteAsync(int id);
    }
}
