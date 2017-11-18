using System;
using System.ComponentModel.DataAnnotations;

namespace ControleJogo.Infra.DatabaseRead.OutputModel
{
    public class JogoDTO : IOutputModel
    {
        public JogoDTO(Guid id, string nome, Guid categoriaId, string descricaoCategoria, Guid consoleId, string descricaoConsole, bool disponivel, int quantidadeJogos)
        {
            Id = id;
            Nome = nome;
            CategoriaId = categoriaId;
            DescricaoCategoria = descricaoCategoria;
            ConsoleId = consoleId;
            DescricaoConsole = descricaoConsole;
            Disponivel = disponivel;
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
        [Display(Name = "Jogo Disponível")]
        public bool Disponivel { get; private set; }
        [Display(Name = "Quant. de Jogos")]
        public int QuantidadeJogos { get; private set; }
    }
}
