using Microsoft.AspNetCore.Mvc;
using SmartoothAI.Domain.Entities;
using SmartoothAI.Domain.Repositories;
using System.Threading.Tasks;

namespace SmartoothAI.Controllers
{
    public class ProntuarioController : Controller
    {
        private readonly IProntuarioRepository _prontuarioRepository;

        public ProntuarioController(IProntuarioRepository prontuarioRepository)
        {
            _prontuarioRepository = prontuarioRepository;
        }

        // Ação para listar todos os prontuários
        public async Task<IActionResult> Index()
        {
            var prontuarios = await _prontuarioRepository.GetAllAsync();
            return View(prontuarios);
        }

        // Ação para exibir detalhes de um prontuário
        public async Task<IActionResult> Detalhes(int id)
        {
            var prontuario = await _prontuarioRepository.GetByIdAsync(id);
            if (prontuario == null)
                return NotFound();

            return View(prontuario);
        }

        // Ação para criar um novo prontuário (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Ação para criar um novo prontuário (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Prontuario prontuario)
        {
            if (ModelState.IsValid)
            {
                await _prontuarioRepository.AddAsync(prontuario);
                return RedirectToAction(nameof(Index));
            }
            return View(prontuario);
        }

        // Ação para editar um prontuário (GET)
        public async Task<IActionResult> Edit(int id)
        {
            var prontuario = await _prontuarioRepository.GetByIdAsync(id);
            if (prontuario == null)
                return NotFound();

            return View(prontuario);
        }

        // Ação para editar um prontuário (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Prontuario prontuario)
        {
            if (id != prontuario.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _prontuarioRepository.UpdateAsync(prontuario);
                return RedirectToAction(nameof(Index));
            }
            return View(prontuario);
        }

        // Ação para excluir um prontuário (GET)
        public async Task<IActionResult> Delete(int id)
        {
            var prontuario = await _prontuarioRepository.GetByIdAsync(id);
            if (prontuario == null)
                return NotFound();

            return View(prontuario);
        }

        // Ação para excluir um prontuário (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _prontuarioRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
