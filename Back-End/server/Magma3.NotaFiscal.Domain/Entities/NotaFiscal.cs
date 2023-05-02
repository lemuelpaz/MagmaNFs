using Magma3.NotaFiscal.Domain.Entities.Base;
using Magma3.NotaFiscal.Domain.Enums;

namespace Magma3.NotaFiscal.Domain.Entities
{
    public class NotaFiscal : BaseEntity
    {
        public NotaFiscal() { }

        public NotaFiscal(string numeroNota, int clienteId, string chaveAcesso, DateTime dataEmissao)
        {
            NumeroNota = numeroNota;
            ClienteId = clienteId;
            ChaveAcesso = chaveAcesso;
            DataEmissao = dataEmissao;

            Produtos = new List<NotaFiscalProduto>();
            NotaFiscalStatus = NotaFiscalStatus.ATIVA;
        }

        public string NumeroNota { get; set; }
        public string ChaveAcesso { get; set; }
        public DateTime DataEmissao { get; set; }
        public NotaFiscalStatus NotaFiscalStatus { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public virtual List<NotaFiscalProduto> Produtos { get; set; }

        public void Excluir()
        {
            NotaFiscalStatus = NotaFiscalStatus.EXCLUIDA;
        }
    }
}