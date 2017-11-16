using ControleJogo.Dominio.Amigos.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ControleJogo.Infra.Data.Contexto.Mapping
{
    public class AmigoMapping : EntityTypeConfiguration<Amigo>
    {
        public AmigoMapping()
        {
            ToTable("Amigo");

            HasKey(t => t.Id);

            Property(t => t.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
                .IsRequired();

            Property(t => t.Nome)
                .HasMaxLength(50)
                .IsRequired();

            Property(t => t.DataCadastro)
                .IsRequired();
        }
    }
}
