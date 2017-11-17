namespace ControleJogo.Infra.Data.Migrations
{
    using ControleJogo.Infra.Data.Contexto;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ControleJogoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            SetHistoryContextFactory("System.Data.SqlClient", (c, d) => new ControleJogoHistory(c, d));
        }

        protected override void Seed(ControleJogoContext context)
        {
            var tiro = new Dominio.Jogos.Entities.Categoria("TIRO");
            var rpg = new Dominio.Jogos.Entities.Categoria("RPG");
            var fut = new Dominio.Jogos.Entities.Categoria("FUTEBOL");

            var sn = new Dominio.Jogos.Entities.Console("SUPER NINTENDO");
            var ps = new Dominio.Jogos.Entities.Console("PS4");
            var xbox = new Dominio.Jogos.Entities.Console("X-BOX ONE");

            if (context.Categorias.Count() == 0)
            {
                context.Categorias.Add(tiro);
                context.Categorias.Add(rpg);
                context.Categorias.Add(fut);
            }

            if(context.Consoles.Count() == 0)
            {
                context.Consoles.Add(sn);
                context.Consoles.Add(ps);
                context.Consoles.Add(xbox);
            }

            if(context.Jogos.Count() == 0)
            {
                context.Jogos.Add(new Dominio.Jogos.Entities.Jogo("DUNGEON AND DRAGON", rpg.Id, sn.Id, 5));
                context.Jogos.Add(new Dominio.Jogos.Entities.Jogo("MEDAL OF HONRON", tiro.Id, ps.Id, 2));
                context.Jogos.Add(new Dominio.Jogos.Entities.Jogo("PES", fut.Id, xbox.Id, 1));
            }
            context.SaveChanges();
        }
    }
}
