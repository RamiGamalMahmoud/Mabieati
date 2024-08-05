using Mabieati.Features.Auth.Login;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mabieati.Features.Auth
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ConfigureAuthFeature(this IServiceCollection services)
        {
            services.AddMediatR((cfg) => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient<ILoginView, View>();
            services.AddSingleton<ViewModel>();
            return services;
        }
    }
}
