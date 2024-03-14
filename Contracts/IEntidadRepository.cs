using Entities.Models;

namespace Contracts
{
    public interface IEntidadRepository
    {
        Task<IEnumerable<Entidad>> GetAllEntidadesAsync(bool trackChanges);
        Task<Entidad> GetEntidadAsync(int companyId, bool trackChanges);
        void CreateEntidad(Entidad entidad);
        void DeleteEntidad(Entidad entidad);
    }
}
