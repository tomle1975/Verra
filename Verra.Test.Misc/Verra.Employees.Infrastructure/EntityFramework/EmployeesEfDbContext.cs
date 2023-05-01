using Microsoft.EntityFrameworkCore;
using Verra.Employees.Infrastructure.EntityFramework.Tables;

namespace Verra.Employees.Infrastructure.EntityFramework;

public class EmployeesEfDbContext : DbContext
{
    public DbSet<Employee>? Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureAddressTable(modelBuilder);
    }

    private static void ConfigureAddressTable(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasKey(a => a.EmpId);

        modelBuilder.Entity<Employee>().Property(a => a.FirstName).HasMaxLength(15);
        modelBuilder.Entity<Employee>().Property(a => a.LastName).HasMaxLength(15);
    }
}