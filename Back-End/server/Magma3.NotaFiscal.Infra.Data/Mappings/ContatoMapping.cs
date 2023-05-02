using Magma3.NotaFiscal.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Magma3.NotaFiscal.Infra.Data.Mappings
{
    public class ContatoMapping : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(e => e.Id)
                .IsClustered();

            builder.Property(e => e.Id)
                .HasColumnName("cod_contato")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.ClienteId)
               .HasColumnName("fk_cod_cliente")
               .IsRequired();

            builder.Property(e => e.CelularNumero)
               .HasColumnName("celular_numero")
               .HasColumnType("varchar(20)")
               .IsRequired();            

            builder
                .ToTable("tb_contato");

            builder.HasData(new List<Contato>()
            {
                new Contato() { Id = 1, CelularNumero = "51998915689", ClienteId = 1},
                new Contato() { Id = 2, CelularNumero = "51995674356", ClienteId = 2},
                new Contato() { Id = 3, CelularNumero = "51876785678", ClienteId = 3}
            });
        }
    }
}