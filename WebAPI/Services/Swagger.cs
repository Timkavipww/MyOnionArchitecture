namespace WebAPI.Services;

public static class SwaggerDI
{
    public static void AddMySwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(c =>
        {
            c.IncludeXmlComments(string.Format(@"{0}\OnionArchitecture.xml", System.AppDomain.CurrentDomain.BaseDirectory));
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "1.0",
                Title = "OnionArchitecture",
            });

        });
    }
}
