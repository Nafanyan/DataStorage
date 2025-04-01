using Application;
using DataStorage.ConfigurationBindings;
using Infrastructure;

namespace DataStorage;

public class Program
{
    public static void Main( string[] args )
    {
        var builder = WebApplication.CreateBuilder( args );

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile( "appsettings.json" )
            .AddJsonFile( $"appsettings.{builder.Environment.EnvironmentName}.json" )
            .Build();

        AddServicesBindings( builder.Services );
        AddConfigurationsBindings( builder.Services, configuration );

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        var app = builder.Build();
        // Configure the HTTP request pipeline.
        if ( app.Environment.IsDevelopment() )
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseCors( builder =>
        //{
        //    builder.WithOrigins( configuration[ "WithOrigins:LocalHost" ] )
        //    .AllowAnyHeader()
        //    .AllowAnyMethod()
        //    .AllowCredentials();
        //} );

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void AddServicesBindings( IServiceCollection services )
    {
        services.AddApplicationBindings();
        services.AddInfrastructureBindings();
    }

    private static void AddConfigurationsBindings( IServiceCollection services, IConfiguration configuration )
    {
        services.AddStorageConfigurationBindings( configuration );
    }
}

