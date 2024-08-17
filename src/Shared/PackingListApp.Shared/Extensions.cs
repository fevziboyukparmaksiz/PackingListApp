using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using PackingListApp.Shared.Abstractions.Commands;
using PackingListApp.Shared.Commands;

namespace PackingListApp.Shared;
public static class Extensions
{
    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        var assembly = Assembly.GetCallingAssembly();

        services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();
        //Automatic Registration with Scrutor
        services.Scan(s => s.FromAssemblies(assembly)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
