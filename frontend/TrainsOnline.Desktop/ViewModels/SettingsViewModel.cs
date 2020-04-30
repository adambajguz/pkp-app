namespace TrainsOnline.Desktop.ViewModels
{
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Helpers;
    using TrainsOnline.Desktop.Services;
    using Windows.ApplicationModel;
    using Windows.UI.Xaml;

    // TODO WTS: Add other settings as necessary. For help see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/pages/settings.md
    public class SettingsViewModel : Screen
    {
        private ElementTheme _elementTheme = ThemeSelectorService.Theme;

        public ElementTheme ElementTheme
        {
            get => _elementTheme;

            set => Set(ref _elementTheme, value);
        }

        private string _versionDescription;

        public string VersionDescription
        {
            get => _versionDescription;

            set => Set(ref _versionDescription, value);
        }

        public async void SwitchTheme(ElementTheme theme)
        {
            await ThemeSelectorService.SetThemeAsync(theme);
        }

        public SettingsViewModel()
        {
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            VersionDescription = GetVersionDescription();
        }

        private string GetVersionDescription()
        {
            string appName = "AppDisplayName".GetLocalized();
            Package package = Package.Current;
            PackageId packageId = package.Id;
            PackageVersion version = packageId.Version;

            return $"{appName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }
    }
}
