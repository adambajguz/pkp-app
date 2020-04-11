namespace TrainsOnline.Application.Main.Authentication.Queries.GetValidToken
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.Common.Interfaces.UoW;
    using Domain.Entities;
    using Domain.Jwt;
    using FluentValidation;
    using MediatR;

    public class GetValidTokenQuery : IRequest<JwtTokenModel>
    {
        public LoginRequest Data { get; }

        public GetValidTokenQuery(LoginRequest login)
        {
            Data = login;
        }

        public class Handler : IRequestHandler<GetValidTokenQuery, JwtTokenModel>
        {
            private readonly IMainDbUnitOfWork _uow;
            private readonly IJwtService _jwt;

            public Handler(IMainDbUnitOfWork uow, IJwtService jwt)
            {
                _uow = uow;
                _jwt = jwt;
            }

            public async Task<JwtTokenModel> Handle(GetValidTokenQuery request, CancellationToken cancellationToken)
            {
                LoginRequest data = request.Data;

                User user = await _uow.UsersRepository.FirstOrDefaultAsync(x => x.Email.Equals(data.Email));
                GetValidTokenQueryValidator.Model validationModel = new GetValidTokenQueryValidator.Model(data, user);

                await new GetValidTokenQueryValidator().ValidateAndThrowAsync(validationModel, cancellationToken: cancellationToken);

                string[] roles = Roles.BuildArray(Roles.User);
                if (user.IsAdmin)
                    roles = Roles.BuildArray(Roles.User, Roles.Admin);

                return _jwt.GenerateJwtToken(user.Email, user.Id, roles);
            }
        }
    }
}
