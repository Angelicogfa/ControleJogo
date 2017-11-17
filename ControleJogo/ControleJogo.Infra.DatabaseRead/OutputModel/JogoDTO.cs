using System;

namespace ControleJogo.Infra.DatabaseRead.OutputModel
{
    public class JogoDTO
    {
        public JogoDTO(Guid id, string nome, Guid categoriaId, Guid consoleId, bool indisponivel, byte[] fotoJogo, int quantidadeJogos)
        {
            Id = id;
            Nome = nome;
            CategoriaId = categoriaId;
            ConsoleId = consoleId;
            Indisponivel = indisponivel;
            FotoJogo = fotoJogo;
            QuantidadeJogos = quantidadeJogos;
        }

        protected JogoDTO()
        {

        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public Guid CategoriaId { get; private set; }
        public Guid ConsoleId { get; private set; }
        public bool Indisponivel { get; private set; }
        public byte[] FotoJogo { get; private set; }
        public int QuantidadeJogos { get; private set; }
    }
}
