using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartoothAI.Domain.Entities;
using SmartoothAI.Domain.Repositories;
using SmartoothAI.Infrastructure.Data;

namespace SmartoothAI.Infrastructure.Repositories
{
    public class DicaRepository : IDicaRepository
    {
        private readonly SmartoothDbContext _context;

        public DicaRepository(SmartoothDbContext context)
        {
            _context = context;
        }

        public async Task<Dica> GetByIdAsync(int id)
        {
            return await _context.Dicas.FindAsync(id);
        }

        public async Task<IEnumerable<Dica>> GetAllAsync()
        {
            return await _context.Dicas.ToListAsync();
        }

        public async Task AddAsync(Dica dica)
        {
            await _context.Dicas.AddAsync(dica);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Dica dica)
        {
            _context.Dicas.Update(dica);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dica = await _context.Dicas.FindAsync(id);
            if (dica != null)
            {
                _context.Dicas.Remove(dica);
                await _context.SaveChangesAsync();
            }
        }
    }
}

