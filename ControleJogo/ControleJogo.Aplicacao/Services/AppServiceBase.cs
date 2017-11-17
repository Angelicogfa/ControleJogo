using DomainDrivenDesign.Repositories;
using System;
using System.Threading.Tasks;

namespace ControleJogo.Aplicacao.Services
{
    public abstract class AppServiceBase : IDisposable
    {
        private IUnitOfWork unitOfWork;
        public AppServiceBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<bool> Commit()
        {
            return unitOfWork.Commit();
        }

        public virtual void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
