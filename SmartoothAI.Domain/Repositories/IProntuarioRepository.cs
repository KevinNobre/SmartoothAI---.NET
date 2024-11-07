using SmartoothAI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartoothAI.Domain.Repositories
{
    public interface IProntuarioRepository
    {
        Task<IEnumerable<Prontuario>> GetAllAsync();
        Task<Prontuario> GetByIdAsync(int id);
        Task AddAsync(Prontuario prontuario);
        Task UpdateAsync(Prontuario prontuario);
        Task DeleteAsync(int id);
    }
}
