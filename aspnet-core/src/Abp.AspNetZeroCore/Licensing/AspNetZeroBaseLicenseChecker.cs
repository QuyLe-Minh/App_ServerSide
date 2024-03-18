
namespace Abp.AspNetZeroCore.Licensing
{
    using Abp.Zero.Configuration;
    using Abp.AspNetZeroCore;
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public abstract class AspNetZeroBaseLicenseChecker
    {
        private readonly IAbpZeroConfig _abpZeroConfig;

        protected AspNetZeroBaseLicenseChecker(AspNetZeroConfiguration configuration, IAbpZeroConfig abpZeroConfig, string configFilePath = "")
        {
        }

        protected bool CompareProjectName(string hashedProjectName) =>
            true;

        protected string GetAssemblyName() =>
            this._abpZeroConfig.EntityTypes.User.Assembly.GetName().Name;

        protected abstract string GetHashedValueWithoutUniqueComputerId(string str);
        protected string GetLicenseCode() =>
            this.LicenseCode;

        protected string GetLicenseController() =>
            "WebProject";

        protected abstract string GetSalt();
        protected bool IsThereAReasonToNotCheck() =>
            !Debugger.IsAttached;

        private string LicenseCode { get; set; }
    }
}
