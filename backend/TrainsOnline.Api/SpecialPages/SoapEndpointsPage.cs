namespace TrainsOnline.Api.SpecialPages
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using TrainsOnline.Api.SoapEndpoints.Core;

    public static class SoapEndpointsPage
    {
        public static void AddSoapEndpointsPage(this IApplicationBuilder app)
        {
            app.Map(ConfigureEndpoints.BaseUrl, builder => builder.Run(async context =>
            {
                IEnumerable<EndpointServiceSpecification> specifications = Assembly.GetExecutingAssembly()
                                                                                   .GetAllSoapEndpointServicesSpecification();

                StringBuilder sb = new StringBuilder();
                sb.Append("<h1>Soap Services Endpoints List</h1>");
                sb.Append("<table><thead>");
                sb.Append("<tr><th>Endpoint</th><th>Route scheme</th><th>Service : Interface</th></tr>");
                sb.Append("</thead><tbody>");

                foreach (EndpointServiceSpecification spec in specifications)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td><a href=\"{spec.ResolveRoute(ConfigureEndpoints.BaseUrl)}\">{spec}</a></td>");
                    sb.Append($"<td>{spec.RouteScheme}</td>");
                    sb.Append($"<td>{spec.Service.FullName} {spec.Interface.FullName}</td>");
                    sb.Append("</tr>");
                }

                sb.Append("</tbody></table>");

                await context.Response.WriteAsync(sb.ToString());
            }));
        }
    }
}
