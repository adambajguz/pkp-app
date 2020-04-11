//namespace TrainsOnline.Application.Crosscutting.GenericCRUD.Queries
//{
//    using System.Threading;
//    using System.Threading.Tasks;
//    using TrainsOnline.Application.Crosscutting.Interfaces.UoW;
//    using MediatR;

//    public class GetListQuery<TUoW, TListResponse, TListItemModel> : IRequest<TListResponse>
//        where TUoW : IGenericUnitOfWork
//    {
//        public class Handler : IRequestHandler<GetListQuery<TUoW, TListResponse, TListItemModel>, TListResponse>
//        {
//            private readonly TUoW _uow;

//            public Handler(TUoW uow)
//            {
//                _uow = uow;
//            }

//            public async Task<TListResponse> Handle(GetListQuery<TUoW, TListResponse, TListItemModel> request, CancellationToken cancellationToken)
//            {
//                return new TListResponse
//                {
//                    Users = await _uow.UsersRepository.ProjectTo<TListItemModel>(cancellationToken: cancellationToken)
//                };
//            }
//        }
//    }
//}

