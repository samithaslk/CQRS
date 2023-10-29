using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dot7.Architecture.Application.Authenticate.Services
{
    public interface IConfigurationSettingsService
    {
        public string AccessTokenKey { get; }
        public int? AccessTokenExpirySeconds { get; }
        public double? RefreshTokenExpiryDays { get; }
        public string SeqUrl { get; }
        public string SeqApiKey { get; }
    }
}
