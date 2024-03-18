using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.AspNetZeroCore;
using Abp.AspNetZeroCore.Licensing;

namespace Abp.AspNetZeroCore
{
    public class AbpAspNetZeroCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            base.IocManager.Register<AspNetZeroConfiguration>();
        }

        public override void Initialize()
        {
            base.IocManager.RegisterAssemblyByConvention(typeof(AbpAspNetZeroCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            base.IocManager.Resolve<AspNetZeroLicenseChecker>().Check();
        }
    }
}
