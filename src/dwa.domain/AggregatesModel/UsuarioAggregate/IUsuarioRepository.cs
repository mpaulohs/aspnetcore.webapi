using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dwa.domain.AggregatesModel.UsuarioAggregate
{
    public interface IUsuarioRepository
    {
        Task<(IdentityResult result, User usuario)> CreateAsync(string name, string email);
        Task<User> GetByIdAsync(string id);
        Task<IEnumerable<User>> ListAllAsync();
    }
}
