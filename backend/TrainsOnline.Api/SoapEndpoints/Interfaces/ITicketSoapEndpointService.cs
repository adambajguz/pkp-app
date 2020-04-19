namespace TrainsOnline.Api.SoapEndpoints.Interfaces
{
    using System.ServiceModel;
    using System.Threading.Tasks;
    using MediatR;
    using TrainsOnline.Api.CustomMiddlewares;
    using TrainsOnline.Api.SoapEndpoints.Core;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Handlers.TicketHandlers.Commands.CreateTicket;
    using TrainsOnline.Application.Handlers.TicketHandlers.Commands.UpdateTicket;
    using TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketDetails;
    using TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketsList;
    using TrainsOnline.Domain.Jwt;

    [ServiceContract]
    public interface ITicketSoapEndpointService : ISoapEndpointService
    {
        [SoapAuthorize(Roles = Roles.User)]
        [OperationContract]
        Task<IdResponse> CreateTicket(CreateTicketRequest ticket);

        [OperationContract]
        Task<GetTicketDetailResponse> GetTicketDetails(IdRequest id);

        [SoapAuthorize(Roles = Roles.Admin)]
        [OperationContract]
        Task<Unit> UpdateTicket(UpdateTicketRequest ticket);

        [SoapAuthorize(Roles = Roles.Admin)]
        [OperationContract]
        Task<Unit> DeleteTicket(IdRequest id);

        [OperationContract]
        Task<GetTicketsListResponse> GetTicketsList();
    }
}