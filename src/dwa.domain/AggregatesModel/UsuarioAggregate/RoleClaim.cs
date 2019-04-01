using Microsoft.AspNetCore.Identity;

namespace dwa.domain.AggregatesModel.UsuarioAggregate
{
    public class RoleClaim : IdentityRoleClaim<string>
    {
        public virtual Role Role { get; set; }
    }
}
