using System.Threading.Tasks;

namespace NerdStore.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
