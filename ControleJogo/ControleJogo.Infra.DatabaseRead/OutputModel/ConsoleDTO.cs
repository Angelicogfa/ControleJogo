using System;

namespace ControleJogo.Infra.DatabaseRead.OutputModel
{
    public class ConsoleDTO : IOutputModel
    {
        public ConsoleDTO(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        protected ConsoleDTO()
        {

        }

        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
    }
}
