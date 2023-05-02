using Magma3.NotaFiscal.Domain.Repositories;

namespace Magma3.NotaFiscal.Infra.Data.UoW
{
    public interface IUnitOfWork
    {
        INotaFiscalRepository NotasFiscais { get; }
        IClienteRepository Clientes { get; }
        IProdutoRepository Produtos { get; }
        Task<bool> CompleteAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
    }
}