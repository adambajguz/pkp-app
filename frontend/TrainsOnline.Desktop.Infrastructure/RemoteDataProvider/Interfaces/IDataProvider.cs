namespace TrainsOnline.Desktop.Infrastructure.RemoteDataProvider.Interfaces
{
    using System;
    using System.Threading.Tasks;
    using TrainsOnline.Desktop.Infrastructure.DTO;
    using TrainsOnline.Desktop.Infrastructure.DTO.Authentication;
    using TrainsOnline.Desktop.Infrastructure.DTO.Route;
    using TrainsOnline.Desktop.Infrastructure.DTO.Station;
    using TrainsOnline.Desktop.Infrastructure.DTO.Ticket;
    using TrainsOnline.Desktop.Infrastructure.DTO.User;

    public interface IDataProvider
    {
        bool IsAuthenticated { get; }

        Task<JwtTokenModel> Login(LoginRequest data);
        void Logout();
        Task<IdResponse> Register(CreateUserRequest data);

        Task<GetUserDetailsResponse> GetCurrentUser();

        Task<GetStationDetailsResponse> GetStation(Guid id);
        Task<GetStationsListResponse> GetStations();

        Task<GetRouteDetailsResponse> GetRoute(Guid id);
        Task<GetRoutesListResponse> GetRoutes();

        Task<IdResponse> CreateTicket(CreateTicketRequest data);
        Task<GetTicketDetailsResponse> GetTicket(Guid id);
        Task<GetTicketDocumentResponse> GetTicketDocument(Guid id);
        Task<GetUserTicketsListResponse> GetCurrentUserTickets();
    }
}
