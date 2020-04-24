namespace TrainsOnline.Common
{
    using System;
    using System.Reflection;

    public static partial class GlobalAppConfig
    {
        public static class AppInfo
        {
            public static Version AppVersion { get; } = Assembly.GetEntryAssembly()?.GetName()?.Version ?? new Version(0, 0, 0, 0);
            public static string AppVersionText { get; } = AppVersion.ToString();

            public static string AppName { get; } = "TrainsOnline";
            public static string Author { get; } = "Adam Bajguz & Michał Kierzkowski";
            public static string AppDevelopmentYear { get; } = "2020";

            public static string AppCopyright { get; } = $"© {Author} {AppDevelopmentYear}";
            public static string AppNameWithVersion { get; } = $"{AppName} v{AppVersionText}";
            public static string AppNameWithVersionCopyright { get; } = $"{AppName} v{AppVersionText} — {AppCopyright}";

            public static string SentryReleaseVersion { get; } = $"{AppName}-v{AppVersionText}";
            public static string SwaggerDocumentName { get; } = "v1";
            public static string SwaggerStartupUrl { get; } = $"/api/{SwaggerDocumentName}/swagger.json";
            public static string RestApiUrl { get; } = "/api";
            public static string SoapApiUrl { get; } = "/soap-api";

            public static string AppDescription { get; } = $"Backend Api for {AppName}.\n" +
                                                           $"{AppCopyright}\n" +
                                                           "\n" +
                                                           @$"REST API JSON can be found at {SwaggerStartupUrl}\n" +
                                                           @$"REST API can be accessed through {RestApiUrl}\n" +
                                                           @$"Soap version of the api can be found at {SoapApiUrl}";
            public static string AppDescriptionHTML { get; } = $"Backend Api for {AppName}<br>" +
                                                               $"{AppCopyright}<br>" +
                                                               "<hr>" +
                                                               "<p>" +
                                                               @$"REST API JSON can be found at <a href=""{SwaggerStartupUrl}"">{SwaggerStartupUrl}</a><br>" +
                                                               @$"REST API docs can be found at <a href=""{RestApiUrl}"">{RestApiUrl}</a><br>" +
                                                               @$"SOAP API docs can be found at <a href=""{SoapApiUrl}"">{SoapApiUrl}</a>" +
                                                               "</p>";
        }
    }
}
