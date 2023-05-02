using Magma3.NotaFiscal.Domain.Entities;

namespace Magma3.NotaFiscal.Domain.ValueObjects
{
    public class Endereco
    {
        public Endereco() { }

        public Endereco(string cep, string uf, string cidade, string bairro, string logradouro, string numero, int clienteId)
        {
            Cep = cep;
            UF = uf;
            Cidade = cidade;
            Bairro = bairro;
            Logradouro = logradouro;
            Numero = numero;
            ClienteId = clienteId;
        }

        public int Id { get; set; }
        public string Cep { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Endereco endereco &&
                   Cep == endereco.Cep &&
                   UF == endereco.UF &&
                   Cidade == endereco.Cidade &&
                   Bairro == endereco.Bairro &&
                   Logradouro == endereco.Logradouro &&
                   Numero == endereco.Numero;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Cep, UF, Cidade, Bairro, Logradouro, Numero);
        }
    }
}