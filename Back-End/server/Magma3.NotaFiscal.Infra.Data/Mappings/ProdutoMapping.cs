using Magma3.NotaFiscal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Magma3.NotaFiscal.Infra.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(e => e.Id)
                .IsClustered();

            builder.Property(e => e.Id)
                .HasColumnName("cod_produto")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.UId)
                .HasColumnName("uid_produto")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(e => e.Descricao)
                .HasColumnName("des_produto")
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(e => e.ProdutoPreco)
                .HasColumnName("preco_produto")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder
                .ToTable("tb_produto");

            builder.HasData(new List<Produto>()
            {
                new Produto()
                {
                    Id = 1,
                    Descricao = "Produto Teste 1",
                    ProdutoPreco = 99.99m
                },
                new Produto()
                {
                    Id = 2,
                    Descricao = "Produto Teste 2",
                    ProdutoPreco = 55.99m
                },
                new Produto()
                {
                    Id = 3,
                    Descricao = "Produto Teste 3",
                    ProdutoPreco = 88.00m
                }
            });
        }
    }
}