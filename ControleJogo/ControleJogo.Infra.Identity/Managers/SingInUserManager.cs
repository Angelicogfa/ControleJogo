using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace ControleJogo.Infra.Identity.Managers
{
    public class SingInUserManager : SignInManager<User, string>
    {
        public SingInUserManager(CustomUserManager userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {

        }
    }
}
