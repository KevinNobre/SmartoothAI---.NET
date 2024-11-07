using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartoothAI.Domain.Entities;
using SmartoothAI.Domain.Repositories;
using SmartoothAI.Infrastructure.Data;

namespace SmartoothAI.Infrastructure.Repositories
{
    public class ProntuarioRepository : IProntuarioRepository
    {
        private readonly SmartoothDbContext _context;

        public ProntuarioRepository(SmartoothDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prontuario>> GetAllAsync()
        {
            return await _context.Prontuarios.ToListAsync();
        }


        public async Task<Prontuario> GetByIdAsync(int id)
        {
            return await _context.Prontuarios.FindAsync(id);
        }


        public async Task AddAsync(Prontuario prontuario)
        {
            await _context.Prontuarios.AddAsync(prontuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Prontuario prontuario)
        {
            _context.Prontuarios.Update(prontuario);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var prontuario = await GetByIdAsync(id);
            if (prontuario != null)
            {
                _context.Prontuarios.Remove(prontuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}
