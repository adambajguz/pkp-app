namespace TrainsOnline.Application.GenericCRUD.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces.UoW;
    using Application.Interfaces;
    using AutoMapper;
    using Domain.Entities;
    using FluentValidation;
    using MediatR;
    using TrainsOnline.Application.Common.DTO;
    using TrainsOnline.Application.User.Queries.GetUserDetails;

    public class GetDetailsQuery : IRequest<GetUserDetailResponse>
    {
        public IdRequest Data { get; }

        public GetDetailsQuery(IdRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<GetUserDetailsQuery, GetUserDetailResponse>
        {
            private readonly IPKPAppDbUnitOfWork _uow;
            private readonly IMapper _mapper;
            private readonly IDataRightsService _drs;

            public Handler(IPKPAppDbUnitOfWork uow, IMapper mapper, IDataRightsService drs)
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
