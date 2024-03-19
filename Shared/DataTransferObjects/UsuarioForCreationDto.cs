namespace Shared.DataTransferObjects
{
    public record UsuarioForCreationDto(
        string PrimerNombre,
        string SegundoNombre,
        string PrimerApellido,
        string SegundoApellido,
        string UsuarioAcceso,
        string Contrasenna
    );
}
