using Magma3.NotaFiscal.Domain.Entities;
using Magma3.NotaFiscal.Domain.ValueObjects;

namespace Magma3.NotaFiscal.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task AdicionarClienteAsync(Cliente cliente, CancellationToken cancellationToken = default);
        Task AdicionarClienteEnderecoAsync(Endereco endereco, CancellationToken cancellationToken = default);
        Task AdicionarClienteContatoAsync(Contato contato, CancellationToken cancellationToken = default);

    }
}