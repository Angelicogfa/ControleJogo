using ControleJogo.Dominio.Jogos.Validations;
using DomainDrivenDesign.Entities;
using FluentValidation.Results;
using System;

namespace ControleJogo.Dominio.Jogos.Entities
{
    public class Jogo : Entity<Guid>
    {
        public string Nome { get; private set; }
        public Guid CategoriaId { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public StatusJogo Status { get; private set; }
        public int QuantidadeJogos { get; private set; }

        public int CopiasDisponiveis { get;  }

        public ValidationResult ValidationResult { get; set; }
        
        public virtual Categoria Categoria { get; private set; }

        public Jogo(string Nome, Guid CategoriaId, int QuantidadeJogos = 1)
        {
            Id = Guid.NewGuid();
            this.CategoriaId = CategoriaId;
            DataCadastro = DateTime.Now;
            this.Nome = Nome;
            this.QuantidadeJogos = QuantidadeJogos;
            Status = QuantidadeJogos > 0 ? StatusJogo.Disponivel : StatusJogo.Indisponivel;
        }

        public void AlterarNome(string Nome) => this.Nome = Nome;
        public void AlterarCategoria(Guid CategoriaId) => this.CategoriaId = CategoriaId;

        public bool EhValido()
        {
            ValidationResult = new JogoEstaConsistenteValidator().Validate(this);
            return ValidationResult?.IsValid ?? false;
        }
    }
}
