using SmartoothAI.Domain.Entities;
using SmartoothAI.Domain.Repositories;
using SmartoothAI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SmartoothAI.Infrastructure.Exceptions;


namespace SmartoothAI.Infrastructure.Repositories
{
    public class UsuarioPacienteRepository : IUsuarioPacienteRepository
    {
        private readonly SmartoothDbContext _context;

        public UsuarioPacienteRepository(SmartoothDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioPaciente> GetByIdAsync(int id)
        {
            var usuarioPaciente = await _context.UsuariosPacientes.FindAsync(id);

            if (usuarioPaciente == null)
            {
                throw new NotFoundException($"Usuário paciente com ID {id} não encontrado.");
            }

            return usuarioPaciente;
        }

        public async Task<IEnumerable<UsuarioPaciente>> GetAllAsync()
        {
            return await _context.UsuariosPacientes.ToListAsync();
        }

        public async Task AddAsync(UsuarioPaciente usuarioPaciente)
        {
            await _context.UsuariosPacientes.AddAsync(usuarioPaciente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UsuarioPaciente usuarioPaciente)
        {
            // Verifique se o usuário paciente existe
            var existingUsuario = await GetByIdAsync(usuarioPaciente.PacienteId);
            if (existingUsuario == null)
            {
                throw new NotFoundException($"Usuário paciente com ID {usuarioPaciente.PacienteId} não encontrado.");
            }

            _context.UsuariosPacientes.Update(usuarioPaciente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuarioPaciente = await GetByIdAsync(id);
            if (usuarioPaciente != null)
            {
                _context.UsuariosPacientes.Remove(usuarioPaciente);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException($"Usuário paciente com ID {id} não encontrado.");
            }
        }
    }
}
