using Magma3.NotaFiscal.Application.DTOs;
using Magma3.NotaFiscal.Application.Mediator;
using Magma3.NotaFiscal.Application.Mediator.Notifications;
using Magma3.NotaFiscal.Domain.Repositories;
using MediatR;

namespace Magma3.NotaFiscal.Application.Queries.BuscarTodasNotasFiscais
{
    public class BuscarTodasNotasFiscaisQueryHandler : CommandHandler,
        IRequestHandler<BuscarTodasNotasFiscaisQuery, bool>
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;

        public BuscarTodasNotasFiscaisQueryHandler(
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> notifications,
            INotaFiscalRepository notaFiscalRepository) : base(mediator, notifications)
        {
            _notaFiscalRepository = notaFiscalRepository;
        }

        public async Task<bool> Handle(BuscarTodasNotasFiscaisQuery request, CancellationToken cancellationToken)
        {
            var notasFiscais = await _notaFiscalRepository.BuscarTodasNotasFiscaisAsync(cancellationToken);

            var notasFiscaisViewModel = notasFiscais
                .Select(x => NotaFiscalViewModel.FromEntity(x))
                .ToList();

            request.SetResponse(notasFiscaisViewModel);

            return true;
        }
    }
}