namespace TrainsOnline.Application.Handlers.TicketHandlers.Queries.GetTicketDetails
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentValidation;
    using MediatR;
    using TrainsOnline.Application.DTO;
    using TrainsOnline.Application.Interfaces.UoW.Generic;
    using TrainsOnline.Domain.Entities;

    public class GetTicketDetailsQuery : IRequest<GetTicketDetailResponse>
    {
        public IdRequest Data { get; }

        public GetTicketDetailsQuery(IdRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<GetTicketDetailsQuery, GetTicketDetailResponse>
        {
            private readonly IPKPAppDbUnitOfWork _uow;
            private readonly IMapper _mapper;

            public Handler(IPKPAppDbUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<GetTicketDetailResponse> Handle(GetTicketDetailsQuery request, CancellationToken cancellationToken)
            {
                IdRequest data = request.Data;

                await new GetTicketDetailsQueryValidator(_uow).ValidateAndThrowAsync(data, cancellationToken: cancellationToken);

                Ticket entity = await _uow.TicketsRepository.GetByIdAsync(data.Id);

                return _mapper.Map<GetTicketDetailResponse>(entity);
            }
        }
    }
}
