using Abp.Application.Services.Dto;

namespace MyCompanyName.AbpZeroTemplate.Authorization.Users.Dto
{
    public interface IGetLoginAttemptsInput: ISortedResultRequest
    {
        string Filter { get; set; }
    }
}