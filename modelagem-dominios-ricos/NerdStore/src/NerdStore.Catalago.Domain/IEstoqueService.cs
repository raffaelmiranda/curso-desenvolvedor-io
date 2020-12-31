using System;
using System.Threading.Tasks;

namespace NerdStore.Catalago.Domain
{
    public interface IEstoqueService : IDisposable
    {
        Task<bool> DebitarEstoque(Guid productId, int quantidade);
        Task<bool> ReporEstoque(Guid productId, int quantidade);

    }
}
