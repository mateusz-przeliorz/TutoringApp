using Autofac;
using Microsoft.Extensions.Configuration;
using Tutoring.Infrastructure.Extensions;
using Tutoring.Infrastructure.Settings;

namespace Tutoring.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<UserSettings>())
                                        .SingleInstance();
        }
    }
}
