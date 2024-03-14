using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class EntidadService : BaseService, IEntidadService
    {
        public EntidadService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) : base(repository, logger, mapper)
        {
        }

        public async Task<IEnumerable<EntidadDto>> GetAllEntidadesAsync(bool trackChanges)
        {
            var entidades = await _repository.Entidad.GetAllEntidadesAsync(trackChanges);
            var entidadesDto = _mapper.Map<IEnumerable<EntidadDto>>(entidades);

            return entidadesDto;
        }

        public async Task<EntidadDto> GetEntidadAsync(int id, bool trackChanges)
        {
            var entidad = await _repository.Entidad.GetEntidadAsync(id, trackChanges);

            if (entidad is null)
                throw new EntidadNotFoundException(id);

            var entidadDto = _mapper.Map<EntidadDto>(entidad);
            return entidadDto;
        }

        public async Task<EntidadDto> CreateEntidadAsync(EntidadForCreationDto entidad)
        {
            var entidadEntity = _mapper.Map<Entidad>(entidad);

            _repository.Entidad.CreateEntidad(entidadEntity);
            await _repository.SaveAsync();

            var entidadToReturn = _mapper.Map<EntidadDto>(entidadEntity);

            return entidadToReturn;
        }

        public async Task DeleteEntidadAsync(int entidadId, bool trackChanges)
        {
            var entidad = await _repository.Entidad.GetEntidadAsync(entidadId, trackChanges);
            if (entidad is null)
                throw new EntidadNotFoundException(entidadId);

            _repository.Entidad.DeleteEntidad(entidad);
            await _repository.SaveAsync();
        }

        public async Task UpdateEntidadAsync(int entidadId, EntidadForUpdateDto entidadForUpdate, bool trackChanges)
        {
            var entidadEntity = await _repository.Entidad.GetEntidadAsync(entidadId, trackChanges);
            if (entidadEntity is null)
                throw new EntidadNotFoundException(entidadId);

            _mapper.Map(entidadForUpdate, entidadEntity);
            await _repository.SaveAsync();
        }
    }
}
