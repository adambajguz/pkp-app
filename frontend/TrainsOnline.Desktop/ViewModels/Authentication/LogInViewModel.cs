namespace TrainsOnline.Desktop.ViewModels
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using TrainsOnline.Desktop.Application.Helpers;
    using TrainsOnline.Desktop.Application.Services;
    using TrainsOnline.Desktop.Extensions;

    public class LogInViewModel : ViewModelBase
    {
        private string _statusMessage;
        private bool _isBusy;
        private RelayCommand _loginCommand;

        private IdentityService IdentityService => Singleton<IdentityService>.Instance;

        public string StatusMessage
        {
            get => _statusMessage;
            set => Set(ref _statusMessage, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                Set(ref _isBusy, value);
                LoginCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand LoginCommand => _loginCommand ?? (_loginCommand = new RelayCommand(OnLogin, () => !IsBusy));

        public LogInViewModel()
        {

        }

        private async void OnLogin()
        {
            IsBusy = true;
            StatusMessage = string.Empty;
            LoginResultType loginResult = await IdentityService.LoginAsync();
            StatusMessage = GetStatusMessage(loginResult);
            IsBusy = false;
        }

        private string GetStatusMessage(LoginResultType loginResult)
        {
            switch (loginResult)
            {
                case LoginResultType.Unauthorized:
                    return "StatusUnauthorized".GetLocalized();
                case LoginResultType.NoNetworkAvailable:
                    return "StatusNoNetworkAvailable".GetLocalized();
                case LoginResultType.UnknownError:
                    return "StatusLoginFails".GetLocalized();
                default:
                    return string.Empty;
            }
        }
    }
}
