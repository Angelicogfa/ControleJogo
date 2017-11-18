using System;
using System.ComponentModel.DataAnnotations;

namespace ControleJogo.Infra.DatabaseRead.OutputModel
{
    public class JogoDTO : IOutputModel
    {
        public JogoDTO(Guid id, string nome, Guid categoriaId, string descricaoCategoria, Guid consoleId, string descricaoConsole, bool indisponivel, int quantidadeJogos)
        {
            Id = id;
            Nome = nome;
            CategoriaId = categoriaId;
            DescricaoCategoria = descricaoCategoria;
            ConsoleId = consoleId;
            DescricaoConsole = descricaoConsole;
            Indisponivel = indisponivel;
            QuantidadeJogos = quantidadeJogos;
        }

        protected JogoDTO()
        {

        }

        [Key]
        public Guid Id { get; private set; }
        [Display(Name = "Nome")]
        public string Nome { get; private set; }
        [ScaffoldColumn(false)]
        public Guid CategoriaId { get; private set; }
        [Display(Name = "Categoria")]
        public string DescricaoCategoria { get; private set; }
        [ScaffoldColumn(false)]
        public Guid ConsoleId { get; private set; }
        [Display(Name = "Console")]
        public string DescricaoConsole { get; set; }
        [Display(Name = "Jogo Indisponível")]
        public bool Indisponivel { get; private set; }
        [Display(Name = "Quant. Disp. para Empréstimo")]
        public int QuantidadeJogos { get; private set; }
    }
}
