using CarCompaniesApplication.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CarCompaniesApplication.DAL;

/// <summary>
/// Контекст базы данных.
/// </summary>
public class DataContext : DbContext
{
    /// <summary>
    /// Компании-производители.
    /// </summary>
    public DbSet<CarCompany> CarCompanies { get; set; }

    /// <summary>
    /// Марки автомобилей.
    /// </summary>
    public DbSet<CarBrand> CarBrands { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarCompany>().HasKey(с => с.Id);
        modelBuilder.Entity<CarBrand>().HasKey(b => b.Id);
    }
}

