using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using Tutoring.Infrastructure.Commands;
using Tutoring.Infrastructure.Commands.Users;
using Tutoring.Infrastructure.Handlers.Users;

namespace Tutoring.Infrastructure.IoC.Modules
{
    public class CommandModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(CommandModule)
                            .GetTypeInfo()
                            .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                   .AsClosedTypesOf(typeof(ICommandHandler<>))
                   .InstancePerLifetimeScope();

            builder.RegisterType<CommandDispatcher>()
                    .As<ICommandDispatcher>()
                    .InstancePerLifetimeScope();
        }
    }
}
