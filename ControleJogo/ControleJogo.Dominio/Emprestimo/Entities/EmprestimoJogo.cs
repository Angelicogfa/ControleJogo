﻿using ControleJogo.Dominio.Amigos.Entities;
using ControleJogo.Dominio.Jogos.Entities;
using DomainDrivenDesign.Entities;
using FluentValidation.Results;
using System;

namespace ControleJogo.Dominio.Emprestimo.Entities
{
    public class EmprestimoJogo : Entity<Guid>
    {
        public Guid JogoId { get; private set; }
        public Guid AmigoId { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime DataDevolucao { get; private set; }
        public bool Devolvido { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        public virtual Jogo Jogo { get; private set; }
        public virtual Amigo Amigo { get; private set; }

        internal EmprestimoJogo(Guid JogoId, Guid AmigoId)
        {
            Id = Guid.NewGuid();
            this.JogoId = JogoId;
            this.AmigoId = AmigoId;
            DataEmprestimo = DateTime.Now;
            this.DataDevolucao = DataEmprestimo.AddDays(7);
        }

        protected EmprestimoJogo()
        {

        }

        public void AlterarDataDevolucao(DateTime NovaDataDevolucao)
        {
            this.DataDevolucao = NovaDataDevolucao;
        }

        public bool EhValido()
        {
            return ValidationResult?.IsValid ?? false;
        }

        public void Devolver()
        {
            Devolvido = true;
            DataDevolucao = DateTime.Now;
        }

        public void Renovar()
        {
            Devolvido = false;

            DateTime novaData = DataDevolucao.AddDays(7);
            int dias = (novaData - DataEmprestimo).Days;
            if (dias > 21)//Tres semanas
                throw new InvalidOperationException("Renovação não permitida!");

            DataDevolucao = novaData;
         }
    }
}
