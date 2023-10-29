using AutoMapper;
using Dot7.Architecture.Application.Authenticate.Services;
using Dot7.Architecture.Application.Books.GetAllBooks;
using Dot7.Architecture.Application.Common;
using Dot7.Architecture.Application.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dot7.Architecture.Application.Authenticate
{
    public class GetAuthenticateRequestHandler : IRequestHandler<GetAuthenticateRequest, GetAuthenticateResponse>
    {
        private readonly IMyDbContext _myDbContext;
        private readonly IMapper _mapper;
        private readonly IAuthenticationService _authenticationService;
        public GetAuthenticateRequestHandler(IMyDbContext myDbContext,
        IMapper mapper, IAuthenticationService authenticationService)
        {
            _myDbContext = myDbContext;
            _mapper = mapper;
            _authenticationService = authenticationService;
        }
   
        public async Task<GetAuthenticateResponse> Handle(GetAuthenticateRequest request, CancellationToken cancellationToken)
        {
            var user = await _myDbContext.LibraryUser
           .FirstOrDefaultAsync(x => x.Username == request.Username, cancellationToken);

            var hashedPassword = Security.HashPassword(user.Username, request.Password);
            var accessToken = _authenticationService.GenerateUserAccessJwtToken(user);

            var authenticateResponse = new GetAuthenticateResponse
            {
                AccessToken = accessToken.Token,
                Expiry = accessToken.ExpirySeconds,
                RefreshToken = accessToken.Token
            };

            return authenticateResponse;
        }

        private AccessJwtToken GenerateUserAccessJwtToken(Domain.Entities.User user)
        {
            return GenerateAccessJwtToken("Üser", user.Id.ToString(), user.Username);
        }
        private AccessJwtToken GenerateAccessJwtToken(string role, string nameIdentifier, string clientCode)
        {
            //if (_configurationSettingsService.AccessTokenExpirySeconds == null)
            //    throw new EmptyOrInvalidConfigurationSettingException("AccessTokenExpirySeconds");

            //if (_configurationSettingsService.AccessTokenKey == null)
            //    throw new EmptyOrInvalidConfigurationSettingException("AccessTokenKey");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("ljsndfljsdfksdfkhbgdsak");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, nameIdentifier),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.Name, clientCode)
            }),
                Expires = DateTime.UtcNow
                    .AddSeconds(3600),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AccessJwtToken
            {
                Token = tokenHandler.WriteToken(token),
                ExpirySeconds = Convert.ToInt32(3600)
            };
        }
    }
}
