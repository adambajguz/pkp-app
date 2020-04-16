namespace TrainsOnline.Api
{
    using CommandLine;
    using SPA.Runner.CommandLineOptions;

    internal static class Program
    {
        public static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<RuntimeOptions>(args)
                     .WithParsed(CoreLogic.Execute)
                     .WithNotParsed(CoreLogic.HandleOptionsErrors);

            //commandLineApplication.HelpOption("--h | --show-help");
            //commandLineApplication.Name = "dotnet TrainsOnline.Api.dll";
            //commandLineApplication.Description = "Backend REST Api for TrainsOnline.";
            //commandLineApplication.ExtendedHelpText = commandLineApplication.Description;
            //commandLineApplication.FullName = GlobalAppConfig.AppInfo.AppName;
            //commandLineApplication.Syntax = "TrainsOnline.Api.dll";
            //commandLineApplication.VersionOption("--version", () => VersionHelper.AppShortVersion, () => VersionHelper.AppVersion);

            //commandLineApplication.OnExecute(() =>
            //{
            //    ExecuteApp(args, doMigrate, verifyMigrate, run);
            //    return 0;
            //});

            //try
            //{
            //    commandLineApplication.Execute(args);
            //}
            //catch (CommandParsingException)
            //{
            //    commandLineApplication.ShowHelp();
            //}
        }
    }
}