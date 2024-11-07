using Microsoft.AspNetCore.Mvc;

namespace SmartoothAI.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult Detalhes(string id)
        {
            var pacienteDetalhes = $"Prontuário do Paciente: {id}";
            return View("Detalhes", pacienteDetalhes);
        }
    }
}
