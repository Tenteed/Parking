using Microsoft.Extensions.DependencyInjection;

namespace Parking.Infrastructure.Security;

public static class Extensions
{
    public static IServiceCollection AddCustomCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: "DefaultAllow",
                policy  =>
                {
                    policy.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();
                });
        });
        
        return services;
    }
}