using Magma3.NotaFiscal.Domain.Entities.Base;
using Magma3.NotaFiscal.Domain.ValueObjects;

namespace Magma3.NotaFiscal.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente() { }

        public Cliente(string nomeCliente)
        {
            NomeCliente = nomeCliente;

            NotaFiscais = new List<NotaFiscal>();
        }

        public string NomeCliente { get; set; }

        public virtual Endereco Endereco { get; set; }
        public virtual Contato Contato { get; set; }
        public virtual List<NotaFiscal> NotaFiscais { get; set; }
    }
}