using Magma3.NotaFiscal.Domain.Entities;
using Magma3.NotaFiscal.Domain.Repositories;
using Magma3.NotaFiscal.Infra.Data.Context;

namespace Magma3.NotaFiscal.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly NotaFiscalDbContext _context;

        public ProdutoRepository(NotaFiscalDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarProdutoAsync(Produto produto, CancellationToken cancellationToken = default)
        {
            await _context.Produtos.AddAsync(produto, cancellationToken);
        }
    }
}