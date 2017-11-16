using ControleJogo.Dominio.Amigos.Entities;
using DomainDrivenDesign.Services;
using System;

namespace ControleJogo.Dominio.Amigos.Services
{
    public interface IAmigoService : IService<Amigo, Guid>
    {
    }
}
