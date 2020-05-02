namespace TrainsOnline.Desktop.Infrastructure.RemoteDataProvider
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using TrainsOnline.Desktop.Application.Interfaces.RemoteDataProvider;
    using TrainsOnline.Desktop.Domain.ValueObjects.Route;
    using TrainsOnline.Desktop.Domain.ValueObjects.Station;
    using TrainsOnline.Desktop.Domain.ValueObjects.Ticket;
    using TrainsOnline.Desktop.Domain.ValueObjects.User;
    using TrainsOnline.Desktop.Infrastructure.DTO;
    using TrainsOnline.Desktop.Infrastructure.DTO.Authentication;
    using TrainsOnline.Desktop.Infrastructure.DTO.Route;
    using TrainsOnline.Desktop.Infrastructure.DTO.Station;
    using TrainsOnline.Desktop.Infrastructure.DTO.Ticket;
    using TrainsOnline.Desktop.Infrastructure.DTO.User;
    using TrainsOnline.Desktop.Infrastructure.RemoteDataProvider.Interfaces;

    public class RemoteDataProviderService : IRemoteDataProviderService
    {
        private IMapper Mapper { get; set; }

        public WebApiTypes ApiType { get; set; }

        public bool IsAuthenticated => !string.IsNullOrWhiteSpace(Token);
        protected string Token { get; private set; }

        private SoapDataProvider SoapProvider { get; }
        private RestDataProvider RestProvider { get; }

        private IDataProvider DataProvider => (ApiType == WebApiTypes.SOAP ? (IDataProvider)SoapProvider : RestProvider);

        public RemoteDataProviderService(IMapper mapper)
        {
            Mapper = mapper;

            SoapProvider = new SoapDataProvider();
            RestProvider = new RestDataProvider();
        }

        public async Task<bool> Login(string email, string password)
        {
            JwtTokenModel jwtTokenModel = await DataProvider.Login(new LoginRequest
            {
                Email = email,
                Password = password
            });

            Token = jwtTokenModel?.Token;

            return IsAuthenticated;
        }

        public void Logout()
        {
            Token = string.Empty;
        }

        public async Task<Guid> Register(NewUser data)
        {
            CreateUserRequest request = Mapper.Map<CreateUserRequest>(data);
            IdResponse response = await DataProvider.Register(request);

            return response.Id;
        }

        public async Task<UserDetailsValueObject> GetCurrentUser()
        {
            GetUserDetailsResponse response = await DataProvider.GetCurrentUser();
            Mapper.Map<UserDetailsValueObject>(response);

            return null;
        }

        public async Task<StationDetailsValueObject> GetStation(Guid id)
        {
            GetStationDetailsResponse response = await DataProvider.GetStation(id);
            return null;
        }

        public async Task<IList<StationDetailsValueObject>> GetStations()
        {
            GetStationsListResponse response = await DataProvider.GetStations();
            return null;
        }

        public async Task<RouteDetailsValueObject> GetRoute(Guid id)
        {
            GetRouteDetailsResponse response = await DataProvider.GetRoute(id);
            return null;
        }

        public async Task<IList<RouteDetailsValueObject>> GetRoutes()
        {
            GetRoutesListResponse response = await DataProvider.GetRoutes();
            return null;
        }

        public async Task<Guid> CreateTicket(NewTicket data)
        {
            IdResponse response = await DataProvider.CreateTicket(null);
            return response.Id;
        }

        public async Task<TicketDetailsValueObject> GetTicket(Guid id)
        {
            GetTicketDetailsResponse response = await DataProvider.GetTicket(id);
            return null;
        }

        public async Task<TicketDocumentValueObject> GetTicketDocument(Guid id)
        {
            GetTicketDocumentResponse response = await DataProvider.GetTicketDocument(id);
            return null;
        }

        public async Task<IList<TicketDetailsValueObject>> GetCurrentUserTickets()
        {
            GetUserTicketsListResponse response = await DataProvider.GetCurrentUserTickets();
            return null;
        }
    }
}
