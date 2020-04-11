namespace TrainsOnline.Application.Main.User.Queries.GetUserDetails
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Application.Common.Interfaces.UoW;
    using Application.CommonDTO;
    using Application.Interfaces;
    using Domain.Entities;
    using FluentValidation;
    using MediatR;

    public class GetUserDetailsQuery : IRequest<GetUserDetailResponse>
    {
        public IdRequest Data { get; }

        public GetUserDetailsQuery(IdRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<GetUserDetailsQuery, GetUserDetailResponse>
        {
            private readonly IMainDbUnitOfWork _uow;
            private readonly IMapper _mapper;
            private readonly IDataRightsService _drs;

            public Handler(IMainDbUnitOfWork uow, IMapper mapper, IDataRightsService drs)
            {
                _uow = uow;
                _mapper = mapper;
                _drs = drs;
            }

            public async Task<GetUserDetailResponse> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
            {
                IdRequest data = request.Data;

                _drs.ValidateUserId(data, x => x.Id);

                await new GetUserDetailsQueryValidator(_uow).ValidateAndThrowAsync(data, cancellationToken: cancellationToken);

                User entity = await _uow.UsersRepository.GetByIdAsync(data.Id);

                return _mapper.Map<GetUserDetailResponse>(entity);
            }
        }
    }
}
