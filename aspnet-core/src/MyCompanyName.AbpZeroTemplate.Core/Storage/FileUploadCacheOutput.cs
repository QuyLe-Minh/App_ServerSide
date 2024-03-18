using Abp.Web.Models;

namespace MyCompanyName.AbpZeroTemplate.Storage
{
    public class FileUploadCacheOutput : ErrorInfo
    {
        public string FileToken { get; set; }

        public FileUploadCacheOutput(string fileToken)
        {
            FileToken = fileToken;
        }

        public FileUploadCacheOutput(ErrorInfo error)
        {
            Code = error.Code;
            Details = error.Details;
            Message = error.Message;
            ValidationErrors = error.ValidationErrors;
        }
    }
}