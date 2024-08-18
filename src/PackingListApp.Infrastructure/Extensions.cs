using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackingListApp.Infrastructure.EF.Contexts;
using PackingListApp.Shared.Queries;

namespace PackingListApp.Infrastructure;
public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddQueries();

        services.AddDbContext<ReadDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
        services.AddDbContext<WriteDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
        
        return services;
    }
}
