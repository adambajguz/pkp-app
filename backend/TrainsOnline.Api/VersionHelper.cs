namespace TrainsOnline.Api
{
    using System;
    using System.Reflection;

    public static class VersionHelper
    {
        public static string? AppFullVersion => Assembly.GetExecutingAssembly().GetName().Version?.ToString();
        public static Version? Version => Assembly.GetExecutingAssembly().GetName().Version;

        public static string AppVersion
        {
            get
            {
                Version? version = Version;
                return $"{version?.Major}.{version?.Minor}.{version?.MajorRevision}";
            }
        }

        public static string AppShortVersion
        {
            get
            {
                Version? version = Version;
                return $"{version?.Major}.{version?.Minor}";
            }
        }
    }
}
