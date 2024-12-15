namespace WebAPI.Services;

public static class DependencyInjections
{
    public static WebApplicationBuilder AddDependencyInjection(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.Services.AddApplication();
        builder.Services.AddPersistence(configuration);

        return builder;
    }
}
