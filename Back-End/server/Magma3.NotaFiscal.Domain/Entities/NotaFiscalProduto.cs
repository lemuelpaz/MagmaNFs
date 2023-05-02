using Magma3.NotaFiscal.Domain.Entities.Base;

namespace Magma3.NotaFiscal.Domain.Entities
{
    public class NotaFiscalProduto : BaseEntity
    {
        public NotaFiscalProduto() { }

        public NotaFiscalProduto(int notaFiscalId, int produtoId, decimal produtoPreco, DateTime dataCompra)
        {
            NotaFiscalId = notaFiscalId;
            ProdutoId = produtoId;
            ProdutoPreco = produtoPreco;
            DataCompra = dataCompra;
        }
        
        public DateTime DataCompra { get; set; }
        public decimal ProdutoPreco { get; set; }
        public int NotaFiscalId { get; set; }
        public virtual NotaFiscal NotaFiscal { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}