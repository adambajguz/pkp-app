namespace TrainsOnline.Api.SoapEndpoints.Core
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class SoapRouteAttribute : Attribute
    {
        public string RouteScheme { get; }

        public SoapRouteAttribute(string routeScheme)
        {
            RouteScheme = routeScheme;
        }
    }
}
