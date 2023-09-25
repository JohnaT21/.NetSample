using System.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestProject.Data.DbModel.AccountSchema;
using TestProject.Data.DbModel.ConfigurationSchema;

namespace TestProject.Data.DataContext;

public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid,
    ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
    ApplicationRoleClaim, ApplicationUserToken>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //SeedData


        modelBuilder.Entity<RoleMenuPermission>(b =>
        {
            b.HasKey(b=> new { b.Id});
        });
        // set application user relations
        modelBuilder.Entity<ApplicationUser>(b =>
        {
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

            // Each User can have organization unit
           

        });
        // set application role relations
        modelBuilder.Entity<ApplicationRole>(b =>
        {
            // set application role primary key
            // b.HasKey(u => u.Id);
            // Each Role can have many associated RoleClaims
            b.HasMany(e => e.RoleClaims)
                .WithOne(e => e.Role)
                .HasForeignKey(rc => rc.RoleId)
                .IsRequired();


            // Each User can have many entries in the UserRole join table
            b.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(rc => rc.RoleId)
                .IsRequired();

        });

        // set application user role primary key
        // modelBuilder.Entity<ApplicationUserRole>(b =>
        // {
        //     b.HasKey(u => u.Id);
        // });

        // Update Identity Schema
        modelBuilder.Entity<ApplicationUser>().ToTable("users", "account");
        modelBuilder.Entity<ApplicationRole>().ToTable("roles", "account");
        modelBuilder.Entity<ApplicationUserRole>().ToTable("user_roles", "account");
        modelBuilder.Entity<ApplicationUserLogin>().ToTable("user_logins", "account");
        modelBuilder.Entity<ApplicationUserClaim>().ToTable("user_claims", "account");
        modelBuilder.Entity<ApplicationUserToken>().ToTable("user_tokens", "account");
        modelBuilder.Entity<ApplicationRoleClaim>().ToTable("role_claims", "account");
        modelBuilder.Entity<RoleMenuPermission>().ToTable("role_menu_permissions", "account");
        modelBuilder.Entity<Permission>().ToTable("permissions", "account");

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        foreach (Microsoft.EntityFrameworkCore.Metadata.IMutableProperty property in modelBuilder.Model.GetEntityTypes()
                       .SelectMany(t => t.GetProperties())
                       .Where(p => p.ClrType == typeof(decimal)))
        {
            property.SetDefaultValue(0);
            property.SetColumnType("decimal(18, 4)");
        }

        foreach (var property in modelBuilder.Model.GetEntityTypes()
                                .SelectMany(t => t.GetProperties())
                                .Where(p => p.ClrType == typeof(bool)))
        {
            property.SetDefaultValue(false);
        }

    }

    public DbSet<UserPreference> UserPreferences { get; set; }

    #region Configration
    // public DbSet<Configuration> Configurations { get; set; }
    // public DbSet<Menu> Menus { get; set; }
    // public DbSet<MenuRole> MenuRoles { get; set; }
    // public DbSet<MenuPlan> MenuPlans { get; set; }
    #endregion
    

    public IDbConnection Connection { get; }
}
