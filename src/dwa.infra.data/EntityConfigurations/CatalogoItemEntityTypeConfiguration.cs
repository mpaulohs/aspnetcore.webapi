using dwa.domain.AggregatesModel.CatalogoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dwa.infra.data.EntityConfigurations
{
    class CatalogoItemEntityTypeConfiguration
        : IEntityTypeConfiguration<CatalogoItem>
    {
        public void Configure(EntityTypeBuilder<CatalogoItem> builder)
        {
            builder.ToTable("Catalogo");

            builder.Property(ci => ci.Id)
                .ForSqlServerUseSequenceHiLo("catalog_hilo")
                .IsRequired();

            builder.Property(ci => ci.Nome)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(ci => ci.Preco)
                .IsRequired(true);

            builder.Property(ci => ci.ImagemFileName)
                .IsRequired(false);

            builder.Ignore(ci => ci.ImagemUri);

            builder.HasOne(ci => ci.CatalogoMarca)
                .WithMany()
                .HasForeignKey(ci => ci.CatalogoMarcaId);

            builder.HasOne(ci => ci.CatalogoTipo)
                .WithMany()
                .HasForeignKey(ci => ci.CatalogoTipoId);
        }
    }
}
