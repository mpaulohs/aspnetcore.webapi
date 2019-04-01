using Microsoft.AspNetCore.Identity;

namespace dwa.domain.AggregatesModel.UsuarioAggregate
{
    public class UserLogin : IdentityUserLogin<string>
    {
        public virtual User User { get; set; }
    }
}
