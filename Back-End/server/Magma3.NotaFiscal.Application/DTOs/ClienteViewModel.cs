using Magma3.NotaFiscal.Domain.Entities;

namespace Magma3.NotaFiscal.Application.DTOs
{
    public class ClienteViewModel
    {
        public ClienteViewModel(Guid clienteUId, string nomeCliente, ContatoViewModel contato, EnderecoViewModel endereco)
        {
            ClienteUId = clienteUId;
            NomeCliente = nomeCliente;
            Contato = contato;
            Endereco = endereco;
        }

        public Guid ClienteUId { get; set; }
        public string NomeCliente { get; set; }
        public ContatoViewModel Contato { get; set; }
        public EnderecoViewModel Endereco { get; set; }

        public static ClienteViewModel FromEntity(Cliente cliente)
        {
            var contato = ContatoViewModel.FromEntity(cliente);

            var endereco = EnderecoViewModel.FromEntity(cliente);

            return new ClienteViewModel(cliente.UId, cliente.NomeCliente, contato, endereco);
        }

        public class ContatoViewModel
        {
            public ContatoViewModel(string celularNumero)
            {
                CelularNumero = celularNumero;
            }

            public string CelularNumero { get; set; }

            public static ContatoViewModel FromEntity(Cliente cliente)
            {
                return new ContatoViewModel(cliente.Contato.CelularNumero);
            }
        }

        public class EnderecoViewModel
        {
            public EnderecoViewModel(string cep, string uf, string cidade, string bairro, string logradouro, string numero)
            {
                Cep = cep;
                UF = uf;
                Cidade = cidade;
                Bairro = bairro;
                Logradouro = logradouro;
                Numero = numero;
            }

            public string Cep { get; set; }
            public string UF { get; set; }
            public string Cidade { get; set; }
            public string Bairro { get; set; }
            public string Logradouro { get; set; }
            public string Numero { get; set; }

            public static EnderecoViewModel FromEntity(Cliente cl)
            {
                return new EnderecoViewModel(
                    cl.Endereco.Cep,
                    cl.Endereco.UF,
                    cl.Endereco.Cidade,
                    cl.Endereco.Bairro,
                    cl.Endereco.Logradouro,
                    cl.Endereco.Numero);
            }
        }
    }    
}