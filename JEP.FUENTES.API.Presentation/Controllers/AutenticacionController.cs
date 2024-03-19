using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

[Route("api/autenticacion")]
[ApiController] 
public class AuthenticationController : ControllerBase 
{ 
    private readonly IServiceManager _service; 

    public AuthenticationController(IServiceManager service) => _service = service;

    [HttpPost("login")]
    //[ServiceFilter(typeof(ValidationFilterAttribute))] 
    public async Task<IActionResult> Authenticate([FromBody] UsuarioForAuthenticationDto usuario)
    {
        if (!await _service.AuthenticationService.ValidarUsuario(usuario, trackChanges: false)) 
            return BadRequest("Usuario o contraseña invalidos");

        var usuarioToReturn = await _service.AuthenticationService.GetUsuarioByName(usuario.UsuarioAcceso!, trackChanges: false);
        usuarioToReturn.Token = _service.AuthenticationService.CrearToken();
 
        return Ok(usuarioToReturn);
    }
}