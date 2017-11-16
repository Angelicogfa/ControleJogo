using ControleJogo.Dominio.Jogos.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ControleJogo.Infra.Data.Contexto.Mapping
{
    public class CategoriaMapping : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMapping()
        {
            ToTable("Categoria");

            HasKey(t => t.Id);

            Property(t => t.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
                .IsRequired();

            Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
