using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Microsoft.Extensions.Configuration;

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
                return  new 
            });
        }
    }
}
