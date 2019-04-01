using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace dwa.domain.AggregatesModel.UsuarioAggregate
{
    public class User : IdentityUser
    {
        public string Nome { get; set; }
        public virtual ICollection<UserClaim> Claims { get; set; }
        public virtual ICollection<UserLogin> Logins { get; set; }
        public virtual ICollection<UserToken> Tokens { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
