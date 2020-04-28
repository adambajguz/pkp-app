namespace TrainsOnline.Desktop.Infrastructure
{
    using System.Threading.Tasks;
    using RestSharp;
    using TrainsOnline.Desktop.Domain.Station;

    public class RemoteDataProvider
    {
        private const string ApiUrl = "https://genericapi.francecentral.cloudapp.azure.com/";

        public bool UseSoapApi { get; set; }

        private RestClient Client { get; }

        public RemoteDataProvider()
        {
            Client = new RestClient(ApiUrl);
        }

        public async Task<GetStationsListResponse> GetStations()
        {
            RestRequest request = new RestRequest("api/station/get-all", DataFormat.Json);

            return await Client.GetAsync<GetStationsListResponse>(request);
        }
    }
}
