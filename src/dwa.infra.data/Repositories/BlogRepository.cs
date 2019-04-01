using dwa.domain.AggregatesModel.CatalogoAggregate;
using dwa.domain.SeedWork;
using dwa.infra.data.RepositoriesEfc;
using System;

namespace dwa.infra.data.Repositories
{
    public class BlogRepository : EfcRepository<Blog>, IBlogRepository
    {
        public BlogRepository(DwaContext dbContext) : base(dbContext)
        {
        }       
    }
}
