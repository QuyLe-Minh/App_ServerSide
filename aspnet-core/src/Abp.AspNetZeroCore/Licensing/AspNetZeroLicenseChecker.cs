
namespace Abp.AspNetZeroCore.Licensing
{
    using Abp.Dependency;
    using Abp.Threading;
    using Abp.Zero.Configuration;
    using Abp.AspNetZeroCore;
    using Castle.Core.Logging;
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    public sealed class AspNetZeroLicenseChecker : AspNetZeroBaseLicenseChecker, ISingletonDependency
    {
        private readonly string _licenseCheckFilePath;
        private readonly string _uniqueComputerId;

        public AspNetZeroLicenseChecker(AspNetZeroConfiguration configuration = null, IAbpZeroConfig abpZeroConfig = null, string configFilePath = "") : base(configuration, abpZeroConfig, configFilePath)
        {
        }

        public void Check()
        {
        }

        private bool CheckedBefore() =>
            true;

        private Task CheckInternal() =>
            null;

        public void CheckSync()
        {
            try
            {
                AsyncHelper.RunSync(new Func<Task>(this.CheckInternal));
            }
            catch (AspNetZeroLicenseException exception1)
            {
                Console.WriteLine(exception1.Message);
                Environment.Exit(-42);
            }
            catch (Exception exception2)
            {
                Console.WriteLine(exception2.Message);
            }
        }

        private static string EncodeBase64(object o) =>
            "";

        private static string GetComputerName() =>
            Environment.MachineName;

        private string GetHashedProjectName() =>
            base.GetLicenseCode().Substring(base.GetLicenseCode().Length - 0x20, 0x20);

        private string GetHashedValue(string str)
        {
            using (MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider())
            {
                return EncodeBase64(provider.ComputeHash(Encoding.UTF8.GetBytes(str + this._uniqueComputerId + this.GetSalt())));
            }
        }

        protected override string GetHashedValueWithoutUniqueComputerId(string str)
        {
            using (MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider())
            {
                return EncodeBase64(provider.ComputeHash(Encoding.UTF8.GetBytes(str + this.GetSalt())));
            }
        }

        private string GetLastLicenseCheckDate() =>
            File.ReadAllText(this._licenseCheckFilePath);

        private string GetLicenseCodeWithoutProjectNameHash() =>
            base.GetLicenseCode().Substring(0, base.GetLicenseCode().Length - 0x20);

        private static string GetLicenseExpiredString() =>
            "";

        protected override string GetSalt() =>
            "";

        private static string GetTodayAsString() =>
            DateTime.Now.ToString("yyyy-MM-dd");

        private static string GetUniqueComputerId() =>
            "";

        private bool IsProjectNameValid() =>
            base.CompareProjectName(this.GetHashedProjectName());

        private void MarkAsLastRequest()
        {
            File.WriteAllText(this._licenseCheckFilePath, this.GetHashedValue(GetLicenseExpiredString()));
        }

        private static string StringGeneratorFromInteger(object letters) =>
            "";

        private void UpdateLastLicenseCheckDate()
        {
            File.WriteAllText(this._licenseCheckFilePath, this.GetHashedValue(GetTodayAsString()));
        }

        private Task<LicenseValidationResult> ValidateLicense(string licenseCode) =>
            null;

        private Task ValidateLicenseOnServer() =>
            null;

        public ILogger Logger { get; set; }
    }
}
