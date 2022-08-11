using Sgb.Api.Extensions;
using Sgb.Api.IoC;

namespace Sgb.Api;

public class Startup : Interfaces.IStartup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) =>        
        Configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddControllers();//.AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new IntToStringConverter()))
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddVersioning();
        services.AddSwagger();
        services.AddAuthentication(Configuration);
        services.AddAuthorizationPolicies();
        services.RegisterServices(Configuration);
    }
    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if(env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors(builder => builder
            .SetIsOriginAllowed(orign => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
        app.MapControllers();
    }

    
}
