namespace Magma3.NotaFiscal.Application.DTOs
{
    public class NotaFiscalViewModel
    {
        public NotaFiscalViewModel(Guid notaUId, string numeroNota, ClienteViewModel cliente, string chaveAcesso, DateTime dataEmissao, List<NotaFiscalProdutoViewModel> produtos)
        {
            NotaFiscalUId = notaUId;
            NumeroNota = numeroNota;
            Cliente = cliente;
            ChaveAcesso = chaveAcesso;
            DataEmissao = dataEmissao;
            ProdutosNotaFiscal = new List<NotaFiscalProdutoViewModel>(produtos);
        }

        public Guid NotaFiscalUId { get; set; }
        public string NumeroNota { get; set; }
        public string ChaveAcesso { get; set; }
        public DateTime DataEmissao { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public List<NotaFiscalProdutoViewModel> ProdutosNotaFiscal { get; set; }

        public static NotaFiscalViewModel FromEntity(Domain.Entities.NotaFiscal nf)
        {
            var cliente = ClienteViewModel.FromEntity(nf.Cliente);

            var produtos = nf.Produtos
                .Select(x => NotaFiscalProdutoViewModel.FromEntity(x))
                .ToList();

            return new NotaFiscalViewModel(
                nf.UId,
                nf.NumeroNota,
                cliente,
                nf.ChaveAcesso,
                nf.DataEmissao,
                produtos);
        }
    }
}