namespace TrainsOnline.Api.Configuration
{
    using Microsoft.AspNetCore.Builder;
    using TrainsOnline.Common;

    public static class SwaggerConfiguration
    {
        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = false;
                c.RouteTemplate = "api/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api";
                c.SwaggerEndpoint("/api/v1/swagger.json", "BioGameAPI " + VersionHelper.AppVersion);
            });

            return app;
        }
    }
}
