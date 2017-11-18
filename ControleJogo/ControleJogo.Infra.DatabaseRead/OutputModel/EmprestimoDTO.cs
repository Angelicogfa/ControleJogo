using System;
using System.ComponentModel.DataAnnotations;

namespace ControleJogo.Infra.DatabaseRead.OutputModel
{
    public class EmprestimoDTO
    {
        public EmprestimoDTO(Guid emprestimoid, Guid amigoId, string nomeAmigo, Guid jogoId, string nomeJogo, DateTime dataAquisicao, DateTime dataDevolucao, bool devolvido)
        {
            Id = emprestimoid;
            AmigoId = amigoId;
            NomeAmigo = nomeAmigo;
            JogoId = jogoId;
            NomeJogo = nomeJogo;
            DataEmprestimo = dataAquisicao;
            DataDevolucao = dataDevolucao;
            Devolvido = devolvido;

        }

        protected EmprestimoDTO()
        {

        }

        [Key]
        public Guid Id { get; private set; }
        [ScaffoldColumn(false)]
        public Guid AmigoId { get; private set; }
        [Display(Name = "Amigo")]
        public string NomeAmigo { get; private set; }
        [ScaffoldColumn(false)]
        public Guid JogoId { get; private set; }
        [Display(Name = "Jogo")]
        public string NomeJogo { get; private  set; }
        [Display(Name = "Data do Emprestimo")]
        public DateTime DataEmprestimo { get; private  set; }
        [Display(Name = "Data para Devolução")]
        public DateTime DataDevolucao { get; private  set; }
        public bool Devolvido { get; private  set; }
    }
}
