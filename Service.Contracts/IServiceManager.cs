namespace Service.Contracts
{
    public interface IServiceManager
    {
        IEntidadService EntidadService { get; }
        IAuthenticationService AuthenticationService { get; }
        IUsuarioService UsuarioService { get; }
    }
}
