using Magma3.NotaFiscal.Application.Mediator.Message;
using Magma3.NotaFiscal.Domain.Entities;
using Magma3.NotaFiscal.Domain.ValueObjects;

namespace Magma3.NotaFiscal.Application.Commands.RegistrarNotaFiscal
{
    public class RegistrarNotaFiscalCommand : Command
    {
        public DateTime DataCompra { get; set; }
        public NotaFiscalInputModel NotaFiscal { get; set; }
        public ClienteInputModel Cliente { get; set; }        
        public ProdutoInputModel Produto { get; set; }
    }
    public class NotaFiscalInputModel
    {
        public Guid NotaFiscalUId { get; private set; }
        public string NumeroNota { get; set; }
        public string ChaveAcesso { get; set; }
        public DateTime DataEmissao { get; set; }

        public void SetNotaFiscalUId(Guid notaFiscalUId) => NotaFiscalUId = notaFiscalUId;

        public Domain.Entities.NotaFiscal ToEntity(int clienteId)
        {
            return new Domain.Entities.NotaFiscal(NumeroNota, clienteId, ChaveAcesso, DataEmissao);
        }
    }

    public class ProdutoInputModel
    {
        public string Descricao { get; set; }
        public decimal ProdutoPreco { get; set; }

        public Produto ToEntity()
        {
            return new Produto(Descricao, ProdutoPreco);
        }
    }    

    public class ClienteInputModel
    {
        public string NomeCliente { get; set; }
        public EnderecoInputModel Endereco { get; set; }
        public ContatoInputModel Contato { get; set; }

        public Cliente ToEntity()
        {
            return new Cliente(NomeCliente);
        }
    }

    public class EnderecoInputModel
    {
        public string Cep { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }

        public Endereco ToEntity(int clienteId)
        {
            return new Endereco(Cep, UF, Cidade, Bairro, Logradouro, Numero, clienteId);
        }
    }

    public class ContatoInputModel
    {
        public string CelularNumero { get; set; }

        public Contato ToEntity(int clienteId)
        {
            return new Contato(CelularNumero, clienteId);
        }
    }
}