using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents;

namespace Parking.Infrastructure.Database.Raven;

internal static class Extensions
{
    public static IServiceCollection AddRaven(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IDocumentStore>(provider =>
        {
            var store = DocumentStoreHolder.Store;
            return store;
        });
        
        return services;
    }
}