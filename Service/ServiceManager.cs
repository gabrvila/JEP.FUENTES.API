using AutoMapper;
using Contracts;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IEntidadService> _entidadService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager, 
            ILoggerManager logger, 
            IMapper mapper,
            IConfiguration configuration)
        {
            _entidadService = new Lazy<IEntidadService>(()
                => new EntidadService(repositoryManager, logger, mapper));

            _authenticationService = new Lazy<IAuthenticationService>(()
                => new AuthenticationService(repositoryManager, logger, mapper, configuration));
        }

        public IEntidadService EntidadService => _entidadService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;

    }
}
