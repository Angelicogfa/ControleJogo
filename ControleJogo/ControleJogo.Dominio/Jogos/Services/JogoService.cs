﻿using ControleJogo.Dominio.Jogos.Entities;
using DomainDrivenDesign.Services;
using System;
using ControleJogo.Dominio.Jogos.Repositories;
using System.Threading.Tasks;

namespace ControleJogo.Dominio.Jogos.Services
{
    public class JogoService : Service<Jogo, Guid>, IJogoService
    {
        public JogoService(IJogoRepository repository) : base(repository)
        {
        }

        public override Jogo Adicionar(Jogo obj)
        {
            if (!obj.EhValido())
                return obj;

            return obj = base.Adicionar(obj);
        }

        public override Jogo Atualizar(Jogo obj)
        {
            if (!obj.EhValido())
                return obj;

            return obj = base.Atualizar(obj);
        }

        public Task<bool> JogoDisponivelParaEmprestimo(Guid JogoId)
        {
            return Task.FromResult(true);
        }
    }
}
