namespace TrainsOnline.Api.SoapEndpoints.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class AssemblySoapExtensions
    {
        public static IEnumerable<Type> GetAllSoapEndpointServices(this Assembly assembly)
        {
            IEnumerable<Type> soapEndpointServices = from type in assembly.GetTypes()
                                                     where typeof(ISoapEndpointService).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract
                                                     select type;

            return soapEndpointServices;
        }

        public static IEnumerable<EndpointServiceSpecification> GetAllSoapEndpointServicesSpecification(this Assembly assembly)
        {
            IEnumerable<Type> soapEndpointServices = assembly.GetAllSoapEndpointServices();

            IEnumerable<EndpointServiceSpecification> tmp = soapEndpointServices.Select((type) =>
            {
                Type @interface = type.GetInterfaces()
                                      .Where(x => x.GetInterfaces()
                                                   .Contains(typeof(ISoapEndpointService)))
                                      .First();

                string route = type.GetCustomAttribute<SoapRouteAttribute>()?.RouteScheme ?? throw new NullReferenceException($"{nameof(SoapRouteAttribute)} not set in class {type.FullName}");

                return new EndpointServiceSpecification(type, @interface, route);
            });

            return tmp;
        }
    }

    public class EndpointServiceSpecification
    {
        public Type Service { get; }
        public Type Interface { get; }
        public string RouteScheme { get; }

        public EndpointServiceSpecification(Type service, Type @interface, string routeScheme)
        {
            Service = service;
            Interface = @interface;
            RouteScheme = routeScheme;
        }

        public string ResolveRoute(string basePath)
        {
            return RouteScheme.Replace("[baseUrl]", basePath);
        }
    }
}
