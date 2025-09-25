using DirectoryService.Application;
using DirectoryService.Application.Database;
using DirectoryService.Infrastructure;

namespace DirectoryService.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        builder.Services.AddScoped<IDirectoryServiceDbContext, DirectoryServiceDbContext>(_ =>
            new DirectoryServiceDbContext(builder.Configuration.GetConnectionString("DirectoryServiceDb")!));

        builder.Services.AddScoped<CreateLocationHandle>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "DirectoryService"));
        }
        
        app.MapControllers();

        app.Run();
    }
}