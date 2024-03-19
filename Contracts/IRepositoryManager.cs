namespace Contracts
{
    public interface IRepositoryManager
    {
        IEntidadRepository Entidad { get; }
        IUsuarioRepository Usuario { get; }
        Task SaveAsync();
    }
}
