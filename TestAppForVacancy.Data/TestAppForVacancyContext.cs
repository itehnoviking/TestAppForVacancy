using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Xml.Linq;
using TestAppForVacancy.Data.Entities;

namespace TestAppForVacancy.Data;

public class TestAppForVacancyContext : DbContext
{
    private readonly IConfiguration _configuration;

    public TestAppForVacancyContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;

    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Provider> Providers { get; set; }
}