using FluentValidation;

namespace Magma3.NotaFiscal.Application.Commands.RegistrarNotaFiscal
{
    public class RegistrarNotaFiscalCommandValidator : AbstractValidator<RegistrarNotaFiscalCommand>
    {
        public RegistrarNotaFiscalCommandValidator()
        {
            RuleFor(nf => nf.DataCompra)
                 .NotNull()
                 .WithMessage("A data da compra é obrigatória.")
                 .LessThanOrEqualTo(DateTime.Now)
                 .WithMessage("A data da compra não pode ser posterior à data atual.");

            RuleFor(c => c.Cliente)
                .SetValidator(new ClienteInputModelValidator());

            RuleFor(c => c.Cliente.Endereco)
                .SetValidator(new EnderecoInputModelValidator());

            RuleFor(c => c.Cliente.Contato)
                .SetValidator(new ContatoInputModelValidator());

            RuleFor(c => c.Produto)
                .SetValidator(new ProdutoInputModelValidator());

            RuleFor(c => c.NotaFiscal)
                .SetValidator(new NotaFiscalInputModelValidator());
        }
    }

    public class ClienteInputModelValidator : AbstractValidator<ClienteInputModel>
    {
        public ClienteInputModelValidator()
        {
            RuleFor(c => c.NomeCliente)
                .NotEmpty()
                .WithMessage("O nome do cliente é obrigatório.");
        }
    }

    public class EnderecoInputModelValidator : AbstractValidator<EnderecoInputModel>
    {
        public EnderecoInputModelValidator()
        {
            RuleFor(e => e.Cep)
                .NotEmpty()
                .WithMessage("O CEP é obrigatório.");

            RuleFor(e => e.UF)
                .NotEmpty()
                .WithMessage("A UF é obrigatória.");

            RuleFor(e => e.Cidade)
                .NotEmpty()
                .WithMessage("A cidade é obrigatória.");

            RuleFor(e => e.Bairro)
                .NotEmpty()
                .WithMessage("O bairro é obrigatório.");

            RuleFor(e => e.Logradouro)
                .NotEmpty()
                .WithMessage("O logradouro é obrigatório.");

            RuleFor(e => e.Numero)
                .NotEmpty()
                .WithMessage("O número é obrigatório.");
        }
    }

    public class ContatoInputModelValidator : AbstractValidator<ContatoInputModel>
    {
        public ContatoInputModelValidator()
        {
            RuleFor(c => c.CelularNumero)
                .NotEmpty()
                .WithMessage("O número do celular é obrigatório.");
        }
    }

    public class ProdutoInputModelValidator : AbstractValidator<ProdutoInputModel>
    {
        public ProdutoInputModelValidator()
        {
            RuleFor(p => p.Descricao)
                .NotEmpty()
                .WithMessage("A descrição do produto é obrigatória.");

            RuleFor(p => p.ProdutoPreco)
                .GreaterThan(0)
                .WithMessage("O preço do produto deve ser maior que zero.");
        }
    }

    public class NotaFiscalInputModelValidator : AbstractValidator<NotaFiscalInputModel>
    {
        public NotaFiscalInputModelValidator()
        {

            RuleFor(nf => nf.NumeroNota)
               .NotEmpty()
               .WithMessage("O número da nota fiscal é obrigatório.");

            RuleFor(nf => nf.ChaveAcesso)
                .NotEmpty()
                .WithMessage("A chave de acesso da nota fiscal é obrigatória.");

            RuleFor(nf => nf.DataEmissao)
                .NotNull()
                .WithMessage("A data de emissão da nota fiscal é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("A data de emissão da nota fiscal não pode ser posterior à data atual.");
        }
    }
}