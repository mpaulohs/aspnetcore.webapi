using dwa.domain.AggregatesModel.CatalogoAggregate;
using dwa.domain.SeedWork;
using dwa.infra.data.RepositoriesEfc;
using System;

namespace dwa.infra.data.Repositories
{
    public class CatalagoMarcaRepository : EfcRepository<CatalogoMarca>, ICatalagoMarcaRepository
    {
        public CatalagoMarcaRepository(DwaContext dbContext) : base(dbContext)
        {
        }        
    }
}
