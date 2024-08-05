using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mabieati.Features.Dashboard
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureDashboardFeature(this IServiceCollection services)
        {
            services.AddMediatR((cfg) => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddSingleton<Home.IDashboardView, Home.View>();
            services.AddSingleton<Home.ViewModel>();
            return services;
        }
    }
}
    