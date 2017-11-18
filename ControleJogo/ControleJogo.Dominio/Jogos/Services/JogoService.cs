using ControleJogo.Dominio.Jogos.Entities;
using DomainDrivenDesign.Services;
using System;
using ControleJogo.Dominio.Jogos.Repositories;
using System.Threading.Tasks;
using System.Linq;
using ControleJogo.Dominio.Jogos.Validations;

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

        public override Jogo Remover(Jogo obj)
        {
            obj.ValidationResult = new JogoPodeSerRemovidoApenasSeNaoExistirEmprestimosEfetuadosValidator((IJogoRepository)_repository).Validate(obj);
            if (!obj.ValidationResult.IsValid)
                return obj;

            return obj = base.Remover(obj);
        }

        public async Task<bool> JogoDisponivelParaEmprestimo(Guid JogoId)
        {
            var jogo = await _repository.ProcurarPeloId(JogoId);
            if (jogo == null)
                throw new InvalidOperationException($"Jogo não localizado para o Id {JogoId}");

            return jogo.CopiasDisponiveis > 0;                      
        }
    }
}
