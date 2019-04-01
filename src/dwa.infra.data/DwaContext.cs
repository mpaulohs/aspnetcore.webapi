using dwa.domain.AggregatesModel.CatalogoAggregate;
using dwa.domain.AggregatesModel.UsuarioAggregate;
using dwa.infra.data.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dwa.infra.data
{
    public class DwaContext : IdentityDbContext<User, Role, string, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbSet<CatalogoItem> CatalogoItens { get; set; }
        public DbSet<CatalogoMarca> CatalogoMarcas { get; set; }
        public DbSet<CatalogoTipo> CatalogoTipos { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        public DwaContext(DbContextOptions<DwaContext> options)
           : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
    }
}
