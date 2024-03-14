using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace JEP.FUENTES.API.Presentation.Controllers
{
    [ApiController]
    [Route("api/entidades")]
    public class EntidadesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EntidadesController(IServiceManager service) =>
            _service = service;

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetEntidades()
        {
            var entidades = await _service.EntidadService.GetAllEntidadesAsync(trackChanges: false);
            return Ok(entidades);
        }

        [HttpGet("{id:int}", Name = "EntidadById")]
        public async Task<IActionResult> GetEntidad(int id)
        {
            var company = await _service.EntidadService.GetEntidadAsync(id, trackChanges: false);
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntidad([FromBody] EntidadForCreationDto entidad)
        {
            if (entidad is null)
                return BadRequest("Objeto EntidadForCreationDto es nulo");

            var createdEntidad = await _service.EntidadService.CreateEntidadAsync(entidad);
            
            return CreatedAtRoute("EntidadById", new { id = createdEntidad.Id }, createdEntidad);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEntidad(int id)
        {
            await _service.EntidadService.DeleteEntidadAsync(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCompany(int id, [FromBody] EntidadForUpdateDto entidad)
        {
            if (entidad is null)
                return BadRequest("Objeto EntidadForUpdateDto es nulo");

            await _service.EntidadService.UpdateEntidadAsync(id, entidad, trackChanges: true);
            return NoContent();
        }
    }
}
