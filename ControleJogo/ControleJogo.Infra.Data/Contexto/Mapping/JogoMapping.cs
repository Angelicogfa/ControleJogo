using ControleJogo.Dominio.Jogos.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ControleJogo.Infra.Data.Contexto.Mapping
{
    public class JogoMapping : EntityTypeConfiguration<Jogo>
    {
        public JogoMapping()
        {
            ToTable("Jogo");

            HasKey(t => t.Id);

            Property(t => t.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);

            Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.CategoriaId)
                .IsRequired();

            Property(t => t.DataCadastro)
                .IsRequired();

            Property(t => t.Status)
                .IsRequired();

            Property(t => t.QuantidadeJogos)
                .IsRequired();

            Ignore(t => t.CopiasDisponiveis);

            HasRequired(t => t.Categoria)
                .WithMany(t => t.Jogos)
                .HasForeignKey(t => t.CategoriaId)
                .WillCascadeOnDelete(false);
        }
    }
}
