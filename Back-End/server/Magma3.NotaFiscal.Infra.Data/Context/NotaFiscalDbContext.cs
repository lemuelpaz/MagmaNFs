using Magma3.NotaFiscal.Domain.Entities;
using Magma3.NotaFiscal.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Magma3.NotaFiscal.Infra.Data.Context
{
    public class NotaFiscalDbContext : DbContext
    {
        public NotaFiscalDbContext(DbContextOptions<NotaFiscalDbContext> options) : base(options) { }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Domain.Entities.NotaFiscal> NotasFiscais { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<NotaFiscalProduto> NotasFiscaisProdutos { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Contato> Contatos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}