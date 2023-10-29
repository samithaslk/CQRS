using Dot7.Architecture.Application.Common;
using MediatR;

namespace Dot7.Architecture.Application.Authenticate.Services
{
    public interface IAuthenticationService : IRequest
    {
        public AccessJwtToken GenerateUserAccessJwtToken(Domain.Entities.User user);
    }
}
