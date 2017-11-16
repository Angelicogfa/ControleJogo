using ControleJogo.Dominio.Amigos.Entities;
using ControleJogo.Dominio.Jogos.Entities;
using ControleJogo.Infra.Data.Contexto.Mapping;
using FluentValidation.Results;
using System;
using System.Data.Entity;
using System.Linq;

namespace ControleJogo.Infra.Data.Contexto
{
    public class ControleJogoContext : DbContext
    {
        public ControleJogoContext() : base("ConnDB")
        {

        }

        static ControleJogoContext() => Database.SetInitializer(new ControleJogoInicializer());

        public DbSet<Amigo> Amigos { get; private set; }
        public DbSet<Jogo> Jogos { get; private set; }
        public DbSet<Categoria> Categoria { get; private set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove pluralização das tabelas
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<ValidationFailure>();

            //Complex type
            modelBuilder.Configurations.Add(new EmailMapping());
            modelBuilder.Configurations.Add(new LogradouroMapping());

            //Entities
            modelBuilder.Configurations.Add(new CategoriaMapping());
            modelBuilder.Configurations.Add(new JogoMapping());
            modelBuilder.Configurations.Add(new AmigoMapping());

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
    }
}
