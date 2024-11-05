using SmartoothAI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartoothAI.Domain.Repositories
{
    public interface IDicaRepository
    {
        Task<Dica> GetByIdAsync(int id); 
        Task<IEnumerable<Dica>> GetAllAsync(); 
        Task AddAsync(Dica dica); 
        Task UpdateAsync(Dica dica); 
        Task DeleteAsync(int id); 
    }
}