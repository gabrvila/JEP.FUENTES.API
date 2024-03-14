using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IEntidadService
    {
        Task<IEnumerable<EntidadDto>> GetAllEntidadesAsync(bool trackChanges);
        Task<EntidadDto> GetEntidadAsync(int entidadId, bool trackChanges);
        Task<EntidadDto> CreateEntidadAsync(EntidadForCreationDto entidad);
        Task DeleteEntidadAsync(int entidadId, bool trackChanges);
        Task UpdateEntidadAsync(int entidadId, EntidadForUpdateDto companyForUpdate, bool trackChanges);
    }
}
