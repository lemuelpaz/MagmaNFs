using Magma3.NotaFiscal.Application.Mediator.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Magma3.NotaFiscal.Api.Controllers
{
    public abstract class ApiController : ControllerBase 
    {
        protected ILogger _logger;
        protected readonly DomainNotificationHandler _notifications;
        protected ApiController(ILogger logger, INotificationHandler<DomainNotification> notifications)
        {
            _logger = logger;
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected ActionResult ResponseApiOk(object? result = null)
        {
            ModelStateIsValid();

            if (!_notifications.HasNotifications())
            {
                return Ok(new 
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => new  { Message = n.Value }).FirstOrDefault()
            });
        }

        protected ActionResult ResponseApiCreatedAtAction(string? actionName, object? routeValues, object? result = null)
        {
            ModelStateIsValid();

            if (!_notifications.HasNotifications())
            {
                return CreatedAtAction(actionName, routeValues, new { success = true, data = result });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => new { Message = n.Value }).FirstOrDefault()
            });
        }

        protected ActionResult ResponseApiNotFound()
        {
            return NotFound(new
            {
                success = false,
                errors = _notifications.GetNotifications().Select(n => new { Message = n.Value }).FirstOrDefault()
            });
        }

        private void ModelStateIsValid()
        {
            if (!ModelState.IsValid)
            {
                for (var i = 0; i < ModelState.Count; i++)
                    _notifications.Handle(new DomainNotification(ModelState.Keys.ToList()[i], ModelState.Values.ToList()[i].Errors.FirstOrDefault().ErrorMessage), CancellationToken.None);
            }
        }
    }
}