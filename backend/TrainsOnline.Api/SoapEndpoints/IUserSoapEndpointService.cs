namespace TrainsOnline.Api.SoapEndpoints
{
    using System.ServiceModel;
    using System.Threading.Tasks;
    using MediatR;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.User.Commands.ChangePassword;
    using TrainsOnline.Application.User.Commands.CreateUser;
    using TrainsOnline.Application.User.Commands.UpdateUser;
    using TrainsOnline.Application.User.Queries.GetUserDetails;
    using TrainsOnline.Application.User.Queries.GetUsersList;

    [ServiceContract]
    public interface IUserSoapEndpointService
    {
        [OperationContract]
        Task<IdResponse> Registration(CreateUserRequest user);

        [OperationContract]
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