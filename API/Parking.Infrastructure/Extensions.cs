using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Parking.Core.Interfaces;
using Parking.Core.Interfaces.Repositories;
using Parking.Infrastructure.Database.Raven;
using Parking.Infrastructure.Security;

namespace Parking.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCustomCors();

        services.AddControllers();
        services.AddHttpContextAccessor();
        
        services
            .AddSingleton<IParkingAreaRepository, DocumentParkingAreaRepository>()
            .AddSingleton<ITime, Time>();
        
        services.AddEndpointsApiExplorer();

        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseAuthentication();

        app.UseCors("DefaultAllow");
        
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }
}