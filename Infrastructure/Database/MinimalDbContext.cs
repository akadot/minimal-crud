using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Infrastructure.Database;

public class MinmalDbContext : DbContext
{
    private readonly IConfiguration _configurationAppSettings;

    public MinmalDbContext(IConfiguration configuration)
    {
        _configurationAppSettings = configuration;
    }

    public DbSet<Administrator> Administrators { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured){
            var connectionString = _configurationAppSettings.GetConnectionString("mysql")?.ToString();

            if(!string.IsNullOrEmpty(connectionString)){
                optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString));
            }
        }
    }
}
