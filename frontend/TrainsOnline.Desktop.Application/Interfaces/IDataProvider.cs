namespace TrainsOnline.Desktop.Application.Interfaces
{
    using System;
    using System.Threading.Tasks;
    using TrainsOnline.Desktop.Domain.DTO;
    using TrainsOnline.Desktop.Domain.DTO.Authentication;
    using TrainsOnline.Desktop.Domain.DTO.Route;
    using TrainsOnline.Desktop.Domain.DTO.Station;
    using TrainsOnline.Desktop.Domain.DTO.Ticket;
    using TrainsOnline.Desktop.Domain.DTO.User;

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
