namespace TrainsOnline.Application.Authentication.Queries.GetResetPasswordToken
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.Common.Interfaces.UoW;
    using Domain.Entities;
    using Domain.Jwt;
    using FluentValidation;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using TrainsOnline.Common;

    public class GetResetPasswordTokenQuery : IRequest<string>
    {
        public SendResetPasswordRequest Data { get; }

        public GetResetPasswordTokenQuery(SendResetPasswordRequest data)
        {
            Data = data;
        }

        public class Handler : IRequestHandler<GetResetPasswordTokenQuery, string>
        {
            private readonly IPKPAppDbUnitOfWork _uow;
            private readonly IHttpContextAccessor _context;
            private readonly IJwtService _jwt;
            private readonly IEmailService _email;

            public Handler(IPKPAppDbUnitOfWork uow, IHttpContextAccessor context, IJwtService jwt, IEmailService email)
            {
                _context = context;
                _uow = uow;
                _jwt = jwt;
                _email = email;
            }

            public async Task<string> Handle(GetResetPasswordTokenQuery request, CancellationToken cancellationToken)
            {
                SendResetPasswordRequest data = request.Data;

                Uri uri = GetAbsoluteUri();

                await new GetResetPasswordTokenQueryValidator().ValidateAndThrowAsync(data, cancellationToken: cancellationToken);

                User user = await _uow.UsersRepository.FirstOrDefaultAsync(x => x.Email.Equals(data.Email));

                if (user != null)
                {
                    string token = _jwt.GenerateJwtToken(user.Email, user.Id, Roles.BuildArray(Roles.ResetPassword)).Token;
                    await _email.SendEmail(user.Email, "Reset Password", uri.AbsoluteUri + "/" + token);

#pragma warning disable CS0162 // Unreachable code detected
                    if (GlobalAppConfig.DEV_MODE)
                        return uri.AbsoluteUri + "/" + token;
#pragma warning restore CS0162 // Unreachable code detected
                }

                return "e-mail sent";
            }

            private Uri GetAbsoluteUri()
            {
                HttpRequest request = _context.HttpContext.Request;
                UriBuilder uriBuilder = new UriBuilder
                {
                    Scheme = request.Scheme,
                    Host = request.Host.Host,
                    Path = request.Path.ToString(),
                    Query = request.QueryString.ToString()
                };

                return uriBuilder.Uri;
            }
        }
    }

}
