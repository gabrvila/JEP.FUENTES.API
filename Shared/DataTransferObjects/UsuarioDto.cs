namespace Shared.DataTransferObjects
{
    public class UsuarioDto
    {
        public int? Id { get; init; }
        public string? UsuarioAcceso { get; init; }
        public string? NombreCompleto { get; init; }
        public string? Token { get; set; }
    }
}
