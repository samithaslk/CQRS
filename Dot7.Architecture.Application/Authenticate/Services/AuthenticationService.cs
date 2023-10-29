using Dot7.Architecture.Application.Common;
using Dot7.Architecture.Application.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dot7.Architecture.Application.Authenticate.Services
{


    public class AuthenticationService: IAuthenticationService
    {
        private readonly IMyDbContext _dataContext;
        private readonly IConfigurationSettingsService _configurationService;
        public AuthenticationService(IMyDbContext context, IConfigurationSettingsService configurationService)
        {
            _dataContext = context;
            _configurationService = configurationService;
        }
        public AccessJwtToken GenerateUserAccessJwtToken(Domain.Entities.User user)
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
            var key = Encoding.ASCII.GetBytes(_configurationService.AccessTokenKey);
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
