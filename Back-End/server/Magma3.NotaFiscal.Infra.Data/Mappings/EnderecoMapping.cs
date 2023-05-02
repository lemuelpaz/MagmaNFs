using Magma3.NotaFiscal.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Magma3.NotaFiscal.Infra.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id)
                .IsClustered();

            builder.Property(e => e.Id)
                .HasColumnName("cod_endereco")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.ClienteId)
               .HasColumnName("fk_cod_cliente")
               .IsRequired();

            builder.Property(e => e.Cep)
               .HasColumnName("cep")
               .HasColumnType("varchar(20)")
               .IsRequired();

            builder.Property(e => e.UF)
               .HasColumnName("uf")
               .HasColumnType("char(2)")
               .IsRequired();

            builder.Property(e => e.Cidade)
               .HasColumnName("cidade")
               .HasColumnType("varchar(70)")
               .IsRequired();

            builder.Property(e => e.Bairro)
               .HasColumnName("bairro")
               .HasColumnType("varchar(70)")
               .IsRequired();

            builder.Property(e => e.Logradouro)
               .HasColumnName("logradouro")
               .HasColumnType("varchar(200)")
               .IsRequired();

            builder.Property(e => e.Numero)
               .HasColumnName("endereco_numero")
               .HasColumnType("varchar(10)")
               .IsRequired();

            builder
                .ToTable("tb_endereco");

            builder.HasData(new List<Endereco>()
            {
                 new Endereco()
                 {
                     Id = 1,
                     Cep = "900200004",
                     UF = "RS",
                     Cidade = "PORTO ALEGRE",
                     Bairro = "Centro Histórico",
                     Logradouro = "Rua dos Andradas",
                     Numero = "771",
                     ClienteId = 1
                 },
                 new Endereco()
                 {
                     Id = 2,
                     Cep = "900200004",
                     UF = "RS",
                     Cidade = "PORTO ALEGRE",
                     Bairro = "Centro Histórico",
                     Logradouro = "Rua dos Andradas",
                     Numero = "234",
                     ClienteId = 2
                 },
                 new Endereco()
                 {
                     Id = 3,
                     Cep = "900200004",
                     UF = "RS",
                     Cidade = "PORTO ALEGRE",
                     Bairro = "Centro Histórico",
                     Logradouro = "Rua dos Andradas",
                     Numero = "534",
                     ClienteId = 3
                 }
            });
        }
    }
}