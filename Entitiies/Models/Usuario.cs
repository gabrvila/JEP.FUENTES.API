namespace Entities.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? PrimerNombre { get; init; }
        public string? SegundoNombre { get; init; }
        public string? PrimerApellido { get; init; }
        public string? SegundoApellido { get; init; }
        public string? UsuarioAcceso { get; init; }
        public string? Contrasenna { get; init; }
        //public byte[] PasswordHash { get; set; }
        //public byte[] PasswordSalt { get; set; }
    }
}
