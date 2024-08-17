using Microsoft.Extensions.DependencyInjection;
using PackingListApp.Domain.Factories;
using PackingListApp.Domain.Policies;
using PackingListApp.Shared;

namespace PackingListApp.Application;
public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCommands();
        services.AddSingleton<IPackingListFactory, PackingListFactory>();

        //Auto registration Policies with Scrutor
        services.Scan(s => s.FromAssemblies(typeof(IPackingItemsPolicy).Assembly)
            .AddClasses(c => c.AssignableTo<IPackingItemsPolicy>())
            .AsImplementedInterfaces()
            .WithSingletonLifetime());

        return services;
    }
}
