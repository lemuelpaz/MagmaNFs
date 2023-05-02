using Magma3.NotaFiscal.Application.Mediator.Message;

namespace Magma3.NotaFiscal.Application.Commands.ExluirNotaFiscal
{
    public class ExluirNotaFiscalCommand : Command
    {
        public ExluirNotaFiscalCommand(Guid notaFiscalUId)
        {
            NotaFiscalUId = notaFiscalUId;
        }

        public Guid NotaFiscalUId { get; set; }
    }
}