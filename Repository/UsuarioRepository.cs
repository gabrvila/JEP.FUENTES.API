using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(c => c.Id).ToListAsync();

        public async Task<Usuario> GetUsuarioByUsuarioAccesoAsync(string usuarioAcceso, bool trackChanges) =>
            await FindByCondition(c => c.UsuarioAcceso.Equals(usuarioAcceso), trackChanges).SingleOrDefaultAsync();

        public async Task<Usuario> GetUsuarioAsync(int UsuarioId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(UsuarioId), trackChanges).SingleOrDefaultAsync();

        public void CreateUsuario(Usuario Usuario) => Create(Usuario);

        public void DeleteUsuario(Usuario Usuario) => Delete(Usuario);
    }
}
