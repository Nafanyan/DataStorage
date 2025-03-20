using Application;
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

        // Add services to the container.
        AddBindings( builder.Services );

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

    private static void AddBindings( IServiceCollection services )
    {
        services.AddApplicationBindings();
        services.AddInfrastructureBindings();
    }
}

