using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record UsuarioForUpdateDto
    {
        [Required(ErrorMessage = "Primer nombre es requerido")]
        public string? PrimerNombre { get; init; }
        public string? SegundoNombre { get; init; }
        [Required(ErrorMessage = "Segundo apellido es requerido")]
        public string? PrimerApellido { get; init; }
        public string? SegundoApellido { get; init; }
        [Required(ErrorMessage = "UsuarioAcceso es requerido")]
        public string? UsuarioAcceso { get; init; }
        [Required(ErrorMessage = "Password es requerido")]
        public string? Contrasenna { get; init; }
        //public ICollection<string>? Roles { get; init; } 
    }
}
