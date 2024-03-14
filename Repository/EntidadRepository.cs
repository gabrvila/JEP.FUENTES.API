using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository
{
    public class EntidadRepository : RepositoryBase<Entidad>, IEntidadRepository
    {
        public EntidadRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Entidad>> GetAllEntidadesAsync(bool trackChanges) =>
            await FindAll(trackChanges).OrderBy(c => c.Id).ToListAsync();

        public async Task<Entidad> GetEntidadAsync(int entidadId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(entidadId), trackChanges).SingleOrDefaultAsync();

        public void CreateEntidad(Entidad entidad) => Create(entidad);

        public void DeleteEntidad(Entidad entidad) => Delete(entidad);
    }
}
