//namespace TrainsOnline.Application.Crosscutting.GenericCRUD.Commands
//{
//    using System.Threading;
//    using System.Threading.Tasks;
//    using AutoMapper;
//    using TrainsOnline.Application.Crosscutting.Interfaces;
//    using TrainsOnline.Application.Crosscutting.Interfaces.UoW;
//    using TrainsOnline.Domain.Main.Entities;
//    using FluentValidation;
//    using MediatR;

//    public class UpdateCommand<TUoW, TUpdateRequest> : IRequest
//        where TUoW : IGenericUnitOfWork
//    {
//        public TUpdateRequest Data { get; }

//        public UpdateCommand(TUpdateRequest data)
//        {
//            Data = data;
//        }

//        public class Handler : IRequestHandler<UpdateCommand<TUoW, TUpdateRequest>, Unit>
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

//            public async Task<Unit> Handle(UpdateCommand<TUoW, TUpdateRequest> request, CancellationToken cancellationToken)
//            {
//                TUpdateRequest data = request.Data;

//                _drs.ValidateUserId(data, x => x.Id);

//                User user = await _uow.UsersRepository.GetByIdAsync(data.Id);
//                UpdateUserCommandValidator.Model validationModel = new UpdateUserCommandValidator.Model(data, user);

//                await new UpdateUserCommandValidator(_uow).ValidateAndThrowAsync(validationModel, cancellationToken: cancellationToken);

//                _mapper.Map(data, user);
//                _uow.UsersRepository.Update(user);

//                await _uow.SaveChangesAsync(cancellationToken);

//                return await Unit.Task;
//            }
//        }
//    }
//}
