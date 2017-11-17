using System;
using System.ComponentModel.DataAnnotations;

namespace ControleJogo.Infra.DatabaseRead.OutputModel
{
    public class AmigoDTO : IOutputModel
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

        [Display(Name ="Id")]
        public Guid Id { get; private set; }
        [Display(Name = "Nome")]
        public string Nome { get; private set; }
        [Display(Name = "Email")]
        public string Email { get; private set; }
        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; private set; }
        [Display(Name = "Estado")]
        public Estado Estado { get;  private set; }
        [Display(Name = "CEP")]
        public string CEP {get;  private set; }
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }
        [Display(Name = "Bairro")]
        public string Bairro { get;  private set; }
        [Display(Name = "Endereço")]
        public string Endereco { get;  private set; }
        [Display(Name = "Número")]
        public string Numero { get;  private set; }
        [Display(Name = "Complemento")]
        public string Complemento { get;  private set; }
    }
}
