using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dot7.Architecture.Application.Authenticate
{
    public class GetAuthenticateRequest : IRequest<GetAuthenticateResponse>
    {
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
