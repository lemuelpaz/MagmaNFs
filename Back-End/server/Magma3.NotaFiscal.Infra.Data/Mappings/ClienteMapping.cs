using Magma3.NotaFiscal.Domain.Entities;
using Magma3.NotaFiscal.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Magma3.NotaFiscal.Infra.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(e => e.Id)
                .IsClustered();

            builder.Property(e => e.Id)
                .HasColumnName("cod_cliente")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.UId)
                .HasColumnName("uid_cliente")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(e => e.NomeCliente)
                .HasColumnName("nome_cliente")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder
                .HasOne(e => e.Endereco)
                .WithOne(e => e.Cliente)
                .HasForeignKey<Endereco>(e => e.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Contato)
                .WithOne(e => e.Cliente)
                .HasForeignKey<Contato>(e => e.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("tb_cliente");

            builder.HasData(new List<Cliente>() 
            {
                new Cliente() { Id = 1, NomeCliente = "Cliente 1" },
                new Cliente() { Id = 2, NomeCliente = "Cliente 2" },
                new Cliente() { Id = 3, NomeCliente = "Cliente 3" }
            });
        }
    }
}