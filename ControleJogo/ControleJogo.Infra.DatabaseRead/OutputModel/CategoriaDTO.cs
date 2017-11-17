using System;

namespace ControleJogo.Infra.DatabaseRead.OutputModel
{
    public class CategoriaDTO : IOutputModel
    {
        public CategoriaDTO(Guid id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        protected CategoriaDTO()
        {

        }

        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
    }
}
