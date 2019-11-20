using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DSN.Common.Authentication
{
    public static class AuthExtensions
    {
        private static readonly string SectionName = "jwt";

        public static void AddJwt(this IServiceCollection services)
        {
            IConfiguration configuration;
            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            var section = configuration.GetSection(SectionName);
            var options = section.Get<JwtOptions>();
            services.Configure<JwtOptions>(section);
            services.AddSingleton(options);
            services.AddTransient<IJwtHandler, JwtHandler>();
        }

        public static long ToTimestamp(this DateTime date)
        {
            var centuryBegin = new DateTime(1970,1,1,0,0,0,DateTimeKind.Utc);
            var expectedDate = date.Subtract(new TimeSpan(centuryBegin.Ticks));
            return expectedDate.Ticks / 10000;

        }
    }
}
