using Magma3.NotaFiscal.Domain.Entities;

namespace Magma3.NotaFiscal.Domain.ValueObjects
{
    public class Contato
    {
        public Contato() { }

        public Contato(string celularNumero, int clienteId)
        {
            CelularNumero = celularNumero;
            ClienteId = clienteId;
        }

        public int Id { get; set; }
        public string CelularNumero { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Contato contato &&
                   Id == contato.Id &&
                   CelularNumero == contato.CelularNumero;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CelularNumero);
        }
    }
}