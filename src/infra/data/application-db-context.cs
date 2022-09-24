using Flunt.Notifications;
using iwantapp.domain.products;
using Microsoft.EntityFrameworkCore;

namespace iwantapp.infra.data;

public class ApplicationDbContext : DbContext {
    public DbSet<Product> products { get; set; }
    public DbSet<Category> categories { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) {}

    protected override void OnModelCreating(ModelBuilder builder) {
        // necessário para o Flunt.Notifications validar os DTO's
        builder.Ignore<Notification>();

        builder.Entity<Product>().Property(p => p.name).IsRequired();
        builder.Entity<Product>().Property(p => p.description).HasMaxLength(255).IsRequired(false);
        
        builder.Entity<Category>().Property(c => c.name).IsRequired();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration) {
        /* 
            equivalente ao builder.Entity<Product>().Property(p => p.description).HasMaxLength(500),
            porém é aplicado a todas as propriedades do tipo string em todas as entidades.
        */
        configuration.Properties<string>().HaveMaxLength(100);
    }
}