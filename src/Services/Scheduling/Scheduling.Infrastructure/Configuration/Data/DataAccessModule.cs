﻿using Autofac;
using BuildingBlocks.Infrastructure;
using BuildingBlocks.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Scheduling.Infrastructure.Configuration.Data
{
    public class DataAccessModule : Module
    {
        private readonly string connectionString;

        public DataAccessModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<SqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", connectionString)
                .InstancePerLifetimeScope();

            builder
                .Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<SchedulingContext>();
                    dbContextOptionsBuilder.UseSqlServer(connectionString);

                    return new SchedulingContext(dbContextOptionsBuilder.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();

            var infrastructureAssembly = typeof(SchedulingContext).Assembly;

            builder.RegisterAssemblyTypes(infrastructureAssembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .FindConstructorsWith(new AllConstructorFinder());
        }
    }
}
