using Magma3.NotaFiscal.Domain.Entities;

namespace Magma3.NotaFiscal.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Task AdicionarProdutoAsync(Produto produto, CancellationToken cancellationToken = default);
    }
}