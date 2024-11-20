#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        // Déclaration des DbSet pour chaque modèle
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Savings> Savings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration des modèles si nécessaire
            modelBuilder.Entity<Salary>().ToTable("Salaries");
            modelBuilder.Entity<Expense>().ToTable("Expenses");
            modelBuilder.Entity<Savings>().ToTable("Savings");

            base.OnModelCreating(modelBuilder);
        }
    }
}
