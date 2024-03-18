using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace MyCompanyName.AbpZeroTemplate.Web.Controllers
{
    public class FileUploadController : AbpZeroTemplateControllerBase
    {
        private readonly IHostEnvironment _env;
        public FileUploadController(IHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        public async Task<string> UploadFile()
        {
            var image = Request.Form.Files.First();
            var uniqueFileName = GetUniqueFileName(image.FileName);
            var dir = Path.Combine(_env.ContentRootPath, "Docs");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var filePath = Path.Combine(dir, uniqueFileName);
            await image.CopyToAsync(new FileStream(filePath, FileMode.Create));
            return uniqueFileName;
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                   + "_"
                   + Guid.NewGuid().ToString().Substring(0, 4)
                   + Path.GetExtension(fileName);
        }

        [HttpGet]
        public async Task <IActionResult> DownloadFile(string fileName)
        {
            var filePath = Path.Combine(_env.ContentRootPath, "Docs", fileName);
            var contentType = GetContentType(fileName);
            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, contentType, Path.GetFileName(fileName));

        }
    }
}

