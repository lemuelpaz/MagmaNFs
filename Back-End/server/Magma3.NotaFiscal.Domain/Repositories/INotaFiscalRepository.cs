using Magma3.NotaFiscal.Domain.Entities;

namespace Magma3.NotaFiscal.Domain.Repositories
{
    public interface INotaFiscalRepository
    {
        Task<List<Entities.NotaFiscal>> BuscarTodasNotasFiscaisAsync(CancellationToken cancellationToken = default);
        Task<Entities.NotaFiscal> BuscarNotaFiscalPeloUIdAsync(Guid notaFiscalUId, CancellationToken cancellationToken = default);
        Task<Entities.NotaFiscal> BuscarNotaFiscalPeloUIdAsNoTrackingAsync(Guid notaFiscalUId, CancellationToken cancellationToken = default);
        Task AdicionarNotaFiscalAsync(Entities.NotaFiscal notaFiscal, CancellationToken cancellationToken = default);
        Task AdicionarProdutoNaNotaFiscalAsync(NotaFiscalProduto produto, CancellationToken cancellationToken = default);
    }
}