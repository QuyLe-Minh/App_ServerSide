using Abp.Domain.Repositories;
using MyCompanyName.AbpZeroTemplate.ICvsDoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.CvsDoc
{
    public class CvsDocService : CvsDocDemoAppServiceBase, ICvsDocService
    {
        private readonly IRepository<CvsDoc> _CvsDocRepository;

        public CvsDocService(IRepository<CvsDoc> CvsDocRepository)
        {
            _CvsDocRepository = CvsDocRepository;
        }

        public ListResultDto<CvsDocDto> GetPeople(GetCvsDocInput input)
        {
            var people = _personRepository
                .GetAll()
                .WhereIf(
                    !input.Filter.IsNullOrEmpty(),
                    p => p.DocTitle.Contains(input.Filter) ||
                         p.DocCode.Contains(input.Filter) ||
                         p.DocType.Contains(input.Filter)
                )
                .WhereIf(
                    !input.DocStatus.IsNullOrEmpty(),
                    p => p.DocStatus == input.DocStatus
                )
                .OrderBy(p => p.DocTitle)
                .ThenBy(p => p.DocCode)
                .ProjectTo<CvsDocDto>(ObjectMapper.ConfigurationProvider)
                .ToList();

            return new ListResultDto<CvsDocDto>(people);
        }
    }

}


