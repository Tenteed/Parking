using Parking.Application;
using Parking.Core;
using Parking.Infrastructure;
using Serilog;

namespace Parking;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services
            .AddCore()
            .AddApplication()
            .AddInfrastructure(builder.Configuration);
        
        var app = builder.Build();
        app.UseInfrastructure();
        
        app.Run();
    }
}