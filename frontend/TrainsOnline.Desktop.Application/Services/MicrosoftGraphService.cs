namespace TrainsOnline.Desktop.Application.Services
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using TrainsOnline.Desktop.Common.Extensions;
    using TrainsOnline.Desktop.Core.Extensions;
    using TrainsOnline.Desktop.Domain.Models;

    public class MicrosoftGraphService
    {
        //// For more information about Get-User Service, refer to the following documentation
        //// https://docs.microsoft.com/graph/api/user-get?view=graph-rest-1.0
        //// You can test calls to the Microsoft Graph with the Microsoft Graph Explorer
        //// https://developer.microsoft.com/graph/graph-explorer

        private const string _graphAPIEndpoint = "https://graph.microsoft.com/v1.0/";
        private const string _apiServiceMe = "me/";
        private const string _apiServiceMePhoto = "me/photo/$value";

        public MicrosoftGraphService()
        {
        }

        public async Task<User> GetUserInfoAsync(string accessToken)
        {
            User user = null;
            HttpContent httpContent = await GetDataAsync($"{_graphAPIEndpoint}{_apiServiceMe}", accessToken);
            if (httpContent != null)
            {
                string userData = await httpContent.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(userData))
                {
                    user = await userData.ToObjectAsync<User>();
                }
            }

            return user;
        }

        public async Task<string> GetUserPhoto(string accessToken)
        {
            HttpContent httpContent = await GetDataAsync($"{_graphAPIEndpoint}{_apiServiceMePhoto}", accessToken);

            if (httpContent == null)
            {
                return string.Empty;
            }

            System.IO.Stream stream = await httpContent.ReadAsStreamAsync();
            return stream.ToBase64String();
        }

        private async Task<HttpContent> GetDataAsync(string url, string accessToken)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                    HttpResponseMessage response = await httpClient.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content;
                    }
                    else
                    {
                        // TODO WTS: Please handle other status codes as appropriate to your scenario
                    }
                }
            }
            catch (HttpRequestException)
            {
                // TODO WTS: The request failed due to an underlying issue such as
                // network connectivity, DNS failure, server certificate validation or timeout.
                // Please handle this exception as appropriate to your scenario
            }
            catch (Exception)
            {
                // TODO WTS: This call can fail please handle exceptions as appropriate to your scenario
            }

            return null;
        }
    }
}
