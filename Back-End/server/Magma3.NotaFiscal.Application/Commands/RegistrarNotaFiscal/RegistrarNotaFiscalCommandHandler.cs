using Magma3.NotaFiscal.Application.Mediator;
using Magma3.NotaFiscal.Application.Mediator.Notifications;
using Magma3.NotaFiscal.Domain.Entities;
using Magma3.NotaFiscal.Infra.Data.UoW;
using MediatR;

namespace Magma3.NotaFiscal.Application.Commands.RegistrarNotaFiscal
{
    public class RegistrarNotaFiscalCommandHandler : CommandHandler,
        IRequestHandler<RegistrarNotaFiscalCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public RegistrarNotaFiscalCommandHandler(
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> notifications,
            IUnitOfWork uow) : base(mediator, notifications)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(RegistrarNotaFiscalCommand request, CancellationToken cancellationToken)
        {
            await _uow.BeginTransactionAsync();

            var cliente = request.Cliente.ToEntity();
            await _uow.Clientes.AdicionarClienteAsync(cliente);
            await _uow.CompleteAsync();

            var endereco = request.Cliente.Endereco.ToEntity(cliente.Id);
            await _uow.Clientes.AdicionarClienteEnderecoAsync(endereco);
            await _uow.CompleteAsync();

            var celular = request.Cliente.Contato.ToEntity(cliente.Id);
            await _uow.Clientes.AdicionarClienteContatoAsync(celular);
            await _uow.CompleteAsync();

            var produto = request.Produto.ToEntity();
            await _uow.Produtos.AdicionarProdutoAsync(produto);
            await _uow.CompleteAsync();

            var notaFiscal = request.NotaFiscal.ToEntity(cliente.Id);
            await _uow.NotasFiscais.AdicionarNotaFiscalAsync(notaFiscal);
            await _uow.CompleteAsync();

            await _uow.NotasFiscais
                .AdicionarProdutoNaNotaFiscalAsync(
                    new NotaFiscalProduto(notaFiscal.Id, 
                    produto.Id, 
                    produto.ProdutoPreco, 
                    request.DataCompra
                 ));

            await _uow.CompleteAsync();

            await _uow.CommitAsync();

            request.NotaFiscal.SetNotaFiscalUId(notaFiscal.UId);

            return true;
        }
    }
}