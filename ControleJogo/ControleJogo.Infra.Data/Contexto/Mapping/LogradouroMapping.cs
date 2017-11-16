using ControleJogo.Dominio.Amigos.ObejctValues;
using System.Data.Entity.ModelConfiguration;

namespace ControleJogo.Infra.Data.Contexto.Mapping
{
    public class LogradouroMapping : ComplexTypeConfiguration<Logradouro>
    {
        public LogradouroMapping()
        {
            Property(t => t.Estado)
                .IsRequired()
                .HasColumnName("Estado");

            Property(t => t.CEP)
                .IsRequired()
                .HasMaxLength(9)
                .HasColumnName("CEP");

            Property(t => t.CEP)
                .IsRequired()
                .HasMaxLength(9)
                .HasColumnName("CEP");

            Property(t => t.Bairro)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnName("Bairro");

            Property(t => t.Endereco)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnName("Endereco");

            Property(t => t.Numero)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("Numero");

            Property(t => t.Complemento)
                .IsOptional()
                .HasMaxLength(30)
                .HasColumnName("Complemento");
        }
    }
}
