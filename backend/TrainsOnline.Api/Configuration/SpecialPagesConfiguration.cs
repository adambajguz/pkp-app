namespace TrainsOnline.Api.Configuration
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public static class SpecialPagesConfiguration
    {
        public static IApplicationBuilder ConfigureSpecialPages(this IApplicationBuilder app, IServiceCollection services)
        {


            return app;
        }
    }
}
