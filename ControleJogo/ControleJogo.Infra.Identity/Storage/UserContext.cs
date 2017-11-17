namespace ControleJogo.Infra.Identity.Storage
{
    public class UserContext : Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<User>
    {
        public UserContext() : base("ConnDB")
        {

        }

        static UserContext()
        {
            System.Data.Entity.Database.SetInitializer(new UserContextInicialize());
        }
    }
}
