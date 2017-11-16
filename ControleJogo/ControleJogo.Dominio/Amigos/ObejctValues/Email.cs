using ControleJogo.Dominio.Amigos.Validations;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace ControleJogo.Dominio.Amigos.ObejctValues
{
    public class Email : DomainDrivenDesign.ObjectValues.ValueObject<Email>
    {
        public string Value { get; private set; }

        public ValidationResult ValidationResult { get; private set; }

        public Email(string Email = null)
        {
            Value = Email;
            EhValido();
        }

        public Email()
        {
            EhValido();
        }
        
        public bool EhValido()
        {
            ValidationResult = new EmailEstaConsistenteValidator().Validate(this);
            return ValidationResult?.IsValid ?? false;
        }

        protected override bool EqualsCore(Email other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            var hashCode = -783812246;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Value);
            return hashCode;
        }
     
        public static implicit operator string(Email email)
        {
            return email.Value;
        }

        public static implicit operator Email(string email)
        {
            return new Email(email);
        }
    }
}
