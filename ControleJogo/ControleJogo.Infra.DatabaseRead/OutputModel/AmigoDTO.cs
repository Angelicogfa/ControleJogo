using System;

namespace ControleJogo.Infra.DatabaseRead.OutputModel
{
    public class AmigoDTO
    {
        public AmigoDTO(Guid id, string nome, string email, DateTime dataCadastro, Estado estado, string cEP, string bairro, string endereco, string numero, string complemento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataCadastro = dataCadastro;
            Estado = estado;
            CEP = cEP;
            Bairro = bairro;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
        }

        protected AmigoDTO()
        {

        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public Estado Estado { get;  private set; }
        public string CEP { get;  private set; }
        public string Bairro { get;  private set; }
        public string Endereco { get;  private set; }
        public string Numero { get;  private set; }
        public string Complemento { get;  private set; }
    }
}
