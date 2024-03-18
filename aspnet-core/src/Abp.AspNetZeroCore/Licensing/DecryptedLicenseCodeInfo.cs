
namespace Abp.AspNetZeroCore.Licensing
{
    using System;
    using System.Runtime.CompilerServices;

    public class DecryptedLicenseCodeInfo
    {
        public long CustomerId { get; set; }

        public string ProjectName { get; set; }
    }
}
