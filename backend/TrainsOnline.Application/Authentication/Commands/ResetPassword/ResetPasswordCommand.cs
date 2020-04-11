using TrainsOnline.Application.Common.Helpers;
using TrainsOnline.Application.Common.Interfaces;
using TrainsOnline.Application.Common.Interfaces.UoW;
using TrainsOnline.Application.Exceptions;

namespace TrainsOnline.Application.Authentication.Commands.ResetPassword
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Helpers;
    using Application.Common.Interfaces;
    using Application.Common.Interfaces.UoW;
    using Application.Exceptions;
    using Domain.Entities;
    using Domain.Jwt;
    using FluentValidation;
    using MediatR;

    public class ResetPasswordCommand : IRequest
    {
        public ResetPasswordRequest Data { get; }

        public ResetPasswordCommand(ResetPasswordRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<ResetPasswordCommand>
        {
            private readonly IMainDbUnitOfWork _uow;
            private readonly IJwtService _jwt;

            public Handler(IMainDbUnitOfWork uow, IJwtService jwt)
            {
                _uow = uow;
                _jwt = jwt;
            }

            public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
            {
                ResetPasswordRequest data = request.Data;

                if (!_jwt.IsTokenStringValid(data.Token) || !_jwt.IsRoleInToken(data.Token, Roles.ResetPassword))
                    throw new ForbiddenException();

                Guid userId = _jwt.GetUserIdFromToken(data.Token);
                User user = await _uow.UsersRepository.FirstOrDefaultAsync(x => x.Id.Equals(userId));

                ResetPasswordCommandValidator.Model validationData = new ResetPasswordCommandValidator.Model(data, user);
                await new ResetPasswordCommandValidator().ValidateAndThrowAsync(validationData, cancellationToken: cancellationToken);

                user.Password = PasswordHelper.CreateHash(data.Password);
                _uow.UsersRepository.Update(user);
                await _uow.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
