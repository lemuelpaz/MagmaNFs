using FluentValidation.Results;
using MediatR;

namespace Magma3.NotaFiscal.Application.Mediator.Message
{
    public abstract class Command : Message, IRequest<bool>
    {
        protected Command()
        {
            SetTimestamp(DateTime.Now);
        }
    }

    public abstract class Command<TResult> : Message, IRequest<ValidationResult> where TResult : ValidationResult
    {
        protected Command()
        {
            SetTimestamp(DateTime.Now);
        }
    }
}