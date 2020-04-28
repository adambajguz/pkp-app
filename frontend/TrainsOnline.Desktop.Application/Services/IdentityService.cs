namespace TrainsOnline.Desktop.Application.Services
{
    using System;
    using System.Net.NetworkInformation;
    using System.Threading.Tasks;

    using Microsoft.Identity.Client;

    using TrainsOnline.Desktop.Application.Helpers;

    public class IdentityService
    {
        public event EventHandler LoggedIn;

        public event EventHandler LoggedOut;

        public void InitializeWithAadAndPersonalMsAccounts()
        {

        }

        public bool IsLoggedIn()
        {
            return true;
        }

        public async Task<LoginResultType> LoginAsync()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                return LoginResultType.NoNetworkAvailable;
            }

            try
            {


                if (!IsAuthorized())
                {
                    return LoginResultType.Unauthorized;
                }

                LoggedIn?.Invoke(this, EventArgs.Empty);
                return LoginResultType.Success;
            }
            catch (MsalClientException ex)
            {
                if (ex.ErrorCode == "authentication_canceled")
                {
                    return LoginResultType.CancelledByUser;
                }

                return LoginResultType.UnknownError;
            }
            catch (Exception)
            {
                return LoginResultType.UnknownError;
            }
        }

        public bool IsAuthorized()
        {
            // TODO WTS: You can also add extra authorization checks here.
            // i.e.: Checks permisions of _authenticationResult.Account.Username in a database.
            return true;
        }

        public string GetAccountUserName()
        {
            return "test";
        }

        public async Task LogoutAsync()
        {
            try
            {

                LoggedOut?.Invoke(this, EventArgs.Empty);
            }
            catch (MsalException)
            {
                // TODO WTS: LogoutAsync can fail please handle exceptions as appropriate to your scenario
                // For more info on MsalExceptions see
                // https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/exceptions
            }
        }
    }
}
