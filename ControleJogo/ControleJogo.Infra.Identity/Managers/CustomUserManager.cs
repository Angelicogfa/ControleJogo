using ControleJogo.Infra.Identity.Storage;
using Microsoft.AspNet.Identity;

namespace ControleJogo.Infra.Identity.Managers
{
    public class CustomUserManager : UserManager<User>
    {
        public CustomUserManager(UserStore store) : base(store)
        {
            PasswordValidator = new PasswordValidator()
            {
                RequireDigit = true, 
                RequiredLength = 8,
                RequireLowercase = true,
                RequireUppercase = true,
            };
        }
    }
}
