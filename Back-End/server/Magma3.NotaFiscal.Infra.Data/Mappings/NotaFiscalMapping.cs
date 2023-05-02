using Magma3.NotaFiscal.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Magma3.NotaFiscal.Infra.Data.Mappings
{
    public class NotaFiscalMapping : IEntityTypeConfiguration<Domain.Entities.NotaFiscal>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.NotaFiscal> builder)
        {
            builder.HasKey(e => e.Id)
                .IsClustered();

            builder.Property(e => e.Id)
                .HasColumnName("cod_nota_fiscal")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.UId)
                .HasColumnName("uid_nota_fiscal")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            builder.Property(e => e.ClienteId)
               .HasColumnName("fk_cod_cliente")
               .IsRequired();

            builder.Property(e => e.NumeroNota)
                .HasColumnName("numero_nota_fiscal")
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(e => e.ChaveAcesso)
                .HasColumnName("chave_acesso_nota_fiscal")
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(e => e.NotaFiscalStatus)
                .HasConversion(
                    x => x.ToString(), 
                    x => (NotaFiscalStatus)Enum.Parse(typeof(NotaFiscalStatus), x));

            builder.Property(e => e.DataEmissao)
                .HasColumnName("data_emissao_nota_fiscal")
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .HasOne(e => e.Cliente)
                .WithMany(e => e.NotaFiscais)
                .HasForeignKey(e => e.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .ToTable("tb_nota_fiscal");

            builder.HasData(new List<Domain.Entities.NotaFiscal>()
            {
                new Domain.Entities.NotaFiscal()
                {
                    Id = 1,
                    DataEmissao = DateTime.Now,
                    NumeroNota = "12346578415",
                    ClienteId = 1,
                    ChaveAcesso = "84815641816",
                    NotaFiscalStatus = NotaFiscalStatus.ATIVA
                },
                new Domain.Entities.NotaFiscal()
                {
                    Id = 2,
                    DataEmissao = DateTime.Now,
                    NumeroNota = "12346578415",
                    ClienteId = 2,
                    ChaveAcesso = "32433241816",
                    NotaFiscalStatus = NotaFiscalStatus.ATIVA
                },
                new Domain.Entities.NotaFiscal()
                {
                    Id = 3,
                    DataEmissao = DateTime.Now,
                    NumeroNota = "12341231231",
                    ClienteId = 3,
                    ChaveAcesso = "67545634636",
                    NotaFiscalStatus = NotaFiscalStatus.ATIVA
                }
            });
        }
    }
}