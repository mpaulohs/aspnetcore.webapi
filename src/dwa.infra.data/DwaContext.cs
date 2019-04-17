using dwa.domain.AggregatesModel.CarrinhoAggregate;
using dwa.domain.AggregatesModel.CatalogoAggregate;
using dwa.domain.AggregatesModel.OrdemAggregate;
using dwa.domain.AggregatesModel.UsuarioAggregate;
using dwa.infra.data.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dwa.infra.data
{
    public class DwaContext : IdentityDbContext<User, Role, string, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {      
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<CatalogoItem> CatalogoItens { get; set; }
        public DbSet<CatalogoMarca> CatalogoMarcas { get; set; }
        public DbSet<CatalogoTipo> CatalogoTipos { get; set; }
        public DbSet<Ordem> Ordens { get; set; }
        public DbSet<OrdemItem> OrderItens { get; set; }

        public DwaContext(DbContextOptions<DwaContext> options)
           : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Carrinho>(ConfigureCarrinho);
            modelBuilder.Entity<Ordem>(ConfigureOrdem);
            modelBuilder.Entity<OrdemItem>(ConfigureOrdemItem);
            modelBuilder.Entity<Endereco>(ConfigureEndereco);
            modelBuilder.Entity<CatalogoItemOrdem>(ConfigurateCatalogoItemOrdem);


            modelBuilder.ApplyConfiguration(new CatalogoMarcaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogoTipoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogoItemEntityTypeConfiguration());

            modelBuilder.Entity<User>(b =>
            {
                b.ToTable("Core_Users");
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<Role>(b =>
            {
                b.ToTable("Core_Roles");
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });

            modelBuilder.Entity<UserClaim>(b =>
            {
                b.ToTable("Core_UserClaims");
            });

            modelBuilder.Entity<UserLogin>(b =>
            {
                b.ToTable("Core_UserLogins");
            });

            modelBuilder.Entity<UserToken>(b =>
            {
                b.ToTable("Core_UserTokens");
            });

            modelBuilder.Entity<RoleClaim>(b =>
            {
                b.ToTable("Core_RoleClaims");
            });

            modelBuilder.Entity<UserRole>(b =>
            {
                b.ToTable("Core_UserRoles");
            });

        }
        private void ConfigurateCatalogoItemOrdem(EntityTypeBuilder<CatalogoItemOrdem> builder)
        {
            builder.Property(cio => cio.ProdutoNome)
                .HasMaxLength(50)
                .IsRequired();
        }
        private void ConfigureEndereco(EntityTypeBuilder<Endereco> builder)
        {
            builder.Property(a => a.Cep)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.Rua)
                .HasMaxLength(180)
                .IsRequired();

            builder.Property(a => a.Estado)
                .HasMaxLength(60);

            builder.Property(a => a.Pais)
                .HasMaxLength(90)
                .IsRequired();

            builder.Property(a => a.Cidade)
                .HasMaxLength(100)
                .IsRequired();
        }
        private void ConfigureCarrinho(EntityTypeBuilder<Carrinho> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Carrinho.Items));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
        private void ConfigureOrdem(EntityTypeBuilder<Ordem> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Ordem.OrderItems));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.OwnsOne(o => o.EnderecoParaEntrega);
        }
        private void ConfigureOrdemItem(EntityTypeBuilder<OrdemItem> builder)
        {
            builder.OwnsOne(i => i.CatalogoItemOrdem);
        }
    }
}
