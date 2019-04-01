using dwa.domain.AggregatesModel.CatalogoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dwa.infra.data.EntityConfigurations
{
    class CatalogoTipoEntityTypeConfiguration
        : IEntityTypeConfiguration<CatalogoTipo>
    {
        public void Configure(EntityTypeBuilder<CatalogoTipo> builder)
        {
            builder.ToTable("CatalogoTipo");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .ForSqlServerUseSequenceHiLo("catalogo_tipo_hilo")
               .IsRequired();

            builder.Property(cb => cb.Tipo)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
