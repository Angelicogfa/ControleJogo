using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleJogo.Aplicacao.InputModel
{
    public class JogoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} não informado!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O {0} deve ter de {1} a {2} caractéres")]
        public string Nome { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "{0} não informado!")]
        public Guid CategoriaId { get; set; }

        [Display(Name = "Console")]
        [Required(ErrorMessage = "{0} não informado!")]
        public Guid ConsoleId { get; set; }

        [Display(Name = "Indisponível")]
        [Required(ErrorMessage = "{0} não informado!")]
        public bool Indisponivel { get; set; }

        [Display(Name = "Foto")]
        public byte[] FotoJogo { get; set; }

        [Display(Name = "Quantidade Jogos")]
        [Required(ErrorMessage = "{0} não informado!")]
        public int QuantidadeJogos { get; set; }

        [ScaffoldColumn(false)]
        public FluentValidation.Results.ValidationResult ValidationResult { get; set; }
    }
}
