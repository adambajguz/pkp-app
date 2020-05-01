namespace TrainsOnline.Desktop.Infrastructure.RemoteDataProvider
{
    using System;
    using System.Threading.Tasks;
    using RestSharp;
    using TrainsOnline.Desktop.Application.Interfaces;
    using TrainsOnline.Desktop.Domain.DTO;
    using TrainsOnline.Desktop.Domain.DTO.Authentication;
    using TrainsOnline.Desktop.Domain.DTO.Route;
    using TrainsOnline.Desktop.Domain.DTO.Station;
    using TrainsOnline.Desktop.Domain.DTO.Ticket;
    using TrainsOnline.Desktop.Domain.DTO.User;
    using TrainsOnline.Desktop.Infrastructure.Extensions;

    public class RemoteDataProviderService : IRemoteDataProviderService
    {
        private const string ApiUrl = "https://genericapi.francecentral.cloudapp.azure.com/";

        public bool UseSoapApi { get; set; }

        public bool IsAuthenticated { get => !string.IsNullOrWhiteSpace(Token); }
        protected string Token { get; private set; }

        private RestClient Client { get; }

        public RemoteDataProviderService()
        {
            Client = new RestClient(ApiUrl);
        }

        public async Task<JwtTokenModel> Login(LoginRequest data)
        {
            RestRequest request = new RestRequest("api/user/login", DataFormat.Json);
            request.AddJsonBody(data);

            JwtTokenModel jwtTokenModel = await Client.PostAsync<JwtTokenModel>(request);
            Token = jwtTokenModel?.Token;

            return jwtTokenModel;
        }

        public void Logout()
        {
            Token = string.Empty;
        }

        public async Task<IdResponse> Register(CreateUserRequest data)
        {
            RestRequest request = new RestRequest("api/user/create", DataFormat.Json);
            request.AddJsonBody(data);

            return await Client.GetAsync<IdResponse>(request);
        }

        public async Task<GetUserDetailsResponse> GetCurrentUser()
        {
            RestRequest request = new RestRequest("api/user/get-current", DataFormat.Json);

            return await Client.GetAsync<GetUserDetailsResponse>(request);
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

        public async Task<IdResponse> CreateTicket(CreateTicketRequest data)
        {
            if (!IsAuthenticated)
            {
                return null;
            }

            RestRequest request = new RestRequest("api/ticket/create}", DataFormat.Json);
            request.AddJsonBody(data)
                   .AddBearerAuthentication(Token);

            return await Client.GetAsync<IdResponse>(request);
        }

        public async Task<GetTicketDetailsResponse> GetTicket(Guid id)
        {
            if (!IsAuthenticated)
            {
                return null;
            }

            RestRequest request = new RestRequest("api/ticket/get/{id}", DataFormat.Json);
            request.AddParameter("id", id, ParameterType.UrlSegment)
                   .AddBearerAuthentication(Token);

            return await Client.GetAsync<GetTicketDetailsResponse>(request);
        }

        public async Task<GetTicketDocumentResponse> GetTicketDocument(Guid id)
        {
            if (!IsAuthenticated)
            {
                return null;
            }

            RestRequest request = new RestRequest("api/ticket/get-document/{id}", DataFormat.Json);
            request.AddParameter("id", id, ParameterType.UrlSegment)
                   .AddBearerAuthentication(Token);

            return await Client.GetAsync<GetTicketDocumentResponse>(request);
        }

        public async Task<GetUserTicketsListResponse> GetCurrentUserTickets()
        {
            if (!IsAuthenticated)
            {
                return null;
            }

            RestRequest request = new RestRequest("api/ticket/get-all-current-user", DataFormat.Json);
            request.AddBearerAuthentication(Token);

            return await Client.GetAsync<GetUserTicketsListResponse>(request);
        }
    }
}
