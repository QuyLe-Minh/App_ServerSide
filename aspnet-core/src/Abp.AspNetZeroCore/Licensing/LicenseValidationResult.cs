namespace Abp.AspNetZeroCore.Licensing
{
    using System;
    using System.Runtime.CompilerServices;

    public class LicenseValidationResult
    {
        public bool Success { get; set; }

        public bool LastRequest { get; set; }

        public string ControlCode { get; set; }
    }
}
