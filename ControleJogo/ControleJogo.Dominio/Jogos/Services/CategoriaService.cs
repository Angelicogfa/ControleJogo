using ControleJogo.Dominio.Jogos.Entities;
using DomainDrivenDesign.Services;
using System;
using ControleJogo.Dominio.Jogos.Repositories;

namespace ControleJogo.Dominio.Jogos.Services
{
    public class CategoriaService : Service<Categoria, Guid>, ICategoriaService
    {
        public CategoriaService(ICategoriaRepository repository) : base(repository)
        {
        }
    }
}
