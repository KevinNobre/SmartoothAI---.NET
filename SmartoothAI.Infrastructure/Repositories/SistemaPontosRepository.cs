using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartoothAI.Domain.Entities;
using SmartoothAI.Domain.Repositories;
using SmartoothAI.Infrastructure.Data;

namespace SmartoothAI.Infrastructure.Repositories
{
    public class SistemaPontosRepository : ISistemaPontosRepository
    {
        private readonly SmartoothDbContext _context;

        public SistemaPontosRepository(SmartoothDbContext context)
        {
            _context = context;
        }

        public async Task<SistemaPontos> GetByIdAsync(int id)
        {
            return await _context.SistemaPontos.FindAsync(id);
        }

        public async Task<IEnumerable<SistemaPontos>> GetAllAsync()
        {
            return await _context.SistemaPontos.ToListAsync();
        }

        public async Task AddAsync(SistemaPontos sistemaPontos)
        {
            await _context.SistemaPontos.AddAsync(sistemaPontos);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SistemaPontos sistemaPontos)
        {
            _context.SistemaPontos.Update(sistemaPontos);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sistemaPontos = await _context.SistemaPontos.FindAsync(id);
            if (sistemaPontos != null)
            {
                _context.SistemaPontos.Remove(sistemaPontos);
                await _context.SaveChangesAsync();
            }
        }
    }
}
