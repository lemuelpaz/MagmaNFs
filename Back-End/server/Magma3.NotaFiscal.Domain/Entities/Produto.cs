using Magma3.NotaFiscal.Domain.Entities.Base;

namespace Magma3.NotaFiscal.Domain.Entities
{
    public class Produto : BaseEntity
    {
        public Produto() { }

        public Produto(string descricao, decimal produtoPreco)
        {
            Descricao = descricao;
            ProdutoPreco = produtoPreco;
        }

        public string Descricao { get; set; }
        public decimal ProdutoPreco { get; set; }
    }
}