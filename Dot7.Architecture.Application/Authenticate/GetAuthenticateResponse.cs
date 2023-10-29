using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dot7.Architecture.Application.Authenticate
{
    public class GetAuthenticateResponse
    {
        public string AccessToken { get; set; } = string.Empty;

        public int Expiry { get; set; }

        public string RefreshToken { get; set; } = string.Empty;
    }
}
