using Microsoft.Extensions.DependencyInjection;
using PackingListApp.Shared.Abstractions.Queries;
using System.Reflection;

namespace PackingListApp.Shared.Queries;
public static class Extensions
{
    public static IServiceCollection AddQueries(this IServiceCollection services)
    {
        var assembly = Assembly.GetCallingAssembly();

        services.AddSingleton<IQueryDispatcher, InMemoryQueryDispatcher>();
        //Automatic Registration with Scrutor
        services.Scan(s => s.FromAssemblies(assembly)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
