namespace TrainsOnline.Application.Handlers.StationHandlers.Queries.GetStationDetails
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

    public class GetStationDetailsQuery : IRequest<GetStationDetailResponse>
    {
        public IdRequest Data { get; }

        public GetStationDetailsQuery(IdRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<GetStationDetailsQuery, GetStationDetailResponse>
        {
            private readonly IPKPAppDbUnitOfWork _uow;
            private readonly IMapper _mapper;

            public Handler(IPKPAppDbUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<GetStationDetailResponse> Handle(GetStationDetailsQuery request, CancellationToken cancellationToken)
            {
                IdRequest data = request.Data;

                await new GetStationDetailsQueryValidator(_uow).ValidateAndThrowAsync(data, cancellationToken: cancellationToken);

                Station entity = await _uow.StationsRepository.GetByIdAsync(data.Id);

                return _mapper.Map<GetStationDetailResponse>(entity);
            }
        }
    }
}
