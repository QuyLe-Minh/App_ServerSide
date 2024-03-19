using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.ICvsDoc
{
    public interface ICvsDocService : IApplicationService
    {
        ListResultDto<CvsDocListDto> GetCsvDoc(GetCvsDocInput input);
    }
}
