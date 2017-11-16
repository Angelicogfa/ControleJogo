﻿using ControleJogo.Dominio.Jogos.Entities;
using DomainDrivenDesign.Repositories;
using System;

namespace ControleJogo.Dominio.Jogos.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria, Guid>
    {
    }
}