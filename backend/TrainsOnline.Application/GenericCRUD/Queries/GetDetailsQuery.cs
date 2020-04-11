//namespace TrainsOnline.Application.Crosscutting.GenericCRUD.Queries
//{
//    using System.Threading;
//    using System.Threading.Tasks;
//    using AutoMapper;
//    using TrainsOnline.Application.Crosscutting.CommonDTO;
//    using TrainsOnline.Application.Crosscutting.Interfaces;
//    using TrainsOnline.Application.Crosscutting.Interfaces.UoW;
//    using TrainsOnline.Domain.Main.Entities;
//    using FluentValidation;
//    using MediatR;

//    public class GetDetailsQuery<TUoW, TDetailResponse> : IRequest<TDetailResponse>
//        where TUoW : IGenericUnitOfWork
//    {
//        public IdRequest Data { get; }

//        public GetDetailsQuery(IdRequest data)
//        {
//            Data = data;
//        }

//        public class Handler : IRequestHandler<GetDetailsQuery<TUoW, TDetailResponse>, TDetailResponse>
//        {
//            private readonly TUoW _uow;
//            private readonly IMapper _mapper;
//            private readonly IDataRightsService _drs;

//            public Handler(TUoW uow, IMapper mapper, IDataRightsService drs)
//            {
//                _uow = uow;
//                _mapper = mapper;
//                _drs = drs;
//            }

//            public async Task<TDetailResponse> Handle(GetDetailsQuery<TUoW, TDetailResponse> request, CancellationToken cancellationToken)
//            {
//                IdRequest data = request.Data;

//                _drs.ValidateUserId(data, x => x.Id);

//                await new GetUserDetailsQueryValidator(_uow).ValidateAndThrowAsync(data, cancellationToken: cancellationToken);

//                User entity = await _uow.UsersRepository.GetByIdAsync(data.Id);

//                return _mapper.Map<TDetailResponse>(entity);
//            }
//        }
//    }
//}
