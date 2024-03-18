
namespace Abp.AspNetZeroCore.Licensing
{
    using System;

    public class AspNetZeroLicenseException : Exception
    {
        public AspNetZeroLicenseException()
        {
            throw new Exception("AspNet Zero License Check Failed. Please contact to info@aspnetzero.com if you are using a licensed version!");
        }

        public AspNetZeroLicenseException(string message) : base(message)
        {
        }
    }
}
