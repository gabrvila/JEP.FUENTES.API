using Entities.Models;

namespace Contracts
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync(bool trackChanges);
        Task<Usuario> GetUsuarioByUsuarioAccesoAsync(string usuarioAcceso, bool trackChanges);
        Task<Usuario> GetUsuarioAsync(int companyId, bool trackChanges);
        void CreateUsuario(Usuario Usuario);
        void DeleteUsuario(Usuario Usuario);
    }
}
