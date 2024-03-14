
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IAuthenticationService 
    {
        //Task<IdentityResult> RegisterUser(UsuarioForRegistrationDto usuarioForRegistration); 

        //Task<bool> ValidarUsuario(UsuarioForAuthenticationDto usuarioForAuth);
        public bool ValidarUsuario(UsuarioForAuthenticationDto usuarioForAuth);
        public UsuarioDto GetUsuarioByName(string usuarioAcceso);
        //Task<string> CrearToken();
        string CrearToken();
    }
}
