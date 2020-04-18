namespace TrainsOnline.Api.SpecialPages
{
    using System.Text;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using TrainsOnline.Api.SoapEndpoints;

    public static class SoapEndpointsPage
    {
        private static string[] Endpoints { get; } =
        {
            ConfigureEndpoints.AuthenticationEndpoint,
            ConfigureEndpoints.UserEndpoint
        };

        public static void AddSoapEndpointsPage(this IApplicationBuilder app, IServiceCollection services)
        {
            app.Map(ConfigureEndpoints.BaseUrl, builder => builder.Run(async context =>
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<h1>Soap Services Endpoints List</h1>");
                sb.Append("<table><thead>");
                sb.Append("<tr><th>Endpoints</th></tr>");
                sb.Append("</thead><tbody>");

                foreach (string endpoint in Endpoints)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td>{endpoint}</td>");
                    sb.Append("</tr>");
                }

                sb.Append("</tbody></table>");

                await context.Response.WriteAsync(sb.ToString());
            }));
        }
    }
}
