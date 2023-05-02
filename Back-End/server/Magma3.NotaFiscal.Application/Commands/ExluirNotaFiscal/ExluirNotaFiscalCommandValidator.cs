using FluentValidation;
using Magma3.NotaFiscal.Domain.Repositories;

namespace Magma3.NotaFiscal.Application.Commands.ExluirNotaFiscal
{
    public class ExluirNotaFiscalCommandValidator : AbstractValidator<ExluirNotaFiscalCommand>
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;

        public ExluirNotaFiscalCommandValidator(INotaFiscalRepository notaFiscalRepository)
        {
            _notaFiscalRepository = notaFiscalRepository;

            RuleFor(x => x)
                .Must(cmd => NotaFiscalExiste(cmd.NotaFiscalUId))
                .WithMessage("Nota Fiscal informada não existe.");
        }

        private bool NotaFiscalExiste(Guid notaFiscalUId)
        {
            var nf = _notaFiscalRepository.BuscarNotaFiscalPeloUIdAsNoTrackingAsync(notaFiscalUId).Result;

            return nf != null;
        }
    }
}