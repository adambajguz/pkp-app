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
        public WebApiTypes ApiType { get; set; }

        public bool IsAuthenticated { get => !string.IsNullOrWhiteSpace(Token); }
        protected string Token { get; private set; }

        private SoapDataProvider SoapProvider { get; }
        private RestDataProvider RestProvider { get; }

        private IDataProvider DataProvider => (ApiType == WebApiTypes.SOAP ? (IDataProvider)SoapProvider : RestProvider);

        public RemoteDataProviderService()
        {
            SoapProvider = new SoapDataProvider();
            RestProvider = new RestDataProvider();
        }

        public async Task<JwtTokenModel> Login(LoginRequest data)
        {
            JwtTokenModel jwtTokenModel = await DataProvider.Login(data);
            Token = jwtTokenModel?.Token;

            return jwtTokenModel;
        }

        public void Logout()
        {
            Token = string.Empty;
        }

        public async Task<IdResponse> Register(CreateUserRequest data)
        {
            return await DataProvider.Register(data);
        }

        public async Task<GetUserDetailsResponse> GetCurrentUser()
        {
            return await DataProvider.GetCurrentUser();
        }

        public async Task<GetStationDetailsResponse> GetStation(Guid id)
        {
            return await DataProvider.GetStation(id);
        }

        public async Task<GetStationsListResponse> GetStations()
        {
            return await DataProvider.GetStations();
        }

        public async Task<GetRouteDetailsResponse> GetRoute(Guid id)
        {
            return await DataProvider.GetRoute(id);
        }

        public async Task<GetRoutesListResponse> GetRoutes()
        {
            return await DataProvider.GetRoutes();
        }

        public async Task<IdResponse> CreateTicket(CreateTicketRequest data)
        {
            return await DataProvider.CreateTicket(data);
        }

        public async Task<GetTicketDetailsResponse> GetTicket(Guid id)
        {
            return await DataProvider.GetTicket(id);
        }

        public async Task<GetTicketDocumentResponse> GetTicketDocument(Guid id)
        {
            return await DataProvider.GetTicketDocument(id);
        }

        public async Task<GetUserTicketsListResponse> GetCurrentUserTickets()
        {
            return await DataProvider.GetCurrentUserTickets();
        }
    }
}
