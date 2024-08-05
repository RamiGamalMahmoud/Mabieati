using Microsoft.Extensions.DependencyInjection;

namespace Mabieati.Data
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureDataService(this IServiceCollection services)
        {
            services.AddSingleton(new AppDbContextFactory("Data Source = .\\Data\\mabieati.db"));
            return services;
        }
    }
}
