using Abp.Modules;
using Abp.Reflection.Extensions;

namespace MyCompanyName.AbpZeroTemplate
{
    [DependsOn(typeof(AbpZeroTemplateCoreSharedModule))]
    public class AbpZeroTemplateApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpZeroTemplateApplicationSharedModule).GetAssembly());
        }
    }
}