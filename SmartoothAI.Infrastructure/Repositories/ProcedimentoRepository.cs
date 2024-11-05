using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartoothAI.Domain.Entities;
using SmartoothAI.Domain.Repositories;
using SmartoothAI.Infrastructure.Data;

namespace SmartoothAI.Infrastructure.Repositories
{
    public class ProcedimentoRepository : IProcedimentoRepository
    {
        private readonly SmartoothDbContext _context;

        public ProcedimentoRepository(SmartoothDbContext context)
        {
            _context = context;
        }

        public async Task<Procedimento> GetByIdAsync(int id)
        {
            return await _context.Procedimentos.FindAsync(id);
        }

        public async Task<IEnumerable<Procedimento>> GetAllAsync()
        {
            return await _context.Procedimentos.ToListAsync();
        }

        public async Task AddAsync(Procedimento procedimento)
        {
            await _context.Procedimentos.AddAsync(procedimento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Procedimento procedimento)
        {
            _context.Procedimentos.Update(procedimento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var procedimento = await _context.Procedimentos.FindAsync(id);
            if (procedimento != null)
            {
                _context.Procedimentos.Remove(procedimento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
