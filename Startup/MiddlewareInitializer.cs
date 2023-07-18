using IWantApp.Middleware;

namespace IWantApp.Startup;

public static partial class MiddlewareInitializer
{
    public static WebApplication ConfigureMiddleware(this WebApplication app)
    {
        ConfigureSwagger(app);

        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.ConfigureExceptionHandler(app.Logger);

        return app;
    }

    private static void ConfigureSwagger(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}
