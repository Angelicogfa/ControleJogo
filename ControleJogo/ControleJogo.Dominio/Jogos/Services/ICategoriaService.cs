using ControleJogo.Dominio.Jogos.Entities;
using DomainDrivenDesign.Services;
using System;

namespace ControleJogo.Dominio.Jogos.Services
{
    public interface ICategoriaService : IService<Categoria, Guid>
    {
    }
}
