namespace TrainsOnline.Api.SoapEndpoints
{
    using System.ServiceModel;
    using System.Threading.Tasks;
    using MediatR;
    using TrainsOnline.Api.CustomMiddlewares;
    using TrainsOnline.Api.SoapEndpoints.Core;
    using TrainsOnline.Application.DTO;
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
        Task<IdResponse> Registration(CreateUserRequest user);

        [OperationContract]
        [SoapAuthorize(Roles = Roles.User)]
        Task<GetUserDetailResponse> GetCurrentUserDetails();

        [OperationContract]
        Task<GetUserDetailResponse> GetUserDetails(IdRequest id);

        [OperationContract]
        Task<Unit> UpdateUser(UpdateUserRequest user);

        [OperationContract]
        Task<Unit> DeleteUser(IdRequest id);

        [OperationContract]
        Task<Unit> ChangePassword(ChangePasswordRequest user);

        [OperationContract]
        Task<GetUsersListResponse> GetUsersList();
    }
}