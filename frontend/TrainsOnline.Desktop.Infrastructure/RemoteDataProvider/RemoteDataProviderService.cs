namespace TrainsOnline.Desktop.Infrastructure.RemoteDataProvider
{
    using System;
    using System.Threading.Tasks;
    using RestSharp;
    using TrainsOnline.Desktop.Application.Interfaces;
    using TrainsOnline.Desktop.Domain.Route;
    using TrainsOnline.Desktop.Domain.Station;

    public class RemoteDataProviderService : IRemoteDataProviderService
    {
        private const string ApiUrl = "https://genericapi.francecentral.cloudapp.azure.com/";

        public bool UseSoapApi { get; set; }

        private RestClient Client { get; }

        public RemoteDataProviderService()
        {
            Client = new RestClient(ApiUrl);
        }

        public async Task<GetStationDetailsResponse> GetStation(Guid id)
        {
            RestRequest request = new RestRequest("api/station/get/{id}", DataFormat.Json);
            request.AddParameter("id", id, ParameterType.UrlSegment);

            return await Client.GetAsync<GetStationDetailsResponse>(request);
        }

        public async Task<GetStationsListResponse> GetStations()
        {
            RestRequest request = new RestRequest("api/station/get-all", DataFormat.Json);

            return await Client.GetAsync<GetStationsListResponse>(request);
        }

        public async Task<GetRouteDetailsResponse> GetRoute(Guid id)
        {
            RestRequest request = new RestRequest("api/route/get/{id}", DataFormat.Json);
            request.AddParameter("id", id, ParameterType.UrlSegment);

            return await Client.GetAsync<GetRouteDetailsResponse>(request);
        }

        public async Task<GetRoutesListResponse> GetRoutes()
        {
            RestRequest request = new RestRequest("api/route/get-all", DataFormat.Json);

            return await Client.GetAsync<GetRoutesListResponse>(request);
        }
    }
}
