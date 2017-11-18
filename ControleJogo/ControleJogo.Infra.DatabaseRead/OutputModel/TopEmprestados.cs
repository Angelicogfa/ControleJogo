using System;
using System.ComponentModel.DataAnnotations;

namespace ControleJogo.Infra.DatabaseRead.OutputModel
{
    public class TopEmprestados
    {
        public TopEmprestados(Guid jogoId, string nomeJogo, int quantidadeEmprestimos)
        {
            JogoId = jogoId;
            NomeJogo = nomeJogo;
            QuantidadeEmprestimos = quantidadeEmprestimos;
        }

        
        [ScaffoldColumn(false)]
        public Guid JogoId { get; private set; }
        [Display(Name ="Jogo")]
        public string NomeJogo { get; private set; }
        [Display(Name = "Quantidade Emprestada")]
        public int QuantidadeEmprestimos { get; private set; }
    }
}
