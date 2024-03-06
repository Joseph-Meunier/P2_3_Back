using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using static System.Net.Mime.MediaTypeNames;

namespace API.DbContext;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer("Server = localhost; Database=BddPourLeControle; Trusted_Connection = True; Trust Server Certificate = True");

        return new AppDbContext(optionsBuilder.Options);
    }
}