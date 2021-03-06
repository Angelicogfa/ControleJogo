﻿using ControleJogo.Dominio.Jogos.Entities;
using ControleJogo.Dominio.Jogos.Repositories;
using System;
using ControleJogo.Infra.Data.Contexto;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace ControleJogo.Infra.Data.Repositories
{
    public class JogoRepository : RepositoryBase<Jogo, Guid>, IJogoRepository
    {
        public JogoRepository(ControleJogoContext ctx) : base(ctx)
        {
        }

        public Task<bool> NomeEhUnicoPorConsole(Guid jogoId, Guid consoleId, string nome)
        {
            return _ctx.Jogos.Where(t => t.ConsoleId != consoleId && t.Id != jogoId).AnyAsync(t => t.Nome.Equals(nome));
        }

        public async Task<bool> PossuiEmprestimos(Guid id)
        {
            return await _ctx.Emprestimos.Where(t => t.JogoId == id).AnyAsync();
        }

        public override async Task<Jogo> ProcurarPeloId(Guid Id)
        {
            var dado = await base.ProcurarPeloId(Id);
            if (dado != null)
                await _ctx.Emprestimos.Where(t => t.AmigoId == Id && t.Devolvido == false).ToListAsync();
            return dado;
        }
    }
}
