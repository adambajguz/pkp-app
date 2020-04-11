namespace TrainsOnline.Application.Main.User.Queries.GetUsers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces.UoW;
    using MediatR;

    public class GetUsersQuery : IRequest<GetUsersListResponse>
    {
        public class Handler : IRequestHandler<GetUsersQuery, GetUsersListResponse>
        {
            private readonly IMainDbUnitOfWork _uow;

            public Handler(IMainDbUnitOfWork uow)
            {
                _uow = uow;
            }

            public async Task<GetUsersListResponse> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {
                return new GetUsersListResponse
                {
                    Users = await _uow.UsersRepository.ProjectTo<GetUsersListResponse.UserLookupModel>(cancellationToken: cancellationToken)
                };
            }
        }
    }
}

