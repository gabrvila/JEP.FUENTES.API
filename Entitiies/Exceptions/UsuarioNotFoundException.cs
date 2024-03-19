namespace Entities.Exceptions
{
    public sealed class UsuarioNotFoundException : NotFoundException
    {
        public UsuarioNotFoundException(string nombreAcceso)
        : base($"El usuario {nombreAcceso} no existe en la base de datos.")
            {
            }

        public UsuarioNotFoundException(int usuarioId)
        : base($"El usuario con id: {usuarioId} no existe en la base de datos.")
            {
            }
    }
}
