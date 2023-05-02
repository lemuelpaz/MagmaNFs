using Magma3.NotaFiscal.Application.DTOs;
using Magma3.NotaFiscal.Application.Mediator.Message;

namespace Magma3.NotaFiscal.Application.Queries.BuscarNotaFiscalPeloUId
{
    public class BuscarNotaFiscalPeloUIdQuery : Command
    {
        public BuscarNotaFiscalPeloUIdQuery(Guid notaFiscalUId)
        {
            NotaFiscalUId = notaFiscalUId;
        }

        public Guid NotaFiscalUId { get; set; }

        private NotaFiscalViewModel _notaFiscal { get; set; }
        public void SetResponse(NotaFiscalViewModel notaFiscal) => _notaFiscal = notaFiscal;
        public NotaFiscalViewModel GetResponse() => _notaFiscal;
    }
}