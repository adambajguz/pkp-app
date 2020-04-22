namespace TrainsOnline.Application.Handlers.RouteHandlers.Queries.GetRouteDetails
{
    using System.Threading;
    using System.Threading.Tasks;
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

            public Handler(IPKPAppDbUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<GetRouteDetailResponse> Handle(GetRouteDetailsQuery request, CancellationToken cancellationToken)
            {
                IdRequest data = request.Data;

                await new GetRouteDetailsQueryValidator(_uow).ValidateAndThrowAsync(data, cancellationToken: cancellationToken);

                Route entity = await _uow.RoutesRepository.GetByIdWithRelatedAsync(data.Id, x => x.From, x => x.To);

                return _mapper.Map<GetRouteDetailResponse>(entity);
            }
        }
    }
}
