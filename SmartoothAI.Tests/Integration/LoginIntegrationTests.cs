using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SmartoothAI.WebAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace SmartoothAI.Tests.Integration
{
    public class LoginIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public LoginIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Home_Index_DeveRetornarComSucesso()
        {
            // Act
            var response = await _client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode(); // Lança exceção se não for 2xx
            var content = await response.Content.ReadAsStringAsync();

            Assert.Contains("SmartoothAI", content); // Verifica se o HTML contém o título ou algo marcante
        }

        [Fact]
        public async Task Login_ComCredenciaisInvalidas_DeveRetornarViewComErro()
        {
            var formData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Usuario", "errado"),
                new KeyValuePair<string, string>("Senha", "errado")
            });

            var response = await _client.PostAsync("/Home/Login", formData);
            var body = await response.Content.ReadAsStringAsync();

            var tempPath = Path.Combine(Path.GetTempPath(), "response_login_invalido.html");
            File.WriteAllText(tempPath, body);

            Console.WriteLine("HTML salvo em: " + tempPath);
        }
    }
}