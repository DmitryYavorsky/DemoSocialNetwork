using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DSN.Common.Mvc
{
    public static class Extensions
    {
        public static IMvcCoreBuilder AddCustomMvc(this IServiceCollection services)
        {
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                services.Configure<AppOptions>(configuration.GetSection("app"));
            }

            services.AddSingleton<IServiceId, ServiceId>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            return services.AddMvcCore();
        }
    }
}
