namespace TrainsOnline.Api.SoapEndpoints
{
    using System.ServiceModel;
    using System.Threading.Tasks;
    using MediatR;
    using TrainsOnline.Api.CustomMiddlewares;
    using TrainsOnline.Api.SoapEndpoints.Core;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Route.Commands.CreateRoute;
    using TrainsOnline.Application.Route.Commands.UpdateRoute;
    using TrainsOnline.Application.Route.Queries.GetRouteDetails;
    using TrainsOnline.Application.Route.Queries.GetRoutesList;
    using TrainsOnline.Application.User.Commands.ChangePassword;
    using TrainsOnline.Application.User.Commands.CreateUser;
    using TrainsOnline.Application.User.Commands.UpdateUser;
    using TrainsOnline.Application.User.Queries.GetUserDetails;
    using TrainsOnline.Application.User.Queries.GetUsersList;
    using TrainsOnline.Domain.Jwt;

    [ServiceContract]
    public interface IUserSoapEndpointService : ISoapEndpointService
    {
        [OperationContract]
        [SoapAuthorize(Roles = Roles.User)]
        Task<IdResponse> Registration(CreateUserRequest user);

        [OperationContract]
        [SoapAuthorize(Roles = Roles.User)]
        Task<GetUserDetailResponse> GetCurrentUserDetails();

        [OperationContract]
        [SoapAuthorize(Roles = Roles.User)]
        Task<GetUserDetailResponse> GetUserDetails(IdRequest id);

        [OperationContract]
        [SoapAuthorize(Roles = Roles.User)]
        Task<Unit> UpdateUser(UpdateUserRequest user);

        [OperationContract]
        [SoapAuthorize(Roles = Roles.User)]
        Task<Unit> DeleteUser(IdRequest id);

        [OperationContract]
        [SoapAuthorize(Roles = Roles.User)]
        Task<Unit> ChangePassword(ChangePasswordRequest user);

        [OperationContract]
        [SoapAuthorize(Roles = Roles.User)]
        Task<GetUsersListResponse> GetUsersList();
    }
}