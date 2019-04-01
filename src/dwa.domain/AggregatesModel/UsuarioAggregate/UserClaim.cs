using Microsoft.AspNetCore.Identity;

namespace dwa.domain.AggregatesModel.UsuarioAggregate
{
    public class UserClaim : IdentityUserClaim<string>
    {
        public virtual User User { get; set; }
    }
}
