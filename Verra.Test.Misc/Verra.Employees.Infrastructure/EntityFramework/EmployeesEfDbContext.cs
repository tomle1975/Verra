using Microsoft.EntityFrameworkCore;
using Verra.Employees.Infrastructure.EntityFramework.Tables;

namespace Verra.Employees.Infrastructure.EntityFramework;

public class EmployeesEfDbContext : DbContext
{
    /// <summary>
    /// Gets or sets all employees.
    /// </summary>
    public DbSet<Employee>? Employees { get; set; }

    /// <summary>
    /// Gets or sets all positions.
    /// </summary>
    public DbSet<EmployeePosition>? Positions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // TODO: Need this to be configurable.
        optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Employees;Trusted_Connection=Yes;Encrypt=false");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureAddressTable(modelBuilder);
    }

    private static void ConfigureAddressTable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasKey(e => e.Id);
        modelBuilder.Entity<Employee>().Property(e => e.FirstName).HasMaxLength(15);
        modelBuilder.Entity<Employee>().Property(e => e.LastName).HasMaxLength(15);
        modelBuilder.Entity<Employee>().HasMany(e => e.Positions).WithOne(e => e.Employee).IsRequired();
        // TODO: Define other database constraints for the rest of employee data attributes.

        modelBuilder.Entity<EmployeePosition>().HasKey(p => p.Id);
        modelBuilder.Entity<EmployeePosition>()
            .HasOne(p => p.Employee)
            .WithMany(p => p.Positions)
            .IsRequired()
            .HasForeignKey(p => p.EmployeeId);
        // TODO: Define other database constraints for EmployeePosition.
    }
}