using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{

    public class Usuario
    {
        [Column("UsuarioId")]
        public int Id { get; set; }
        public string? PrimerNombre { get; set; }
        public string? SegundoNombre { get; set; }
        public string? PrimerApellido { get; set; }
        public string? SegundoApellido { get; set; }
        public string? UsuarioAcceso { get; set; }
        public byte[]? ContrasennaHash { get; set; }
        public byte[]? ContrasennaSalt { get; set; }
    }
}
