namespace TrainsOnline.Api.SoapEndpoints
{
    using System;
    using System.Threading.Tasks;
    using MediatR;
    using TrainsOnline.Api.SoapEndpoints.Core;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Interfaces;
    using TrainsOnline.Application.Route.Commands.CreateRoute;
    using TrainsOnline.Application.Route.Commands.DeleteRoute;
    using TrainsOnline.Application.Route.Commands.UpdateRoute;
    using TrainsOnline.Application.Route.Queries.GetRouteDetails;
    using TrainsOnline.Application.Route.Queries.GetRoutesList;
    using TrainsOnline.Application.User.Commands.ChangePassword;
    using TrainsOnline.Application.User.Commands.CreateUser;
    using TrainsOnline.Application.User.Commands.DeleteUser;
    using TrainsOnline.Application.User.Commands.UpdateUser;
    using TrainsOnline.Application.User.Queries.GetUserDetails;
    using TrainsOnline.Application.User.Queries.GetUsersList;

    [SoapRoute("[baseUrl]/user", "User", "Create, update and get user")]
    public class UserSoapEndpointService : IUserSoapEndpointService
    {
        protected IMediator Mediator { get; }
        protected IDataRightsService DataRights { get; }

        public UserSoapEndpointService(IMediator mediator, IDataRightsService dataRights)
        {
            Mediator = mediator;
            DataRights = dataRights;
        }

        public async Task<IdResponse> Registration(CreateUserRequest user)
        {
            return await Mediator.Send(new CreateUserCommand(user));
        }

        public async Task<GetUserDetailResponse> GetCurrentUserDetails()
        {
            IdRequest data = new IdRequest((Guid)DataRights.GetUserIdFromContext()!);

            return await Mediator.Send(new GetUserDetailsQuery(data));
        }

        public async Task<GetUserDetailResponse> GetUserDetails(IdRequest id)
        {
            return await Mediator.Send(new GetUserDetailsQuery(id));
        }

        public async Task<Unit> UpdateUser(UpdateUserRequest user)
        {
            return await Mediator.Send(new UpdateUserCommand(user));
        }

        public async Task<Unit> DeleteUser(IdRequest id)
        {
            return await Mediator.Send(new DeleteUserCommand(id));
        }

        public async Task<Unit> ChangePassword(ChangePasswordRequest user)
        {
            return await Mediator.Send(new ChangePasswordCommand(user));
        }

        public async Task<GetUsersListResponse> GetUsersList()
        {
            return await Mediator.Send(new GetUsersListQuery());
        }
    }
}
