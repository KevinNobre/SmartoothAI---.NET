using Microsoft.AspNetCore.Mvc;
using SmartoothAI.Application.Services;
using SmartoothAI.Domain.Entities;
using SmartoothAI.Models;
using SmartoothAI.WebAPI.Models;
using System.Diagnostics;

namespace SmartoothAI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EnderecoAppService _enderecoAppService;

        public HomeController(ILogger<HomeController> logger, EnderecoAppService enderecoAppService)
        {
            _logger = logger;
            _enderecoAppService = enderecoAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        public IActionResult Atendimento()
        {
            var pacientes = new List<string> { "Paciente Tranquilo", "Sabrina Couto", "Kevin Nobre", "Juliana Moreira", };
            return View(pacientes);
        }

        public IActionResult Detalhes(int id)
        {
            var pacientesDetalhados = new Dictionary<int, PacienteDetalhesViewModel>
        {
            { 1, new PacienteDetalhesViewModel { Nome = "Paciente Tranquilo", Idade = 35, Plano = "Odonto Plus", Historico = "Consulta de rotina, sem problemas." } },
            { 2, new PacienteDetalhesViewModel { Nome = "Sabrina Couto", Idade = 29, Plano = "Odonto Premium", Historico = "Tratamento ortod�ntico em andamento." } },
            { 3, new PacienteDetalhesViewModel { Nome = "Kevin Nobre", Idade = 32, Plano = "Odonto Essencial", Historico = "Extra��o do siso realizada h� 6 meses." } },
            { 4, new PacienteDetalhesViewModel { Nome = "Juliana Moreira", Idade = 27, Plano = "Odonto Top", Historico = "Limpeza dent�ria realizada no �ltimo m�s." } }
        };

            if (pacientesDetalhados.TryGetValue(id, out var paciente))
            {
                return View("Detalhes", paciente);
            }

            return NotFound("Paciente n�o encontrado.");
        }


        // A��o POST para processar o login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Simula��o de uma verifica��o de usu�rio e senha
                if (model.Usuario == "admin" && model.Senha == "admin")
                {
                    // Redireciona para a p�gina inicial ap�s login bem-sucedido
                    TempData["Mensagem"] = "Login realizado com sucesso!";
                    return RedirectToAction("Atendimento", "Home");
                }
                else
                {
                    // Adiciona um erro de autentica��o
                    ModelState.AddModelError(string.Empty, "Usu�rio ou senha inv�lidos.");
                }
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Route("Home/BuscarEnderecoPorCep/{cep}")]
        public async Task<IActionResult> BuscarEnderecoPorCep(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
                return BadRequest("CEP inv�lido.");

            var paciente = new UsuarioPaciente { Cep = cep };
            var pacienteComEndereco = await _enderecoAppService.PreencherEnderecoPorCepAsync(paciente);

            if (string.IsNullOrEmpty(pacienteComEndereco.Logradouro))
                return NotFound("Endere�o n�o encontrado para o CEP informado.");

            // Retorna JSON com os dados do endere�o
            return Json(new
            {
                pacienteComEndereco.Cep,
                pacienteComEndereco.Logradouro,
                pacienteComEndereco.Complemento,
                pacienteComEndereco.Bairro,
                pacienteComEndereco.Cidade,
                pacienteComEndereco.Uf
            });


        }
    }
}
