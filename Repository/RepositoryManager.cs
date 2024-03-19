using Contracts;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;

        private readonly Lazy<IEntidadRepository> _entidadRepository;
        private readonly Lazy<IUsuarioRepository> _usuarioRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

            _entidadRepository = new Lazy<IEntidadRepository>(() => new EntidadRepository(repositoryContext));
            _usuarioRepository = new Lazy<IUsuarioRepository>(() => new UsuarioRepository(repositoryContext));
        }

        public IEntidadRepository Entidad => _entidadRepository.Value;
        public IUsuarioRepository Usuario => _usuarioRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
