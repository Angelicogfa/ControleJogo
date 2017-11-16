using ControleJogo.Dominio.Jogos.Validations;
using DomainDrivenDesign.Entities;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace ControleJogo.Dominio.Jogos.Entities
{
    public class Categoria : Entity<Guid>
    {
        public string Descricao { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual  ICollection<Jogo> Jogos { get; private set; }

        public Categoria(string Descricao)
        {
            Id = Guid.NewGuid();
            this.Descricao = Descricao;
        }

        protected Categoria()
        {
            Jogos = new List<Jogo>();
        }

        public void AlterarDescricao(string Descricao) => this.Descricao = Descricao;

        public bool EhValido()
        {
            ValidationResult = new CategoriaEstaConsistenteValidator().Validate(this);
            return ValidationResult?.IsValid ?? false;
        }
    }
}
