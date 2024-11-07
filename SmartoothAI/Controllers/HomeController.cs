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

        // Ação GET para exibir o formulário de login
        public IActionResult Login()
        {
            return View();
        }

        // Ação POST para processar o login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Simulação de uma verificação de usuário e senha
                if (model.Usuario == "admin" && model.Senha == "admin")
                {
                    // Redireciona para a página inicial após login bem-sucedido
                    TempData["Mensagem"] = "Login realizado com sucesso!";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Adiciona um erro de autenticação
                    ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos.");
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
