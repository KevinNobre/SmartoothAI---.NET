using SmartoothAI.Domain.Entities;
using SmartoothAI.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartoothAI.Infrastructure.Repositories
{
    public class ViaCepService : IViaCepService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ViaCepResult> BuscarEnderecoPorCepAsync(string cep)
        {
            var url = $"https://viacep.com.br/ws/{cep}/json/";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ViaCepResult>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // Verifica se a API retornou erro no JSON
            if (resultado == null || (resultado.Erro))
                return null;

            return resultado;
        }
    }
}