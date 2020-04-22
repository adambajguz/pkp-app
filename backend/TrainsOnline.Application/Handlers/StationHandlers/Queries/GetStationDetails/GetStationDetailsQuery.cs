namespace TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationDetails
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentValidation;
    using MediatR;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Interfaces.UoW.Generic;
    using TrainsOnline.Domain.Entities;

    public class GetStationDetailsQuery : IRequest<GetStationDetailsResponse>
    {
        public IdRequest Data { get; }

        public GetStationDetailsQuery(IdRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<GetStationDetailsQuery, GetStationDetailsResponse>
        {
            private readonly IPKPAppDbUnitOfWork _uow;
            private readonly IMapper _mapper;

            public Handler(IPKPAppDbUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<GetStationDetailsResponse> Handle(GetStationDetailsQuery request, CancellationToken cancellationToken)
            {
                IdRequest data = request.Data;

                await new GetStationDetailsQueryValidator(_uow).ValidateAndThrowAsync(data, cancellationToken: cancellationToken);

                Station entity = await _uow.StationsRepository.GetByIdWithRelatedAsync(data.Id, x => x.Departures);
                return _mapper.Map<GetStationDetailsResponse>(entity);
            }
        }
    }
}
