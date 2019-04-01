using Microsoft.AspNetCore.Identity;

namespace dwa.domain.AggregatesModel.UsuarioAggregate
{
    public class UserToken : IdentityUserToken<string>
    {
        public virtual User User { get; set; }
    }
}
