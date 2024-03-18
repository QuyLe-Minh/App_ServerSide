using Abp.Modules;
using Abp.Reflection.Extensions;

namespace MyCompanyName.AbpZeroTemplate
{
    public class AbpZeroTemplateCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpZeroTemplateCoreSharedModule).GetAssembly());
        }
    }
}