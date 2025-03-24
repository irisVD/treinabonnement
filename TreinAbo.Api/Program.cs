using Microsoft.EntityFrameworkCore;
using TreinAbo.Persistence;
using TreinAbo.Services;


namespace TreinAbo.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("LocalMySQL");
        var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));
        builder.Services.AddDbContext<TreinabonnementenContext>(options =>
            options.UseMySql(connectionString, serverVersion));
        
        builder.Services.AddScoped<IStationService, StationService>();
    
        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}