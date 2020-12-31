using NerdStore.Catalago.Domain.Events;
using NerdStore.Core.Bus;
using System;
using System.Threading.Tasks;

namespace NerdStore.Catalago.Domain
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatrHandler _bus;

        public EstoqueService(IProdutoRepository produtoRepository,
                              IMediatrHandler bus)
        {
            _produtoRepository = produtoRepository;
            _bus = bus;
        }

        public async Task<bool> DebitarEstoque(Guid productId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(productId);

            if (produto == null) return false;

            if (!produto.PossuiEstoque(quantidade)) return false;

            produto.DebitarEstoque(quantidade);

            if (produto.QuantidadeEstoque < 10)
            {
                await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));
            }

            _produtoRepository.Atualizar(produto);

            return await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> ReporEstoque(Guid productId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(productId);

            if (produto == null) return false;
            
            produto.ReporEstoque(quantidade);

            _produtoRepository.Atualizar(produto);

            return await _produtoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }

    }


}
