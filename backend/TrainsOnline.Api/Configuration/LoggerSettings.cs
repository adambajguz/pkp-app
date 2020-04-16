﻿namespace TrainsOnline.Api.Configuration
{
    public sealed class LoggerSettings
    {
        public string? FilePath { get; set; }
        public string? FileNameTemplate { get; set; }
        public string FullPath => string.Concat(FilePath, FileNameTemplate);

        public int RetainedFileCountLimit { get; set; }
        public int FileSizeLimitInBytes { get; set; }
        public int FlushIntervalInSeconds { get; set; }

        public string? FileOutputTemplate { get; set; }

        public string? ConsoleOutputTemplate { get; set; }

        public bool LogEverythingInDev { get; set; }

        public string? SentryDSN { get; set; }
        public bool SentryEnabled { get; set; }
    }
}
