//namespace TrainsOnline.Application.Crosscutting.GenericCRUD.Commands
//{
//    using System.Threading;
//    using System.Threading.Tasks;
//    using TrainsOnline.Application.Crosscutting.CommonDTO;
//    using TrainsOnline.Application.Crosscutting.Interfaces;
//    using TrainsOnline.Application.Crosscutting.Interfaces.UoW;
//    using TrainsOnline.Domain.Main.Entities;
//    using FluentValidation;
//    using MediatR;

//    public class DeleteCommand<TUoW> : IRequest
//        where TUoW : IGenericUnitOfWork
//    {
//        public IdRequest Data { get; }

//        public DeleteCommand(IdRequest data)
//        {
//            Data = data;
//        }

//        public class Handler : IRequestHandler<DeleteCommand<TUoW>, Unit>
//        {
//            private readonly TUoW _uow;
//            private readonly IDataRightsService _drs;

//            public Handler(TUoW uow, IDataRightsService drs)
//            {
//                _uow = uow;
//                _drs = drs;
//            }

//            public async Task<Unit> Handle(DeleteCommand<TUoW> request, CancellationToken cancellationToken)
//            {
//                IdRequest data = request.Data;

//                _drs.ValidateUserId(data, x => x.Id);

//                User user = await _uow.UsersRepository.GetByIdAsync(data.Id);
//                DeleteUserCommandValidator.Model validationModel = new DeleteUserCommandValidator.Model(data, user);

//                await new DeleteUserCommandValidator().ValidateAndThrowAsync(validationModel, cancellationToken: cancellationToken);

//                _uow.UsersRepository.Remove(user);
//                await _uow.SaveChangesAsync();

//                return await Unit.Task;
//            }
//        }
//    }
//}
