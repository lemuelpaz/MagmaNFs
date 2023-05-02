using Magma3.NotaFiscal.Application.Mediator.Message;
using MediatR;

namespace Magma3.NotaFiscal.Application.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T e, CancellationToken cancellationToken = default) where T : Event;
        Task<bool> SendCommand<T>(T c, CancellationToken cancellationToken = default) where T : Command;
    }

    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> SendCommand<T>(T c, CancellationToken cancellationToken = default) where T : Command
            => await _mediator.Send(c, cancellationToken);

        public async Task PublishEvent<T>(T e, CancellationToken cancellationToken = default) where T : Event
            => await _mediator.Publish(e, cancellationToken);
    }
}
