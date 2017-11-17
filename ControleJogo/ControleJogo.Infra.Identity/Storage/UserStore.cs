namespace ControleJogo.Infra.Identity.Storage
{
    public class UserStore : Microsoft.AspNet.Identity.EntityFramework.UserStore<User>
    {
        public UserStore(UserContext context) : base(context)
        {
        }
    }
}
