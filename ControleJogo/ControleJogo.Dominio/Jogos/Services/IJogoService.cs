using ControleJogo.Dominio.Jogos.Entities;
using DomainDrivenDesign.Services;
using System;

namespace ControleJogo.Dominio.Jogos.Services
{
    public interface IJogoService : IService<Jogo, Guid>
    {
    }
}
