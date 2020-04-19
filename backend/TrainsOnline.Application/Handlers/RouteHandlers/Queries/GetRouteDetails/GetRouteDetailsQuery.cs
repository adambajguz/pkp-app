namespace TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetRouteDetails
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Interfaces;
    using AutoMapper;
    using FluentValidation;
    using MediatR;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Interfaces.UoW.Generic;
    using TrainsOnline.Domain.Entities;

    public class GetRouteDetailsQuery : IRequest<GetRouteDetailResponse>
    {
        public IdRequest Data { get; }

        public GetRouteDetailsQuery(IdRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<GetRouteDetailsQuery, GetRouteDetailResponse>
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

            public async Task<GetRouteDetailResponse> Handle(GetRouteDetailsQuery request, CancellationToken cancellationToken)
            {
                IdRequest data = request.Data;

                _drs.ValidateUserId(data, x => x.Id);

                await new GetRouteDetailsQueryValidator(_uow).ValidateAndThrowAsync(data, cancellationToken: cancellationToken);

                Route entity = await _uow.RoutesRepository.GetByIdAsync(data.Id);

                return _mapper.Map<GetRouteDetailResponse>(entity);
            }
        }
    }
}
