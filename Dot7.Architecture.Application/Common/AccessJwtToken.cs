using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dot7.Architecture.Application.Common
{
    public class AccessJwtToken
    {
        public string Token { get; set; } = string.Empty;
        public int ExpirySeconds { get; set; }
    }
}
