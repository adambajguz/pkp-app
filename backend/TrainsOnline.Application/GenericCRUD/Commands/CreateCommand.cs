//namespace TrainsOnline.Application.Crosscutting.GenericCRUD.Commands
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

//    public class CreateCommand<TUoW, TCreateRequest> : IRequest<IdResponse>
//        where TUoW : IGenericUnitOfWork
//    {
//        public TCreateRequest Data { get; }

//        public CreateCommand(TCreateRequest data)
//        {
//            Data = data;
//        }

//        public class Handler : IRequestHandler<CreateCommand<TUoW, TCreateRequest>, IdResponse>
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

//            public async Task<IdResponse> Handle(CreateCommand<TUoW, TCreateRequest> request, CancellationToken cancellationToken)
//            {
//                TCreateRequest data = request.Data;

//                await new CreateUserCommandValidator(_uow).ValidateAndThrowAsync(data, cancellationToken: cancellationToken);

//                User entity = _mapper.Map<User>(data);

//                _uow.UsersRepository.Add(entity);

//                await _uow.SaveChangesAsync(cancellationToken);

//                return new IdResponse(entity.Id);
//            }
//        }
//    }
//}
