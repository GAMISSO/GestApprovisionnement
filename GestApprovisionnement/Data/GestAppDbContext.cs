using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class GestAppDbContext: DbContext
    {
        public DbSet<Approvisionnement> Approvisionnements { get; set; }=null!;
        public DbSet<Article> Articles { get; set; }=null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
            "Server=localhost;Port=3306;Database=GestAppDb;User=root;Password=;",
                new MySqlServerVersion(new Version(5, 7, 39)) // Spécifiez votre version MySQL
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Approvisionnement>().ToTable("Approvisionnements");
            modelBuilder.Entity<Approvisionnement>().HasKey(d => d.Id);
            modelBuilder.Entity<Approvisionnement>()
            .Property(d => d.Référence)
            .IsRequired().
            HasMaxLength(50);
            // Configuration supplémentaire si nécessaire
        }
    }
}