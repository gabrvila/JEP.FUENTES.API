using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UsuarioForRegistrationDto 
    { 
        public string? PrimerNombre { get; init; }
        public string? SegundoNombre { get; init; }
        public string? PrimerApellido { get; init; }
        public string? SegundoApellido { get; init; }
        [Required(ErrorMessage = "Usuario es requerido")] 
        public string? UsuarioAcceso { get; init; } 
        [Required(ErrorMessage = "Password es requerido")] 
        public string? Contrasenna { get; init; } 
        public string? CorreoElectronico { get; init; } 
        public string? Telefono { get; init; } 
        //public ICollection<string>? Roles { get; init; } 
    }
}
