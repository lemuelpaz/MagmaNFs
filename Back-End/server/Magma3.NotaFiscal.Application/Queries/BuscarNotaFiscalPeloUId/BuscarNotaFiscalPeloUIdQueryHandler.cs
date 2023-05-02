using Magma3.NotaFiscal.Application.DTOs;
using Magma3.NotaFiscal.Application.Mediator.Notifications;
using Magma3.NotaFiscal.Application.Mediator;
using Magma3.NotaFiscal.Domain.Repositories;
using MediatR;

namespace Magma3.NotaFiscal.Application.Queries.BuscarNotaFiscalPeloUId
{
    public class BuscarNotaFiscalPeloUIdQueryHandler : CommandHandler,
        IRequestHandler<BuscarNotaFiscalPeloUIdQuery, bool>
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;

        public BuscarNotaFiscalPeloUIdQueryHandler(
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> notifications,
            INotaFiscalRepository notaFiscalRepository) : base(mediator, notifications)
        {
            _notaFiscalRepository = notaFiscalRepository;
        }

        public async Task<bool> Handle(BuscarNotaFiscalPeloUIdQuery request, CancellationToken cancellationToken)
        {
            var notaFiscal = await _notaFiscalRepository.BuscarNotaFiscalPeloUIdAsNoTrackingAsync(request.NotaFiscalUId, cancellationToken);

            var notasFiscaisViewModel = NotaFiscalViewModel.FromEntity(notaFiscal);

            request.SetResponse(notasFiscaisViewModel);

            return true;
        }
    }
}