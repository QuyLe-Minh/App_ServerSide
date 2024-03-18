
namespace Abp.AspNetZeroCore.Licensing
{
    using System;
    using System.Runtime.CompilerServices;

    public class LicenseCheckInfo
    {
        public string LicenseCode { get; set; }

        public string UniqueComputerId { get; set; }

        public string ProjectAssemblyName { get; set; }

        public string LicenseController { get; set; }

        public string ComputerName { get; set; }

        public string ControlCode { get; set; }

        public DateTime DateOfClient { get; set; }
    }
}
