﻿namespace TrainsOnline.Application.GenericCRUD.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces.UoW;
    using MediatR;
    using TrainsOnline.Application.User.Queries.GetUsersList;

    public class GetListQuery : IRequest<GetUsersListResponse>
    {
        public GetListQuery()
        {

        }

        public class Handler : IRequestHandler<GetUsersListQuery, GetUsersListResponse>
        {
            private readonly IPKPAppDbUnitOfWork _uow;

            public Handler(IPKPAppDbUnitOfWork uow)
            {
                _uow = uow;
            }

            public async Task<GetUsersListResponse> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
            {
                return new GetUsersListResponse
                {
                    Users = await _uow.UsersRepository.ProjectTo<GetUsersListResponse.UserLookupModel>(cancellationToken: cancellationToken)
                };
            }
        }
    }
}

