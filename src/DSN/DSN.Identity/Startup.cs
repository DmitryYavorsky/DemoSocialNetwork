using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DSN.Common.Authentication;
using DSN.Common.Mongo;
using DSN.Common.Mvc;
using DSN.Common.Swagger;
using DSN.Identity.Domain;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using IApplicationLifetime = Microsoft.AspNetCore.Hosting.IApplicationLifetime;

namespace DSN.Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IContainer Container { get; private set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCustomMvc().AddFluentValidation();
            //services.AddSwaggerDocs();
            
            services.AddJwt();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", cors =>
                    cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly()).AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddMongo();
            builder.AddMongoRepository<User>("Users");
            builder.RegisterType<PasswordHasher<User>>().As<IPasswordHasher<User>>();
            Container = builder.Build();
            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("CorsPolicy");
            //app.UseSwaggerDocs();
            app.UseErrorHandler();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseAccessTokenValidator();
            //app.UseMvc();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //applicationLifetime.ApplicationStarted.Register(() =>
            //{
            //    Container.Dispose();
            //});

        }
    }
}
