using ControleJogo.Dominio.Amigos.Validations;
using FluentValidation.Results;
using System.Collections.Generic;

namespace ControleJogo.Dominio.Amigos.ObejctValues
{
    public class Logradouro : DomainDrivenDesign.ObjectValues.ValueObject<Logradouro>
    {
        public Estado Estado { get; private set; }
        public string CEP { get; private set; }
        public string Cidade { get; private set; }
        public string Bairro { get; private set; }
        public string Endereco { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }

        public ValidationResult ValidationResult { get; set; }


        protected Logradouro()
        {

        }

        public Logradouro(Estado estado, string cep, string cidade, string bairro, string endereco, string numero, string complemento)
        {
            Estado = estado;
            CEP = cep;
            Cidade = cidade;
            Bairro = bairro;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
        }

        public bool EhValido()
        {
            ValidationResult = new LogradouroEstaConsistenteValidator().Validate(this);
            return ValidationResult?.IsValid ?? false;
        }

        protected override bool EqualsCore(Logradouro logradouro)
        {
            return Estado == logradouro.Estado &&
                  CEP == logradouro.CEP &&
                  Cidade == logradouro.Cidade &&
                  Bairro == logradouro.Bairro &&
                  Endereco == logradouro.Endereco &&
                  Numero == logradouro.Numero &&
                  Complemento == logradouro.Complemento;
        }

        protected override int GetHashCodeCore()
        {
            var hashCode = -1107735805;
            hashCode = hashCode * -1521134295 + Estado.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CEP);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Cidade);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Bairro);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Endereco);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Numero);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Complemento);
            return hashCode;
        }
    }
}
