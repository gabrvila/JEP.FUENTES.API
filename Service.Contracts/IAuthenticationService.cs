
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IAuthenticationService 
    {
        public Task<bool> ValidarUsuario(UsuarioForAuthenticationDto usuarioForAuth, bool trackChanges);
        public Task<UsuarioDto> GetUsuarioByName(string usuarioAcceso, bool trackChanges);
        string CrearToken();
    }
}
