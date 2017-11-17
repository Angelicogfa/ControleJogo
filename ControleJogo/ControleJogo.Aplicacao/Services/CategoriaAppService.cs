using System.Threading.Tasks;
using ControleJogo.Aplicacao.ViewModels;
using DomainDrivenDesign.Repositories;
using ControleJogo.Dominio.Jogos.Services;
using ControleJogo.Dominio.Jogos.Entities;
using AutoMapper;

namespace ControleJogo.Aplicacao.Services
{
    public class CategoriaAppService : AppServiceBase, ICategoriaAppService
    {
        readonly ICategoriaService categoriaService;
        public CategoriaAppService(IUnitOfWork unitOfWork, ICategoriaService categoriaService) : base(unitOfWork)
        {
            this.categoriaService = categoriaService;
        }

        public async Task<CategoriaViewModel> Adicionar(CategoriaViewModel model)
        {
            Categoria categoria = Mapper.Map<CategoriaViewModel, Categoria>(model);
            categoria = categoriaService.Adicionar(categoria);

            if (!categoria.ValidationResult.IsValid)
            {
                model.ValidationResult = categoria.ValidationResult;
                return model;
            }

            await Commit();
            return Mapper.Map<Categoria, CategoriaViewModel>(categoria);
        }

        public async Task<CategoriaViewModel> Atualizar(CategoriaViewModel model)
        {
            Categoria categoria = Mapper.Map<CategoriaViewModel, Categoria>(model);
            categoria = categoriaService.Atualizar(categoria);

            if (!categoria.ValidationResult.IsValid)
            {
                model.ValidationResult = categoria.ValidationResult;
                return model;
            }

            await Commit();
            return Mapper.Map<Categoria, CategoriaViewModel>(categoria);
        }

        public async Task<CategoriaViewModel> Remover(CategoriaViewModel model)
        {
            Categoria categoria = Mapper.Map<CategoriaViewModel, Categoria>(model);
            categoria = categoriaService.Remover(categoria);

            if (!categoria.ValidationResult.IsValid)
            {
                model.ValidationResult = categoria.ValidationResult;
                return model;
            }

            await Commit();
            return Mapper.Map<Categoria, CategoriaViewModel>(categoria);
        }

        public override void Dispose()
        {
            categoriaService.Dispose();
            base.Dispose();
        }
    }
}
