using System.Threading.Tasks;
using SmartoothAI.Application.DTOs;
using SmartoothAI.Domain.Entities;
using SmartoothAI.Domain.Repositories;

namespace SmartoothAI.Application.Services
{
    public class EnderecoAppService
    {
        private readonly IViaCepService _viaCepService;

        public EnderecoAppService(IViaCepService viaCepService)
        {
            _viaCepService = viaCepService;
        }

        public async Task<UsuarioPaciente> PreencherEnderecoPorCepAsync(UsuarioPaciente paciente)
        {
            if (string.IsNullOrEmpty(paciente.Cep))
                return paciente;

            var endereco = await _viaCepService.BuscarEnderecoPorCepAsync(paciente.Cep);

            if (endereco == null)
                return paciente;

            paciente.Logradouro = endereco.Logradouro;
            paciente.Complemento = endereco.Complemento;
            paciente.Bairro = endereco.Bairro;
            paciente.Cidade = endereco.Localidade;
            paciente.Uf = endereco.Uf;

            return paciente;
        }
    }
}