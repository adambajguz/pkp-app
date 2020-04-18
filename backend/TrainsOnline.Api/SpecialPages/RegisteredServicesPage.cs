namespace TrainsOnline.Api.SpecialPages
{
    using System.Text;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;

    public static class RegisteredServicesPage
    {
        public static void AddRegisteredServicesPage(this IApplicationBuilder app, IServiceCollection services)
        {
            app.Map("/services", builder => builder.Run(async context =>
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<h1>Registered Services</h1>");
                sb.Append("<table><thead>");
                sb.Append("<tr><th>Type</th><th>Lifetime</th><th>Instance</th></tr>");
                sb.Append("</thead><tbody>");

                if (services == null)
                    sb.Append("<tr><td>_services is null</td></tr>");
                else
                {
                    foreach (ServiceDescriptor svc in services)
                    {
                        sb.Append("<tr>");
                        sb.Append($"<td>{svc.ServiceType.FullName}</td>");
                        sb.Append($"<td>{svc.Lifetime}</td>");
                        sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
                        sb.Append("</tr>");
                    }
                }
                sb.Append("</tbody></table>");

                await context.Response.WriteAsync(sb.ToString());
            }));
        }
    }
}
