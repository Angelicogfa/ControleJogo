namespace ControleJogo.Infra.Identity.Migrations
{
    using ControleJogo.Infra.Identity.Managers;
    using ControleJogo.Infra.Identity.Storage;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            SetHistoryContextFactory("System.Data.SqlClient", (c, s) => new UserContextHistory(c, s));
        }

        protected override void Seed(UserContext context)
        {
            User user = new User() { Email = "master@gmail.com", UserName = "master" };
            using (CustomUserManager manager = new CustomUserManager(new UserStore(new UserContext())))
            {
                var tarefa = manager.FindByEmailAsync(user.Email);
                tarefa.Wait();
                if(tarefa.Result == null)
                {
                    var result = manager.CreateAsync(user, "Master123#");
                    result.Wait();
                }
            }
        }
    }
}
