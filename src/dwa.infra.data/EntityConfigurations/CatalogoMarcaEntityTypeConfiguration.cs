using dwa.domain.AggregatesModel.CatalogoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dwa.infra.data.EntityConfigurations
{
    class CatalogoMarcaEntityTypeConfiguration
        : IEntityTypeConfiguration<CatalogoMarca>
    {
        public void Configure(EntityTypeBuilder<CatalogoMarca> builder)
        {
            builder.ToTable("CatalogoMarca");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("catalog_marca_hilo")
               .IsRequired();

            builder.Property(cb => cb.Marca)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
