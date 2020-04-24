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
        }
    }
}
