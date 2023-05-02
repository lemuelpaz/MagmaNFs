using FluentValidation;
using Magma3.NotaFiscal.Domain.Repositories;

namespace Magma3.NotaFiscal.Application.Queries.BuscarNotaFiscalPeloUId
{
    public class BuscarNotaFiscalPeloUIdQueryValidator : AbstractValidator<BuscarNotaFiscalPeloUIdQuery>
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;

        public BuscarNotaFiscalPeloUIdQueryValidator(INotaFiscalRepository notaFiscalRepository)
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