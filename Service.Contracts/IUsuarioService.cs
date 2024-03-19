using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync(bool trackChanges);
        Task<UsuarioDto> GetUsuarioByUsuarioAccesoAsync(string usuarioAcceso, bool trackChanges);
        Task<UsuarioDto> GetUsuarioAsync(int UsuarioId, bool trackChanges);
        Task<UsuarioDto> CreateUsuarioAsync(UsuarioForCreationDto Usuario);
        Task DeleteUsuarioAsync(int UsuarioId, bool trackChanges);
        Task UpdateUsuarioAsync(int UsuarioId, UsuarioForUpdateDto companyForUpdate, bool trackChanges);
    }
}
