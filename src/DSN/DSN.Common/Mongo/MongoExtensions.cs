using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using DSN.Common.Types;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DSN.Common.Mongo
{
    public static class MongoExtensions
    {
        private static readonly string SectionName = "mongo";
        public static void AddMongo(this ContainerBuilder builder)
        {

            builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                var section = configuration.GetSection(SectionName);
                var options = section.Get<MongoDbOptions>();
                return options;
            }).SingleInstance();

            builder.Register(context =>
            {
                var mongoOptions = context.Resolve<MongoDbOptions>();
                return new MongoClient(mongoOptions.ConnectionString);
            }).SingleInstance();

            builder.Register(context =>
            {
                var options = context.Resolve<MongoDbOptions>();
                var mongoClient = context.Resolve<MongoClient>();
                return mongoClient.GetDatabase(options.Database);
            }).InstancePerLifetimeScope();

            builder.RegisterType<MongoDbInitializer>().As<IMongoDbInitializer>().InstancePerLifetimeScope();
            builder.RegisterType<MongoDbSeeder>().As<IMongoDbSeeder>().InstancePerLifetimeScope();

        }

        public static void AddMongoRepository<TEntity>(this ContainerBuilder builder, string collectionName)
            where TEntity : IIdentifiable
            => builder.Register(ctx => new MongoRepository<TEntity>(ctx.Resolve<IMongoDatabase>(), collectionName))
                .As<IMongoRepository<TEntity>>().InstancePerLifetimeScope(); 
    }
}
