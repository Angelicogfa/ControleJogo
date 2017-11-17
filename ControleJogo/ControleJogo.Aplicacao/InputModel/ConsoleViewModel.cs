using System;
using System.ComponentModel.DataAnnotations;

namespace ControleJogo.Aplicacao.InputModel
{
    public class ConsoleViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "{0} não informada!")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public FluentValidation.Results.ValidationResult ValidationResult { get; set; }
    }
}
