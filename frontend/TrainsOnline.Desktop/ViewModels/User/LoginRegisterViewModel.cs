namespace TrainsOnline.Desktop.ViewModels.User
{
    using Caliburn.Micro;
    using TrainsOnline.Desktop.Application.Interfaces.RemoteDataProvider;
    using TrainsOnline.Desktop.Views.Ticket;

    public class LoginRegisterViewModel : Screen, ILoginRegisterGridViewEvents
    {
        private int _pivotIndex;
        public int PivotIndex
        {
            get => _pivotIndex;
            set => Set(ref _pivotIndex, value);
        }

        #region Login Properties
        private string _loginEmail;
        public string LoginEmail
        {
            get => _loginEmail;
            set => Set(ref _loginEmail, value);
        }

        private string _loginPassword;
        public string LoginPassword
        {
            get => _loginPassword;
            set => Set(ref _loginPassword, value);
        }
        #endregion

        #region Register Properties
        private string _registerEmail;
        public string RegisterEmail
        {
            get => _registerEmail;
            set => Set(ref _registerEmail, value);
        }

        private string _registerPassword;
        public string RegisterPassword
        {
            get => _registerPassword;
            set => Set(ref _registerPassword, value);
        }

        private string _registerName;
        public string RegisterName
        {
            get => _registerName;
            set => Set(ref _registerName, value);
        }

        private string _registerSurname;
        public string RegisterSurname
        {
            get => _registerSurname;
            set => Set(ref _registerSurname, value);
        }

        private string _registerPhoneNumber;
        public string RegisterPhoneNumber
        {
            get => _registerPhoneNumber;
            set => Set(ref _registerPhoneNumber, value);
        }

        private string _registerAddress;
        public string RegisterAddress
        {
            get => _registerAddress;
            set => Set(ref _registerAddress, value);
        }
        #endregion

        private IRemoteDataProviderService RemoteDataProvider { get; }
        private INavigationService NavigationService { get; }

        public LoginRegisterViewModel(IRemoteDataProviderService remoteDataProvider,
                                      INavigationService navigationService)
        {
            RemoteDataProvider = remoteDataProvider;
            NavigationService = navigationService;
        }

        public async void Login()
        {
            await RemoteDataProvider.Login(LoginEmail, LoginPassword);

            NavigationService.GoBack();
        }

        public async void Register()
        {
            await RemoteDataProvider.Register(new Domain.DTO.User.CreateUserRequest
            {
                Email = RegisterEmail,
                Password = RegisterPassword,
                Name = RegisterName,
                Surname = RegisterSurname,
                PhoneNumber = RegisterPhoneNumber,
                Address = RegisterAddress
            });

            PivotIndex = 0;
        }
    }
}
