using ControleJogo.Dominio.Jogos.Validations;
using DomainDrivenDesign.Entities;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace ControleJogo.Dominio.Jogos.Entities
{
    public class Console : Entity<Guid>
    {
        public string Descricao { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public ICollection<Jogo> Jogos { get; private set; }

        public Console(string Descricao)
        {
            Id = Guid.NewGuid();
            this.Descricao = Descricao;
            DataCadastro = DateTime.Now;
            Jogos = new List<Jogo>();
        }

        protected Console()
        {
            Jogos = new List<Jogo>();
        }

        public bool EhValido()
        {
            ValidationResult = new ConsoleEstaConsistenteValidator().Validate(this);
            return ValidationResult?.IsValid ?? false;
        }
    }
}
