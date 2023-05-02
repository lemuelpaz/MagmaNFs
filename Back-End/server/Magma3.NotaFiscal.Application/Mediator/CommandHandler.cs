using Magma3.NotaFiscal.Application.Mediator.Notifications;
using MediatR;

namespace Magma3.NotaFiscal.Application.Mediator
{
    public abstract class CommandHandler
    {
        protected readonly IMediatorHandler _mediator;
        protected readonly DomainNotificationHandler _notifications;

        protected CommandHandler(IMediatorHandler mediator, INotificationHandler<DomainNotification> notifications)
        {
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)notifications;
        }
    }
}