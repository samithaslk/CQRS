using Microsoft.Extensions.Configuration;

namespace Dot7.Architecture.Application.Authenticate.Services
{
    public class ConfigurationSettingsService : IConfigurationSettingsService
    {
        private readonly IConfiguration _configuration;
        public ConfigurationSettingsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string AccessTokenKey => GetSettingString("Settings:AccessTokenKey");
        public int? AccessTokenExpirySeconds => GetSettingInt("Settings:AccessTokenExpirySeconds");
        public double? RefreshTokenExpiryDays => GetSettingDouble("Settings:RefreshTokenExpiryDays");
        public string SeqUrl => GetSettingString("Settings:SeqUrl");
        public string SeqApiKey => GetSettingString("Settings:SeqApiKey"); 
        private string GetSettingString(string setting)
        {
            return _configuration[setting] ?? string.Empty;
        }

        private double? GetSettingDouble(string setting)
        {
            var stringValue = GetSettingString(setting);

            var isSuccess = double.TryParse(stringValue, out var value);

            return isSuccess ? value : null;
        }

        private int? GetSettingInt(string setting)
        {
            var stringValue = GetSettingString(setting);

            var isSuccess = int.TryParse(stringValue, out var value);

            return isSuccess ? value : null;
        }
    }
}
