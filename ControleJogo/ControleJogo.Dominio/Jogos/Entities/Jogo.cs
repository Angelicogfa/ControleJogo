﻿using ControleJogo.Dominio.Emprestimo.Entities;
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
        public DateTime DataCadastro { get; private set; }
        public StatusJogo Status { get; private set; }
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
        public ICollection<EmprestimoJogo> Emprestados { get; private set; }

        public Jogo(string Nome, Guid CategoriaId, int QuantidadeJogos = 1)
        {
            Id = Guid.NewGuid();
            this.CategoriaId = CategoriaId;
            DataCadastro = DateTime.Now;
            this.Nome = Nome;
            this.QuantidadeJogos = QuantidadeJogos;
            Status = QuantidadeJogos > 0 ? StatusJogo.Disponivel : StatusJogo.Indisponivel;
            Emprestados = new List<EmprestimoJogo>();
        }

        protected Jogo()
        {
            Emprestados = new List<EmprestimoJogo>();
        }

        public void AlterarNome(string Nome) => this.Nome = Nome;
        public void AlterarCategoria(Guid CategoriaId) => this.CategoriaId = CategoriaId;

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
