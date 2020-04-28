namespace TrainsOnline.Desktop.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using TrainsOnline.Desktop.Application.Helpers;
    using TrainsOnline.Desktop.Application.Services;
    using TrainsOnline.Desktop.Extensions;
    using TrainsOnline.Desktop.Services;
    using Windows.ApplicationModel;
    using Windows.UI.Xaml;

    // TODO WTS: Add other settings as necessary. For help see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/pages/settings.md
    public class SettingsViewModel : ViewModelBase
    {
        private UserDataService UserDataService => Singleton<UserDataService>.Instance;

        private IdentityService IdentityService => Singleton<IdentityService>.Instance;

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

        private ICommand _switchThemeCommand;

        public ICommand SwitchThemeCommand
        {
            get
            {
                if (_switchThemeCommand == null)
                {
                    _switchThemeCommand = new RelayCommand<ElementTheme>(
                        async (param) =>
                        {
                            ElementTheme = param;
                            await ThemeSelectorService.SetThemeAsync(param);
                        });
                }

                return _switchThemeCommand;
            }
        }

        private UserViewModel _user;

        private ICommand _logoutCommand;

        public ICommand LogoutCommand => _logoutCommand ?? (_logoutCommand = new RelayCommand(OnLogout));

        public UserViewModel User
        {
            get => _user;
            set => Set(ref _user, value);
        }

        public SettingsViewModel()
        {
        }

        public async Task InitializeAsync()
        {
            VersionDescription = GetVersionDescription();
            IdentityService.LoggedOut += OnLoggedOut;
            UserDataService.UserDataUpdated += OnUserDataUpdated;
            User = await UserDataService.GetUserAsync();
        }

        private string GetVersionDescription()
        {
            string appName = "AppDisplayName".GetLocalized();
            Package package = Package.Current;
            PackageId packageId = package.Id;
            PackageVersion version = packageId.Version;

            return $"{appName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }

        public void UnregisterEvents()
        {
            IdentityService.LoggedOut -= OnLoggedOut;
            UserDataService.UserDataUpdated -= OnUserDataUpdated;
        }

        private void OnUserDataUpdated(object sender, UserViewModel userData)
        {
            User = userData;
        }

        private async void OnLogout()
        {
            await IdentityService.LogoutAsync();
        }

        private void OnLoggedOut(object sender, EventArgs e)
        {
            UnregisterEvents();
        }
    }
}
