using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using DSN.Common.Mongo;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DSN.AccountService.Domain;
using System;
using DSN.Common.Mvc;
using DSN.Common.RabbitMq;
using DSN.AccountService.Messages.Events;

namespace DSN.AccountService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IContainer Container { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCustomMvc();
            services.AddControllers();
            //services.AddJwt();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", cors =>
                    cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddMediatR(Assembly.GetExecutingAssembly());
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.AddMongo();
            builder.AddMongoRepository<Account>("Accounts");
            builder.AddRabbitMq();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly()).AsImplementedInterfaces();
            Container = builder.Build();
            return new AutofacServiceProvider(Container);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseRabbitMq().SubscribeEvent<SignedUp>(@namespace: "identity");
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
