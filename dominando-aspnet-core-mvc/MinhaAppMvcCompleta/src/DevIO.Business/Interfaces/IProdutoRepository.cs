using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto> ObterProdutoFornecedor(Guid id);
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedores();
        Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId);
        
        
    }
}
