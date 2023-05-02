using Magma3.NotaFiscal.Domain.Entities;

namespace Magma3.NotaFiscal.Application.DTOs
{
    public class NotaFiscalProdutoViewModel
    {
        public NotaFiscalProdutoViewModel(int produtoId, string produtoDescricao, decimal produtoPrecoNotaFiscal, DateTime dataCompra)
        {
            ProdutoId = produtoId;
            ProdutoDescricao = produtoDescricao;
            ProdutoPrecoNotaFiscal = produtoPrecoNotaFiscal;
            DataCompra = dataCompra;
        }

        public int ProdutoId { get; set; }
        public string ProdutoDescricao { get; set; }
        public decimal ProdutoPrecoNotaFiscal { get; set; }
        public DateTime DataCompra { get; set; }

        public static NotaFiscalProdutoViewModel FromEntity(NotaFiscalProduto nf)
        {
            return new NotaFiscalProdutoViewModel(nf.ProdutoId, nf.Produto.Descricao, nf.ProdutoPreco, nf.DataCompra);
        }
    }
}