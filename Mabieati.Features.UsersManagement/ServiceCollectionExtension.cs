using Microsoft.Extensions.DependencyInjection;

namespace Mabieati.Features.UsersManagement
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureUsersManagementFeature(this IServiceCollection services)
        {
            services
                .AddSingleton<View>()
                .AddSingleton<ViewModel>();
            return services;
        }
    }
}
