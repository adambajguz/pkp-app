namespace TrainsOnline.Desktop.Domain.RemoteDataProvider
{
    using System;
    using System.Threading.Tasks;
    using RestSharp;
    using TrainsOnline.Desktop.Domain.DTO;
    using TrainsOnline.Desktop.Domain.DTO.Authentication;
    using TrainsOnline.Desktop.Domain.DTO.Route;
    using TrainsOnline.Desktop.Domain.DTO.Station;
    using TrainsOnline.Desktop.Domain.DTO.Ticket;
    using TrainsOnline.Desktop.Domain.DTO.User;
    using TrainsOnline.Desktop.Domain.Extensions;
    using TrainsOnline.Desktop.Domain.RemoteDataProvider.Interfaces;
    using SOAPS = Infrastructure.Services.SoapServices;

    public class SoapDataProvider : IDataProvider
    {
        private const string ApiUrl = "https://genericapi.francecentral.cloudapp.azure.com/soap-api";
        private const string ApiUrlLocal = "http://localhost:2137/soap-api";

        private bool useLocalUrl;
        public bool UseLocalUrl
        {
            get => useLocalUrl; set
            {
                useLocalUrl = value;
                Client = new RestClient(UseLocalUrl ? ApiUrlLocal : ApiUrl);
            }
        }
        public bool IsAuthenticated => !string.IsNullOrWhiteSpace(Token);
        protected string Token { get; private set; }

        protected RestClient Client { get; private set; }

        public SoapDataProvider()
        {
            Client = new RestClient(ApiUrl);
        }

        public void SetToken(string token)
        {
            Token = token;
        }

        public async Task<JwtTokenModel> Login(LoginRequest data)
        {
            RestRequest request = new RestRequest("user/login", DataFormat.Json);
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
            RestRequest request = new RestRequest("user/create", DataFormat.Json);
            request.AddJsonBody(data);

            return await Client.GetAsync<IdResponse>(request);
        }

        public async Task<GetUserDetailsResponse> GetCurrentUser()
        {
            RestRequest request = new RestRequest("user/get-current", DataFormat.Json);

            return await Client.GetAsync<GetUserDetailsResponse>(request);
        }

        public async Task<GetStationDetailsResponse> GetStation(Guid id)
        {
            RestRequest request = new RestRequest("station/get/{id}", DataFormat.Json);
            request.AddParameter("id", id, ParameterType.UrlSegment);

            return await Client.GetAsync<GetStationDetailsResponse>(request);
        }

        public async Task<GetStationsListResponse> GetStations()
        {
            try
            {
                SOAPS.Station.StationSoapEndpointServiceClient client = new SOAPS.Station.StationSoapEndpointServiceClient();
                dynamic data = await client.GetStationsListAsync(new SOAPS.Station.GetStationsListRequest());

                return data as GetStationsListResponse;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<GetRouteDetailsResponse> GetRoute(Guid id)
        {
            RestRequest request = new RestRequest("route/get/{id}", DataFormat.Json);
            request.AddParameter("id", id, ParameterType.UrlSegment);

            return await Client.GetAsync<GetRouteDetailsResponse>(request);
        }

        public async Task<GetRoutesListResponse> GetFilteredRoutes(GetFilteredRoutesListRequest data)
        {
            RestRequest request = new RestRequest("route/get-filtered", DataFormat.Json);
            request.AddJsonBody(data);

            IRestResponse<GetRoutesListResponse> response = await Client.ExecutePostAsync<GetRoutesListResponse>(request);

            return response.Data;
        }

        public async Task<GetRoutesListResponse> GetRoutes()
        {
            RestRequest request = new RestRequest("route/get-all", DataFormat.Json);

            return await Client.GetAsync<GetRoutesListResponse>(request);
        }

        public async Task<IdResponse> CreateTicket(CreateTicketRequest data)
        {
            if (!IsAuthenticated)
            {
                return null;
            }

            RestRequest request = new RestRequest("ticket/create}", DataFormat.Json);
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

            RestRequest request = new RestRequest("ticket/get/{id}", DataFormat.Json);
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

            RestRequest request = new RestRequest("ticket/get-document/{id}", DataFormat.Json);
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

            RestRequest request = new RestRequest("ticket/get-all-current-user", DataFormat.Json);
            request.AddBearerAuthentication(Token);

            return await Client.GetAsync<GetUserTicketsListResponse>(request);
        }

        public async Task UpdateUser(UpdateUserRequest data)
        {
            if (!IsAuthenticated)
            {
                return;
            }

            RestRequest request = new RestRequest("user/change-password", DataFormat.Json);
            request.AddJsonBody(data)
                   .AddBearerAuthentication(Token);

            IRestResponse response = await Client.ExecuteAsync(request, Method.PATCH);

            return;
        }

        public async Task ChangePassword(ChangePasswordRequest data)
        {
            if (!IsAuthenticated)
            {
                return;
            }

            RestRequest request = new RestRequest("user/change-password", DataFormat.Json);
            request.AddBearerAuthentication(Token);

            IRestResponse response = await Client.ExecuteAsync(request, Method.PATCH);

            return;
        }
    }
}
