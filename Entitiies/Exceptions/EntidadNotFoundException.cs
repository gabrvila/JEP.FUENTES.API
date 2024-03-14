namespace Entities.Exceptions
{
    public sealed class EntidadNotFoundException : NotFoundException 
    {
        public EntidadNotFoundException(int companyId) 
            : base($"La entidad con id: {companyId} no existe en la base de datos.") 
        { 
        } 
    }
}
