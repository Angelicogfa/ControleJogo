using ControleJogo.Dominio.Emprestimo.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ControleJogo.Infra.Data.Contexto.Mapping
{
    public class EmprestimoJogoMapping : EntityTypeConfiguration<EmprestimoJogo>
    {
        public EmprestimoJogoMapping()
        {
            ToTable("EmprestimoJogo");

            HasKey(t => t.Id);

            Property(t => t.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)
                .IsRequired();

            Property(t => t.JogoId)
                .IsRequired();

            Property(t => t.AmigoId)
                .IsRequired();

            Property(t => t.DataDevolucao)
                .IsRequired();

            Property(t => t.DataEmprestimo)
                .IsRequired();

            Property(t => t.Devolvido)
                .IsRequired();

            HasRequired(t => t.Amigo)
                .WithMany(t => t.EmprestimosEfetuados)
                .HasForeignKey(t => t.AmigoId)
                .WillCascadeOnDelete(false);

            HasRequired(t => t.Jogo)
                .WithMany(t => t.Emprestados)
                .HasForeignKey(t => t.JogoId)
                .WillCascadeOnDelete(false);
        }
    }
}
