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

        // A��o GET para exibir o formul�rio de login
        public IActionResult Login()
        {
            return View();
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
                    return RedirectToAction("Index", "Home");
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
