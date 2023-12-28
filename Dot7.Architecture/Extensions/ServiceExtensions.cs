

using Dot7.Architecture.Application.Log;

namespace Dot7.Architecture.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services) => services.AddSingleton<ILoggerManager, LoggerManager>();  

    }
}
