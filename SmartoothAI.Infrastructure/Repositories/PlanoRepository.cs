using Microsoft.EntityFrameworkCore;
using SmartoothAI.Domain.Entities;
using SmartoothAI.Domain.Repositories;
using SmartoothAI.Infrastructure.Data;

namespace SmartoothAI.Infrastructure.Repositories
{
    public class PlanoRepository : IPlanoRepository
    {
        private readonly SmartoothDbContext _context;

        public PlanoRepository(SmartoothDbContext context)
        {
            _context = context;
        }

        public async Task<Plano> GetByIdAsync(int id)
        {
            return await _context.Planos.FindAsync(id);
        }

        public async Task<IEnumerable<Plano>> GetAllAsync()
        {
            return await _context.Planos.ToListAsync();
        }

        public async Task AddAsync(Plano plano)
        {
            await _context.Planos.AddAsync(plano);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Plano plano)
        {
            _context.Planos.Update(plano);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var plano = await GetByIdAsync(id);
            if (plano != null)
            {
                _context.Planos.Remove(plano);
                await _context.SaveChangesAsync();
            }
        }
    }
}
