using Microsoft.AspNetCore.Mvc;
using SmartoothAI.Models;
using System.Diagnostics;

namespace SmartoothAI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
        public IActionResult Detalhes(string id)
        {
            var pacienteDetalhes = $"Detalhes do Paciente: {id}";
            return View("Detalhes", pacienteDetalhes);
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


    }
}
