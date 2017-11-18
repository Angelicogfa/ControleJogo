using System;
using System.ComponentModel.DataAnnotations;

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

        [Key]
        public Guid Id { get; private set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; private set; }
    }
}
