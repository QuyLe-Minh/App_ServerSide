using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using MyCompanyName.AbpZeroTemplate.ICvsDoc;
using MyCompanyName.AbpZeroTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using Abp.Extensions;
using AutoMapper.QueryableExtensions;



public class CvsDocAppService : CvsDocListDto, ICvsDocService
{
    private readonly IRepository<CvsDoc> _cvsDocRepository;

    public CvsDocAppService(IRepository<CvsDoc> cvsDocRepository)
    {
        _cvsDocRepository = cvsDocRepository;
    }

    public ListResultDto<CvsDocListDto> GetCvsDocs(GetCvsDocInput input)
    {
        var cvsDocs = _cvsDocRepository
            .GetAll()
            .WhereIf(
                !input.Filter.IsNullOrEmpty(),
                c => c.docTitle.Contains(input.Filter) ||
                     c.docCode.Contains(input.Filter) ||
                     c.docType.Contains(input.Filter)
            )
            .WhereIf(
                !input.DocStatus.IsNullOrEmpty(),
                c => c.DocStatus == input.DocStatus
            )
        .OrderBy(c => c.docTitle)
        .ThenBy(c => c.docCode)
            .ProjectTo<CvsDocListDto>(ObjectMapper.ConfigurationProvider)
            .ToList();

        return new ListResultDto<CvsDocListDto>(cvsDocs);
    }
}
