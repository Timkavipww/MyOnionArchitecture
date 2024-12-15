namespace WebAPI.Services;

public static class DependencyInjections
{
    public static void AddDependencyInjection(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.Services.AddApplication();
        builder.Services.AddPersistence(builder.Configuration);

    }
}
