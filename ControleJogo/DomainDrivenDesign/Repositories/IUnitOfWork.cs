using System;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
