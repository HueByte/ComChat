using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace CLI_Chat.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddServicesOfT<T>(this IServiceCollection serviceCollection)
        {
            var servicesOfT = typeof(Program).Assembly
                .GetTypes()
                .Where(x => !x.IsInterface && typeof(T).IsAssignableFrom(x));

            foreach (var service in servicesOfT)
            {
                serviceCollection.AddSingleton(service);
            }

            return serviceCollection;
        }
    }
}