using SmartoothAI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartoothAI.Domain.Repositories
{
    public interface IProcedimentoRepository
    {
        Task<Procedimento> GetByIdAsync(int id);
        Task<IEnumerable<Procedimento>> GetAllAsync();
        Task AddAsync(Procedimento procedimento);
        Task UpdateAsync(Procedimento procedimento);
        Task DeleteAsync(int id);
    }
}
