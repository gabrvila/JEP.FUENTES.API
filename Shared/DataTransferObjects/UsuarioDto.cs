namespace Shared.DataTransferObjects
{
    //public record UsuarioDto(int Id, string UsuarioAcceso,  string NombreCompleto);

    public class UsuarioDto
    {
        public string? UsuarioAcceso { get; init; }
        public string? NombreCompleto { get; init; }
        public string? Token { get; set; }
    }
}
