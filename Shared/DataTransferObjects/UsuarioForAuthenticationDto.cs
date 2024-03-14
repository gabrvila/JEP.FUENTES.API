using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record UsuarioForAuthenticationDto { 
        [Required(ErrorMessage = "Usuario es requerido")] 
        public string? UsuarioAcceso { get; init; } 
        [Required(ErrorMessage = "Contraseña es requerida")] 
        public string? Contrasenna { get; init; } }
}
