using dwa.domain.AggregatesModel.CatalogoAggregate;
using dwa.domain.SeedWork;
using dwa.infra.data.RepositoriesEfc;
using System;

namespace dwa.infra.data.Repositories
{
    public class CatalagoRepository : EfcRepository<CatalogoItem>, ICatalagoRepository
    {
        public CatalagoRepository(DwaContext dbContext) : base(dbContext)
        {
        }       
    }
}
