using Magma3.NotaFiscal.Application.Commands.ExluirNotaFiscal;
using Magma3.NotaFiscal.Application.Commands.RegistrarNotaFiscal;
using Magma3.NotaFiscal.Application.Mediator;
using Magma3.NotaFiscal.Application.Mediator.Notifications;
using Magma3.NotaFiscal.Application.Queries.BuscarNotaFiscalPeloUId;
using Magma3.NotaFiscal.Application.Queries.BuscarTodasNotasFiscais;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Magma3.NotaFiscal.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/")]
    public class NotaFiscalController : ApiController
    {
        private readonly IMediatorHandler _mediator;

        public NotaFiscalController(
             ILogger<NotaFiscalController> logger,
             INotificationHandler<DomainNotification> notifications,
             IMediatorHandler mediator) : base(logger, notifications)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("notas-fiscais/registrar")]
        public async Task<ActionResult> RegistrarNotaFiscal([FromBody] RegistrarNotaFiscalCommand command, CancellationToken cancellationToken)
        {
            await _mediator.SendCommand(command, cancellationToken);

            return ResponseApiCreatedAtAction(nameof(BuscarNotaFiscalPeloUId), new { notaFiscalUId = command.NotaFiscal.NotaFiscalUId }, command);
        }


        [HttpGet]
        [Route("notas-fiscais/buscar-todas")]
        public async Task<ActionResult> BuscarTodasNotasFiscais(CancellationToken cancellationToken)
        {
            var query = new BuscarTodasNotasFiscaisQuery();

            await _mediator.SendCommand(query, cancellationToken);

            return ResponseApiOk(query.GetResponse());
        }

        [HttpGet]
        [Route("notas-fiscais/buscar-pelo-uid/{notaFiscalUId}")]
        public async Task<ActionResult> BuscarNotaFiscalPeloUId([FromRoute] Guid notaFiscalUId, CancellationToken cancellationToken)
        {
            var query = new BuscarNotaFiscalPeloUIdQuery(notaFiscalUId);

            await _mediator.SendCommand(query, cancellationToken);

            if (query.GetResponse() == null) return ResponseApiNotFound();

            return ResponseApiOk(query.GetResponse());
        }

        [HttpDelete]
        [Route("notas-fiscais/excluir/{notaFiscalUId}")]
        public async Task<ActionResult> ExcluirNotaFiscalPeloUId([FromRoute] Guid notaFiscalUId, CancellationToken cancellationToken)
        {
            await _mediator.SendCommand(new ExluirNotaFiscalCommand(notaFiscalUId), cancellationToken);

            return ResponseApiOk();
        }
    }
}