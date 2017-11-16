using ControleJogo.Dominio.Amigos.ObejctValues;
using ControleJogo.Dominio.Amigos.Validations;
using DomainDrivenDesign.Entities;
using FluentValidation.Results;
using System;

namespace ControleJogo.Dominio.Amigos.Entities
{
    public class Amigo : Entity<Guid>
    {
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public Logradouro Logradouro { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        public Amigo(string Nome, string Email, Logradouro logradouro)
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
            this.Nome = Nome;
            this.Email = Email;
            this.Logradouro = Logradouro;
        }

        public void AlterarEmail(string Email) => this.Email = Email;
        public void AlterarLogradouro(Logradouro Logradouro) => this.Logradouro = Logradouro;


        public bool EhValido()
        {
            ValidationResult = new AmigoEstaConsistenteValidator().Validate(this);
            return ValidationResult?.IsValid ?? false;
        }
    }
}
