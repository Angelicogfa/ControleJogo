using ControleJogo.Dominio.Jogos.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ControleJogo.Infra.Data.Contexto.Mapping
{
    public class ConsoleMapping : EntityTypeConfiguration<Console>
    {
        public ConsoleMapping()
        {
            ToTable("Console");

            HasKey(t => t.Id);

            Property(t => t.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
                .IsRequired();

            Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
