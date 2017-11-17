using ControleJogo.Dominio.Emprestimo.Entities;
using ControleJogo.Dominio.Jogos.Validations;
using DomainDrivenDesign.Entities;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleJogo.Dominio.Jogos.Entities
{
    public class Jogo : Entity<Guid>
    {
        public string Nome { get; private set; }
        public Guid CategoriaId { get; private set; }
        public Guid ConsoleId { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Indisponivel { get; private set; }
        public byte[] FotoJogo { get; private set; }
        public int QuantidadeJogos { get; private set; }

        public int CopiasDisponiveis
        {
            get
            {
                return QuantidadeJogos - Emprestados.Where(t => !t.Devolvido).Count();
            }
        }

        public ValidationResult ValidationResult { get; set; }
        
        public virtual Categoria Categoria { get; private set; }
        public virtual Console Console { get; private set; }
        public ICollection<EmprestimoJogo> Emprestados { get; private set; }

        public Jogo(string Nome, Guid CategoriaId, Guid ConsoleId, int QuantidadeJogos = 1)
        {
            Id = Guid.NewGuid();
            this.CategoriaId = CategoriaId;
            this.ConsoleId = ConsoleId;
            DataCadastro = DateTime.Now;
            this.Nome = Nome;
            this.QuantidadeJogos = QuantidadeJogos;
            Indisponivel = QuantidadeJogos > 0 ? false : true;
            Emprestados = new List<EmprestimoJogo>();
        }

        protected Jogo()
        {
            Emprestados = new List<EmprestimoJogo>();
        }

        public void AlterarNome(string Nome) => this.Nome = Nome;
        public void AlterarCategoria(Guid CategoriaId) => this.CategoriaId = CategoriaId;

        public void AlterarFotoJogo(byte[] FotoJogo) => this.FotoJogo = FotoJogo;

        public EmprestimoJogo NovoEmprestimo(Guid Amigo)
        {
            if (CopiasDisponiveis == 0)
                return null;

            return new EmprestimoJogo(Id, Amigo, DateTime.Now.AddDays(7));
        }

        protected internal bool AdicionarEmprestimo(EmprestimoJogo emprestimo)
        {
            if(emprestimo != null && (emprestimo.ValidationResult?.IsValid ?? false))
            {
                if(!Emprestados.Contains(emprestimo))
                    Emprestados.Add(emprestimo);
                return true;
            }
            return false;
        }

        public bool EhValido()
        {
            ValidationResult = new JogoEstaConsistenteValidator().Validate(this);
            return ValidationResult?.IsValid ?? false;
        }
    }
}
