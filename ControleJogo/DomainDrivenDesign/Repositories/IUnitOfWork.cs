using System.Threading.Tasks;

namespace DomainDrivenDesign.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
