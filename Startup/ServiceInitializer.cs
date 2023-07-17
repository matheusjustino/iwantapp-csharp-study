namespace IWantApp.Startup;

using System.Reflection;
using IWantApp.Data;

public static partial class ServiceInitializer
{
    private static IConfiguration Configuration { get; set; }

    private static string PolicyName = "CorsPolicy";

    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        Configuration = configuration;
        // RegisterHttpClientDependencies(services);
        RegisterSqlServer(services);
        RegisterControllers(services);
        RegisterSwagger(services);
        RegisterCustomDependencies(services);
        RegisterCors(services);

        return services;
    }

    private static void RegisterSqlServer(IServiceCollection services)
    {
        services.AddSqlServer<ApplicationDbContext>(Configuration["ConnectionStrings:IWantDb"]);
    }

    private static void RegisterControllers(IServiceCollection services)
    {
        services.AddControllers();
    }

    private static void RegisterCustomDependencies(IServiceCollection services)
    {
        services.AddServices("IWantApp.Services", Assembly.GetExecutingAssembly());
    }

    private static void RegisterSwagger(IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    private static void RegisterCors(IServiceCollection services)
    {
        services.AddCors(opt => opt.AddPolicy(PolicyName, policy =>
            policy
                .WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()));
    }

    //     private static void RegisterHttpClientDependencies(IServiceCollection services)
    //     {
    //         services.AddHttpClient<>();
    //     }
}
