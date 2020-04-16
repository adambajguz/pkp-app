namespace TrainsOnline.Common
{
    using System;
    using System.Reflection;

    public static class VersionHelper
    {
        public static string? AppFullVersion => Assembly.GetEntryAssembly()?.GetName()?.Version?.ToString();
        public static Version? Version => Assembly.GetEntryAssembly()?.GetName()?.Version;

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
