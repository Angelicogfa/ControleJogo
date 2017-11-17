using ControleJogo.Dominio.Amigos.Entities;
using ControleJogo.Dominio.Emprestimo.Entities;
using ControleJogo.Dominio.Jogos.Entities;
using ControleJogo.Infra.Data.Contexto.Mapping;
using FluentValidation.Results;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ControleJogo.Infra.Data.Contexto
{
    public class ControleJogoContext : DbContext
    {
        public ControleJogoContext() : base("ConnDB")
        {
            
        }

        static ControleJogoContext() => Database.SetInitializer(new ControleJogoInicializer());

        public static void Inicialize()
        {
            using (ControleJogoContext ctx = new ControleJogoContext())
            {
                ctx.Database.Initialize(false);
            }
        }

        public DbSet<Amigo> Amigos { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Dominio.Jogos.Entities.Console> Consoles { get; set; }
        public DbSet<EmprestimoJogo> Emprestimos { get;  set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove pluralização das tabelas
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<ValidationFailure>();

            modelBuilder.Properties<DateTime>().Configure(t => t.HasColumnType("datetime"));
            modelBuilder.Properties<string>().Configure(t => t.HasColumnType("varchar"));

            //Complex type
            modelBuilder.Configurations.Add(new EmailMapping());
            modelBuilder.Configurations.Add(new LogradouroMapping());

            //Entities
            modelBuilder.Configurations.Add(new CategoriaMapping());
            modelBuilder.Configurations.Add(new ConsoleMapping());
            modelBuilder.Configurations.Add(new JogoMapping());
            modelBuilder.Configurations.Add(new AmigoMapping());
            modelBuilder.Configurations.Add(new EmprestimoJogoMapping());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries().ToList().Where(t => t.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (item.State == EntityState.Added)
                    item.Property("DataCadastro").CurrentValue = DateTime.Now;
            }

            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync()
        {
            foreach (var item in ChangeTracker.Entries().ToList().Where(t => t.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (item.State == EntityState.Added)
                    item.Property("DataCadastro").CurrentValue = DateTime.Now;
            }

            return base.SaveChangesAsync();
        }
    }
}
