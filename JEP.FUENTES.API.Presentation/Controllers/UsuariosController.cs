using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace JEP.FUENTES.API.Presentation.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IServiceManager _service;

        public UsuariosController(IServiceManager service) =>
            _service = service;

        [HttpGet]
        public async Task<IActionResult> GetUsuarioes()
        {
            var Usuarioes = await _service.UsuarioService.GetAllUsuariosAsync(trackChanges: false);
            return Ok(Usuarioes);
        }

        [HttpGet("{id:int}", Name = "UsuarioById")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var company = await _service.UsuarioService.GetUsuarioAsync(id, trackChanges: false);
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] UsuarioForCreationDto Usuario)
        {
            if (Usuario is null)
                return BadRequest("Objeto UsuarioForCreationDto es nulo");

            var createdUsuario = await _service.UsuarioService.CreateUsuarioAsync(Usuario);

            if (createdUsuario is null)
                return BadRequest("El usuario de acceso ya existe en la base de datos.");

            return CreatedAtRoute("UsuarioById", new { id = createdUsuario.Id }, createdUsuario);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            await _service.UsuarioService.DeleteUsuarioAsync(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] UsuarioForUpdateDto Usuario)
        {
            if (Usuario is null)
                return BadRequest("Objeto UsuarioForUpdateDto es nulo");

            await _service.UsuarioService.UpdateUsuarioAsync(id, Usuario, trackChanges: true);
            return NoContent();
        }
    }
}
