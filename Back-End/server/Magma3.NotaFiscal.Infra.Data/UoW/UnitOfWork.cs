using Magma3.NotaFiscal.Domain.Repositories;
using Magma3.NotaFiscal.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Magma3.NotaFiscal.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly NotaFiscalDbContext _context;
        private IDbContextTransaction _transaction;
        public INotaFiscalRepository NotasFiscais { get; }
        public IClienteRepository Clientes { get; }
        public IProdutoRepository Produtos { get; }

        public UnitOfWork(
            NotaFiscalDbContext context,
            INotaFiscalRepository notaFiscalRepository,
            IClienteRepository clientesRepository,
            IProdutoRepository produtosRepository)
        {
            _context = context;
            NotasFiscais = notaFiscalRepository;
            Clientes = clientesRepository;
            Produtos = produtosRepository;
        }

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await _transaction.RollbackAsync();
                throw ex;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
        }
    }
}