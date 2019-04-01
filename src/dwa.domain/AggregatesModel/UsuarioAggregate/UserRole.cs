using Microsoft.AspNetCore.Identity;

namespace dwa.domain.AggregatesModel.UsuarioAggregate
{
    public class UserRole : IdentityUserRole<string>
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
