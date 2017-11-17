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

        public static void Inicialize()
        {
            using (UserContext ctx = new UserContext())
            {
                ctx.Database.Initialize(false);
            }
        }
    }
}
