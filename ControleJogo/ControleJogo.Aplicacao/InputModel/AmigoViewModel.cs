using System;
using System.ComponentModel.DataAnnotations;

namespace ControleJogo.Aplicacao.InputModel
{
    public class AmigoViewModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "{0} não informado!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O {2} deve ter de {1} a {0} caractéres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} não informado!")]
        [EmailAddress(ErrorMessage = "Email não é válido!")]
        [StringLength(120, ErrorMessage = "O {0} deve ter até {1} caractéres")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "{0} não informado!")]
        public Estado Estado { get;  set; }

        [Required(ErrorMessage = "{0} não informado!")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O {0} deve ter de {1} caractéres")]
        public string CEP { get;  set; }

        [Required(ErrorMessage = "{0} não informado!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O {0} deve ter de {1} caractéres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "{0} não informado!")]
        [StringLength(50, ErrorMessage = "O {0} deve ter de {1} a {2} caractéres")]
        public string Bairro { get;  set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "{0} não informado!")]
        [StringLength(50, ErrorMessage = "O {0} deve ter de {1} a {2} caractéres")]
        public string Endereco { get;  set; }

        [Required(ErrorMessage = "{0} não informado!")]
        [StringLength(10, MinimumLength =1, ErrorMessage = "O {0} deve ter de {1} a {2} caractéres")]
        public string Numero { get;  set; }

        [StringLength(30, ErrorMessage = "O {0} deve ter até {1} caractéres")]
        public string Complemento { get;  set; }

        [ScaffoldColumn(false)]
        public FluentValidation.Results.ValidationResult ValidationResult { get; set; }
    }
}
