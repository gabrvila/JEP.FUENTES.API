using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Entidad
    {
        [Column("EntidadId")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la entidad es un campo requerido.")]
        [MaxLength(60, ErrorMessage = "La longitud máxima del nombre es de 60 caracteres.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La dirección de la entidad es un campo requerido.")]
        [MaxLength(100, ErrorMessage = "La longitud máxima de la dirección es de 100 caracteres")]
        public string? Direccion { get; set; }

        public string? Pais { get; set; }

    }
}
