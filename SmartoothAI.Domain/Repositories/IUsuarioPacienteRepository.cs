using SmartoothAI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartoothAI.Domain.Repositories
{
    public interface IUsuarioPacienteRepository
    {
        Task<UsuarioPaciente> GetByIdAsync(int id);
        Task<IEnumerable<UsuarioPaciente>> GetAllAsync();
        Task AddAsync(UsuarioPaciente usuarioPaciente);
        Task UpdateAsync(UsuarioPaciente usuarioPaciente);

        // Métodos de Delete
        Task DeleteAsync(int id);
        Task DeleteAsync(UsuarioPaciente usuarioPaciente);
    }
}
