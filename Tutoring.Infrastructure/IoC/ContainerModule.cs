using Autofac;
using Microsoft.Extensions.Configuration;
using Tutoring.Infrastructure.IoC.Modules;
using Tutoring.Infrastructure.Mappers;

namespace Tutoring.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterInstance(AutoMapperConfig.Initialize())
                   .SingleInstance();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule(new SettingsModule(_configuration));
        }
    }
}
