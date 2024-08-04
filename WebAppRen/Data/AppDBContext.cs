using Microsoft.EntityFrameworkCore;
using WebAppRen.Models;
using Microsoft.Data.SqlClient;

namespace WebAppRen.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Gender> tblM_gender { get; set; }
        public DbSet<Hobi> tblM_Hobi { get; set; }
        public DbSet<Personal> tblT_Personal { get; set; }
        public DbSet<Usia> tblT_Umur { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usia>()
                .HasNoKey()
                .ToTable("tblT_Umur");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "DefaultConnection";
                optionsBuilder.UseSqlServer(connectionString);

                // Test the connection
                using (var connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        Console.WriteLine("Connection successful.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Connection failed: {ex.Message}");
                    }
                }
            }
        }

    }
}
