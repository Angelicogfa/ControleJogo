using ControleJogo.Dominio.Amigos.ObejctValues;
using System.Data.Entity.ModelConfiguration;

namespace ControleJogo.Infra.Data.Contexto.Mapping
{
    public class EmailMapping : ComplexTypeConfiguration<Email>
    {
        public EmailMapping()
        {
            Property(t => t.Value)
                .IsOptional()
                .HasMaxLength(120)
                .HasColumnName("Email");
        }
    }
}
