using Microsoft.AspNetCore.Mvc;
using SmartoothAI.Application.Services;
using SmartoothAI.Application.DTOs;
using SmartoothAI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartoothAI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioPacienteController : ControllerBase
    {
        private readonly UsuarioPacienteService _usuarioPacienteService;

        public UsuarioPacienteController(UsuarioPacienteService usuarioPacienteService)
        {
            _usuarioPacienteService = usuarioPacienteService;
        }

        // Get by Id
        /// <summary>
        /// Obter um Paciente
        /// </summary>
        /// <param name="id">Identificador do Usuario Paciente</param>
        /// <returns>Dados do Usuario Paciente</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UsuarioPaciente), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UsuarioPaciente>> GetById(int id)
        {
            var usuarioPaciente = await _usuarioPacienteService.GetByIdAsync(id);
            if (usuarioPaciente == null)
            {
                return NotFound(new { message = "Usuário Paciente não encontrado." });
            }
            return Ok(usuarioPaciente);
        }

        // Get all
        /// <summary>
        /// Obter todos os Usuarios
        /// </summary>
        /// <returns>Todos os Usuários Pacientes</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UsuarioPaciente>>> GetAll()
        {
            var usuariosPacientes = await _usuarioPacienteService.GetAllAsync();
            return Ok(usuariosPacientes);
        }

        // Create
        /// <summary>
        /// Cadastrar um Usuario Paciente
        /// </summary>
        /// <remarks>
        /// objeto Json
        /// </remarks>
        /// <param name="usuarioPacienteDTO">Dados do Usuario</param>
        /// <returns>Paciente recém criado</returns>
        /// <response code="201">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        [HttpPost]
        [ProducesResponseType(typeof(UsuarioPaciente), 201)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UsuarioPaciente>> Create([FromBody] UsuarioPacienteDTO usuarioPacienteDTO)
        {
            if (usuarioPacienteDTO == null)
            {
                return BadRequest(new { message = "Usuário Paciente não pode ser nulo." });
            }

            var usuarioPaciente = await _usuarioPacienteService.CreateAsync(usuarioPacienteDTO);

            return CreatedAtAction(nameof(GetById), new { id = usuarioPaciente.PacienteId }, usuarioPaciente);
        }

        // Update
        /// <summary>
        /// Atualizar um Usuário
        /// </summary>
        /// <param name="id">Identificador do Usuario</param>
        /// <param name="usuarioPacienteDTO">Dados do Usuário</param>
        /// <returns>Não retorna informações</returns>
        /// <response code="404">Não encontrado</response>
        /// <response code="204">Sucesso</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioPacienteDTO usuarioPacienteDTO)
        {
            if (usuarioPacienteDTO == null)
            {
                return BadRequest(new { message = "Os dados do usuário paciente são inválidos." });
            }

            if (usuarioPacienteDTO.PacienteId != id)
            {
                return BadRequest(new { message = "O ID do corpo da requisição não corresponde ao ID da URL." });
            }

            var existingPaciente = await _usuarioPacienteService.GetByIdAsync(id);
            if (existingPaciente == null)
            {
                return NotFound(new { message = "Usuário Paciente não encontrado." });
            }

            await _usuarioPacienteService.UpdateAsync(id, usuarioPacienteDTO);
            return NoContent();
        }

        // Delete
        /// <summary>
        /// Deletar um Usuario
        /// </summary>
        /// <param name="id">Identificador de Usuario</param>
        /// <returns>Não retorna informações</returns>
        /// <response code="404">Não encontrado</response>
        /// <response code="204">Sucesso</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _usuarioPacienteService.DeleteAsync(id);
            if (!success)
            {
                return NotFound(new { message = "Usuário Paciente não encontrado." });
            }

            return NoContent();
        }
    }
}
