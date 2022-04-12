using Domain.Common;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        InfrastructureDIOptions infraOptions)
    {
        // DB
        services.AddDbContext<OrderDbContext>(options =>
        {
            if (infraOptions.UseInMemDb)
            {
                options.UseInMemoryDatabase("TestDB");
            }
            else
            {
                if (infraOptions.ConnectionString is null)
                {
                    throw new ArgumentNullException("Connection String is null");
                } 
                
                options.UseSqlServer(infraOptions.ConnectionString, builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            }
        });
        
        // Repositories
        services.AddScoped<IOrderRepository, OrderRepository>();
        
        return services;
    }
}

public class InfrastructureDIOptions
{
    public bool UseInMemDb { get; set; }
    public string? ConnectionString { get; set; }
}