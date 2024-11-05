using SmartoothAI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartoothAI.Domain.Repositories
{
    public interface ISistemaPontosRepository
    {
        Task<SistemaPontos> GetByIdAsync(int id);
        Task<IEnumerable<SistemaPontos>> GetAllAsync();
        Task AddAsync(SistemaPontos SistemaPontos);
        Task UpdateAsync(SistemaPontos SistemaPontos);
        Task DeleteAsync(int id);
    }
}
