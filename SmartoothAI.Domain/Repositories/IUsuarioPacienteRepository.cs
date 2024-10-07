using SmartoothAI.Domain.Entities;


namespace SmartoothAI.Domain.Repositories
{
    public interface IUsuarioPacienteRepository
    {
        Task<UsuarioPaciente> GetByIdAsync(int id);

        Task<IEnumerable<UsuarioPaciente>> GetAllAsync();

        Task AddAsync(UsuarioPaciente usuarioPaciente);

        Task UpdateAsync(UsuarioPaciente usuarioPaciente);

        Task DeleteAsync(int id);
    }
}
