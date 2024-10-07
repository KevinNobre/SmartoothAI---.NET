using SmartoothAI.Domain.Entities;
using SmartoothAI.Domain.Repositories;
using SmartoothAI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SmartoothAI.Infrastructure.Exceptions;


namespace SmartoothAI.Infrastructure.Repositories
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly SmartoothDbContext _context;

        public AtendimentoRepository(SmartoothDbContext context)
        {
            _context = context;
        }

        public async Task<Atendimento> GetByIdAsync(int id)
        {
            return await _context.Atendimentos.FindAsync(id);
        }

        public async Task<IEnumerable<Atendimento>> GetAllAsync()
        {
            return await _context.Atendimentos.ToListAsync();
        }

        public async Task AddAsync(Atendimento atendimento)
        {
            await _context.Atendimentos.AddAsync(atendimento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Atendimento atendimento)
        {
            _context.Atendimentos.Update(atendimento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var atendimento = await GetByIdAsync(id);
            if (atendimento != null)
            {
                _context.Atendimentos.Remove(atendimento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
