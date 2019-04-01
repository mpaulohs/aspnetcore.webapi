using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace dwa.domain.AggregatesModel.UsuarioAggregate
{
    public class Role : IdentityRole
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<RoleClaim> RoleClaims { get; set; }
    }
}
