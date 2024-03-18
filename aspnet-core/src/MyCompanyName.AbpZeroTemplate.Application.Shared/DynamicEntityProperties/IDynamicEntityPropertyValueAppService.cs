using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.DynamicEntityProperties.Dto;
using MyCompanyName.AbpZeroTemplate.DynamicEntityPropertyValues.Dto;

namespace MyCompanyName.AbpZeroTemplate.DynamicEntityProperties
{
    public interface IDynamicEntityPropertyValueAppService
    {
        Task<DynamicEntityPropertyValueDto> Get(int id);

        Task<ListResultDto<DynamicEntityPropertyValueDto>> GetAll(GetAllInput input);

        Task Add(DynamicEntityPropertyValueDto input);

        Task Update(DynamicEntityPropertyValueDto input);

        Task Delete(int id);

        Task<GetAllDynamicEntityPropertyValuesOutput> GetAllDynamicEntityPropertyValues(GetAllDynamicEntityPropertyValuesInput input);
    }
}
