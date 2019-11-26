using System.Reflection;
using Autofac;
using DSN.Common.Handlers;
using DSN.Common.Mongo;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using RawRabbit.Configuration;


namespace DSN.Common.RabbitMq
{
    public static class Extensions
    {
        private static string sectionName = "rabbitMq";
        public static IBusSubscriber UseRabbitMq(this IApplicationBuilder app)
            => new BusSubscriber(app);
        public static void AddRabbitMq(this ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                var options = configuration.GetOptions<RabbitMqOptions>(sectionName);
                return options;

            }).SingleInstance();

            builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                var options = configuration.GetOptions<RawRabbitConfiguration>("rabbitMq");
                return options;
            }).SingleInstance();

            var assembly = Assembly.GetCallingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(IEventHandler<>)).InstancePerDependency();
            builder.RegisterAssemblyTypes(assembly).AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerDependency();
            builder.RegisterType<Handler>().As<IHandler>().InstancePerDependency();
            builder.RegisterType<BusPublisher>().As<IBusPublisher>().InstancePerDependency();
         

        }

    }
}
