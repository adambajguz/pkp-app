namespace TrainsOnline.Common
{
    public static partial class GlobalAppConfig
    {
        public static class AppInfo
        {
            //TODO consolidate with VersionHelper
            public static string AppVersion
            {
                get
                {
                    int major = 1;
                    int minor = 0;
                    int build = 0;
                    int revision = 0;

                    return string.Format("{0}.{1}.{2}.{3}", major, minor, build, revision);
                }
            }

            public static string AppName => "TrainsOnline";
            public static string Author => "Adam Bajguz";
            public static string AppDevelopmentYear => "2020";
            public static string AppCopyright => $"© {Author} {AppDevelopmentYear}";
            public static string AppNameWithCopyright => $"{AppName} v{AppVersion} — {AppCopyright}";
            public static string SentryReleaseVersion => $"{AppName}-v{AppVersion}";
        }
    }
}
