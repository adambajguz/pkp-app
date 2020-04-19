namespace TrainsOnline.Api.SoapEndpoints
{
    using System.ServiceModel;
    using System.Threading.Tasks;
    using MediatR;
    using TrainsOnline.Api.CustomMiddlewares;
    using TrainsOnline.Api.SoapEndpoints.Core;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.UserHandlers.Commands.ChangePassword;
    using TrainsOnline.Application.UserHandlers.Commands.CreateUser;
    using TrainsOnline.Application.UserHandlers.Commands.UpdateUser;
    using TrainsOnline.Application.UserHandlers.Queries.GetUserDetails;
    using TrainsOnline.Application.UserHandlers.Queries.GetUsersList;
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