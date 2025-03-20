using Microsoft.AspNetCore.Mvc;
using SmartoothAI.Application.Services;
using SmartoothAI.Application.DTOs;
using SmartoothAI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace SmartoothAI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioPacienteController : ControllerBase
    {
        private readonly UsuarioPacienteService _usuarioPacienteService;
        private readonly ILogger<UsuarioPacienteController> _logger;

        public UsuarioPacienteController(UsuarioPacienteService usuarioPacienteService, ILogger<UsuarioPacienteController> logger)
        {
            _usuarioPacienteService = usuarioPacienteService;
            _logger = logger;
        }

        // Get by Id
        /// <summary>   
        /// Obter um Paciente
        /// </summary>
        /// <param name="id">Identificador do Usuario Paciente</param>
        /// <returns>Dados do Usuario Paciente</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não encontrado</response>
        /// <response code="500">Erro interno</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UsuarioPaciente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UsuarioPaciente>> GetById(int id)
        {
            try
            {
                var usuarioPaciente = await _usuarioPacienteService.GetByIdAsync(id);

                if (usuarioPaciente == null)
                {
                    return NotFound(new { message = "Usuário Paciente não encontrado." });
                }

                return Ok(usuarioPaciente);
            }
            catch (OracleException ex) // Captura erro específico do Oracle
            {
                _logger.LogError(ex, "Erro ao acessar o banco de dados: {Message}", ex.Message);
                return StatusCode(500, new { message = "Erro ao acessar o banco de dados. Verifique a conexão e a existência da tabela." });
            }
            catch (Exception ex) // Captura qualquer outro erro inesperado
            {
                _logger.LogError(ex, "Erro inesperado ao buscar usuário paciente: {Message}", ex.Message);
                return StatusCode(500, new { message = "Erro interno no servidor. Tente novamente mais tarde." });
            }
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
            var paciente = await _usuarioPacienteService.GetByIdAsync(id);
            if (paciente == null) return NotFound(new { message = "Usuário Paciente não encontrado." });

            return NoContent();
        }
    }
}
