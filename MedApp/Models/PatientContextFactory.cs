using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using MedApp.Models;


public class PatientContextFactory : IDesignTimeDbContextFactory<PatientContext>
{
    public PatientContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<PatientContext>();
        var connectionString = configuration.GetConnectionString("DbConn");
        builder.UseSqlServer(connectionString);

        return new PatientContext(builder.Options);
    }
}
