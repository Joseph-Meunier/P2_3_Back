using API.DbContext;
using API.Models;
using API.Repository;
using API.Repository.Contracts;
using API.Services;
using API.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API.AzureFunctions;

public class Program
{
    public static void Main(string[] args)
    {
        var host = new HostBuilder()
            .ConfigureFunctionsWorkerDefaults()
            .ConfigureServices((hostBuilder,services) =>
            {
        
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer( hostBuilder.Configuration.GetConnectionString("MyConnectionString")));
                

                services.AddScoped<IProfessionalEventService,ProfessionalEventService>();
                

                services.AddScoped<IProfessionalEventRepository, ProfessionalEventRepository>();


                services.AddLogging();

            })
            .Build();

        host.Run();
    }
}