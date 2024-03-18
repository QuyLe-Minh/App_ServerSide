
namespace Abp.AspNetZeroCore
{
    using Abp.Configuration.Startup;
    using System;
    using System.Runtime.CompilerServices;

    public static class AspNetZeroConfigurationExtensions
    {
        public static AspNetZeroConfiguration AspNetZero(this IModuleConfigurations configurations) =>
            configurations.AbpConfiguration.Get<AspNetZeroConfiguration>();
    }
}
