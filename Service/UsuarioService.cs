using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Security.Cryptography;
using System.Text;

namespace Service
{
    internal sealed class UsuarioService : BaseService, IUsuarioService
    {
        public UsuarioService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllUsuariosAsync(bool trackChanges)
        {
            var Usuarioes = await _repository.Usuario.GetAllUsuariosAsync(trackChanges);
            var UsuarioesDto = _mapper.Map<IEnumerable<UsuarioDto>>(Usuarioes);

            return UsuarioesDto;
        }

        public async Task<UsuarioDto> GetUsuarioByUsuarioAccesoAsync(string usuarioAcceso, bool trackChanges)
        {
            var Usuario = await _repository.Usuario.GetUsuarioByUsuarioAccesoAsync(usuarioAcceso, trackChanges);

            if (Usuario is null)
                throw new UsuarioNotFoundException(usuarioAcceso);

            var UsuarioDto = _mapper.Map<UsuarioDto>(Usuario);
            return UsuarioDto;
        }

        public async Task<UsuarioDto> GetUsuarioAsync(int UsuarioId, bool trackChanges)
        {
            var Usuario = await _repository.Usuario.GetUsuarioAsync(UsuarioId, trackChanges);

            if (Usuario is null)
                throw new UsuarioNotFoundException(UsuarioId);

            var UsuarioDto = _mapper.Map<UsuarioDto>(Usuario);
            return UsuarioDto;
        }

        public async Task<UsuarioDto> CreateUsuarioAsync(UsuarioForCreationDto Usuario)
        {
            UsuarioDto? UsuarioToReturn = null;
            
            var usuario = await _repository.Usuario.GetUsuarioByUsuarioAccesoAsync(Usuario.UsuarioAcceso!, trackChanges: false);
            if (usuario != null)
                return UsuarioToReturn;

            var UsuarioEntity = _mapper.Map<Usuario>(Usuario);

            using var hmac = new HMACSHA512();
            var contrasennaHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Usuario.Contrasenna!));
            var contrasennaSalt = hmac.Key;

            UsuarioEntity.ContrasennaHash = contrasennaHash;
            UsuarioEntity.ContrasennaSalt = contrasennaSalt;
            _repository.Usuario.CreateUsuario(UsuarioEntity);
            await _repository.SaveAsync();

            UsuarioToReturn = _mapper.Map<UsuarioDto>(UsuarioEntity);

            //using var hmac = new HMACSHA512();
            //var contrasennaHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioForAuth.Contrasenna!)));
            //var contrasennaSalt = Convert.ToBase64String(hmac.Key);

            return UsuarioToReturn;
        }

        public async Task DeleteUsuarioAsync(int UsuarioId, bool trackChanges)
        {
            var Usuario = await _repository.Usuario.GetUsuarioAsync(UsuarioId, trackChanges);
            if (Usuario is null)
                throw new UsuarioNotFoundException(UsuarioId);

            _repository.Usuario.DeleteUsuario(Usuario);
            await _repository.SaveAsync();
        }

        public async Task UpdateUsuarioAsync(int UsuarioId, UsuarioForUpdateDto UsuarioForUpdate, bool trackChanges)
        {
            var UsuarioEntity = await _repository.Usuario.GetUsuarioAsync(UsuarioId, trackChanges);
            if (UsuarioEntity is null)
                throw new UsuarioNotFoundException(UsuarioId);

            _mapper.Map(UsuarioForUpdate, UsuarioEntity);
            await _repository.SaveAsync();
        }
    }
}
