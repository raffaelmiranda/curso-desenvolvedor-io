using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDBContext context) : base(context) { }
        
        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await _db.Fornecedores
                .AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await _db.Fornecedores
               .AsNoTracking()
               .Include(c => c.Produtos)
               .Include(c => c.Endereco)
               .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
