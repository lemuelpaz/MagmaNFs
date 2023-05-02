using Magma3.NotaFiscal.Application.Mediator;
using Magma3.NotaFiscal.Application.Mediator.Notifications;
using Magma3.NotaFiscal.Infra.Data.UoW;
using MediatR;

namespace Magma3.NotaFiscal.Application.Commands.ExluirNotaFiscal
{
    public class ExluirNotaFiscalCommandHandler : CommandHandler,
        IRequestHandler<ExluirNotaFiscalCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public ExluirNotaFiscalCommandHandler(
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> notifications,
            IUnitOfWork uow) : base(mediator, notifications)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(ExluirNotaFiscalCommand request, CancellationToken cancellationToken)
        {
            var notaFiscal = await _uow.NotasFiscais.BuscarNotaFiscalPeloUIdAsync(request.NotaFiscalUId, cancellationToken);

            notaFiscal.Excluir();

            return await _uow.CompleteAsync();
        }
    }
}