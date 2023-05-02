

using Magma3.NotaFiscal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Magma3.NotaFiscal.Infra.Data.Mappings
{
    public class NotaFiscalProdutoMapping : IEntityTypeConfiguration<NotaFiscalProduto>
    {
        public void Configure(EntityTypeBuilder<NotaFiscalProduto> builder)
        {
            builder.HasKey(e => e.Id)
                .IsClustered();

            builder.Property(e => e.Id)
                .HasColumnName("cod_nota_fiscal_produto")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.UId)
                .HasColumnName("uid_nota_fiscal_produto")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(e => e.NotaFiscalId)
                .HasColumnName("fk_nota_fiscal")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.ProdutoId)
                .HasColumnName("fk_produto")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.DataCompra)
                .HasColumnName("data_compra_produto")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(e => e.ProdutoPreco)
                .HasColumnName("preco_produto")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder
                .HasOne(e => e.NotaFiscal)
                .WithMany(e => e.Produtos)
                .HasForeignKey(e => e.NotaFiscalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Produto)
                .WithMany()
                .HasForeignKey(e => e.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("tb_nota_fiscal_produto");

            builder.HasData(new List<NotaFiscalProduto>()
            {
                new NotaFiscalProduto()
                {
                    Id = 1,
                    DataCompra = DateTime.Now,
                    NotaFiscalId = 1,
                    ProdutoId = 1,
                    ProdutoPreco = 99.99m
                },
                new NotaFiscalProduto()
                {
                    Id = 2,
                    DataCompra = DateTime.Now,
                    NotaFiscalId = 2,
                    ProdutoId = 2,
                    ProdutoPreco = 55.99m
                },
                new NotaFiscalProduto()
                {
                    Id = 3,
                    DataCompra = DateTime.Now,
                    NotaFiscalId = 3,
                    ProdutoId = 3,
                    ProdutoPreco = 88.00m
                }
            });
        }
    }
}