namespace TrainsOnline.Api
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Sciensoft.Hateoas.Extensions;
    using TrainsOnline.Api.Controllers;
    using TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationDetails;
    using TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationsList;

    public static class HateoasLinks
    {
        public static IServiceCollection AddCustomHateoas(this IServiceCollection services)
        {
            services.AddLink(c =>
            {
                c.AddPolicy<GetStationDetailsResponse>(model =>
                {
                    model.AddSelf(m => m.Id, "This is a GET self link.")
                         .AddRoute(m => m.Id, StationController.Update)
                         .AddRoute(m => m.Id, StationController.Delete)
                         .AddCustomPath(m => m.Id, StationController.Create, method: HttpMethods.Post, message: "Edits resource")
                         .AddCustomPath(m => $"/api/station/delete/{m.Id}", StationController.Delete, method: HttpMethods.Delete, message: "Any operation in your resource.");
                });
            });

            return services;
        }
    }

    //public static class LinksExtension
    //{
    //    private static readonly LinksBuilder linksOptions = new LinksBuilder();

    //    public static IServiceCollection AddLinks(
    //        this IServiceCollection services,
    //        Action<LinksBuilder> policySetup = null)
    //    {
    //        services.AddMvc(setup =>
    //        {
    //            setup.Filters.Add<LocationUriResultFilter>();
    //            setup.Filters.Add<HateoasResultFilter>();
    //        });

    //        policySetup?.Invoke(linksOptions);

    //        return services;
    //    }

    //    public static IServiceCollection AddLinks(this IMvcBuilder mvcBuilder, Action<LinksBuilder> policySetup = null)
    //        => mvcBuilder.Services.AddLinks(policySetup);
    //}
}
