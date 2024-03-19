using AutoMapper;
using Contracts;
using Microsoft.Extensions.Configuration;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IEntidadService> _entidadService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IUsuarioService> _usuarioService;

        public ServiceManager(IRepositoryManager repositoryManager, 
            ILoggerManager logger, 
            IMapper mapper,
            IConfiguration configuration)
        {
            _entidadService = new Lazy<IEntidadService>(()
                => new EntidadService(repositoryManager, logger, mapper));

            _authenticationService = new Lazy<IAuthenticationService>(()
                => new AuthenticationService(repositoryManager, logger, mapper, configuration));

            _usuarioService = new Lazy<IUsuarioService>(()
                => new UsuarioService(repositoryManager, logger, mapper));

        }

        public IEntidadService EntidadService => _entidadService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IUsuarioService UsuarioService => _usuarioService.Value;

    }
}
