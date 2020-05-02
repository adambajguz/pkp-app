﻿namespace TrainsOnline.Desktop.Domain.RemoteDataProvider
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using TrainsOnline.Desktop.Application.Interfaces.RemoteDataProvider;
    using TrainsOnline.Desktop.Domain.DTO;
    using TrainsOnline.Desktop.Domain.DTO.Authentication;
    using TrainsOnline.Desktop.Domain.DTO.Route;
    using TrainsOnline.Desktop.Domain.DTO.Station;
    using TrainsOnline.Desktop.Domain.DTO.Ticket;
    using TrainsOnline.Desktop.Domain.DTO.User;
    using TrainsOnline.Desktop.Domain.RemoteDataProvider.Interfaces;

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

        #region User
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

        public async Task<Guid> Register(CreateUserRequest data)
        {
            IdResponse response = await DataProvider.Register(data);

            return response.Id;
        }

        public async Task<GetUserDetailsResponse> GetCurrentUser()
        {
            return await DataProvider.GetCurrentUser();
        }
        #endregion

        #region Station
        public async Task<GetStationDetailsResponse> GetStation(Guid id)
        {
            return await DataProvider.GetStation(id);
        }

        public async Task<GetStationsListResponse> GetStations()
        {
            return await DataProvider.GetStations();
        }
        #endregion

        #region Route
        public async Task<GetRouteDetailsResponse> GetRoute(Guid id)
        {
            return await DataProvider.GetRoute(id);
        }

        public async Task<GetRoutesListResponse> GetRoutes()
        {
            return await DataProvider.GetRoutes();
        }
        #endregion

        #region Ticket
        public async Task<Guid> CreateTicket(CreateTicketRequest data)
        {
            IdResponse response = await DataProvider.CreateTicket(data);

            return response.Id;
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
        #endregion
    }
}
