using Magma3.NotaFiscal.Application.DTOs;
using Magma3.NotaFiscal.Application.Mediator.Message;

namespace Magma3.NotaFiscal.Application.Queries.BuscarTodasNotasFiscais
{
    public class BuscarTodasNotasFiscaisQuery : Command
    {
        private List<NotaFiscalViewModel> _notasFiscais { get; set; }
        public void SetResponse(List<NotaFiscalViewModel> notasFiscais) => _notasFiscais = notasFiscais;
        public List<NotaFiscalViewModel> GetResponse() => _notasFiscais;
    }
}