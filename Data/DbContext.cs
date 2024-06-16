using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using UserApi.Models;

namespace UserApi.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataBaseContext>
{
    public DataBaseContext CreateDbContext(string[] args) {
        // Créez une configuration pour lire appsettings.json
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        // Récupérez la chaîne de connexion
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new DataBaseContext(optionsBuilder.Options);
    }
}

public class DataBaseContext : DbContext 
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) {}

    public DbSet<User> Users { get; set; } = null!;
}