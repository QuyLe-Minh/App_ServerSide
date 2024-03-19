using System;
using System.Collections.Generic;
using System.Text;

using Abp.Application.Services.Dto;

public class GetCvsDocInput
{
    public string Filter { get; set; }
    public string DocStatus { get; set; }
}

public class CvsDocListDto : FullAuditedEntityDto
{
    public string DocTitle { get; set; }
    public string DocCode { get; set; }
    public string DocType { get; set; }
    public DateTime? DocPublish { get; set; }
    public DateTime DocValid { get; set; }
    public DateTime DocExp { get; set; }
    public string DocPlace { get; set; }
    public string DocStatus { get; set; }
    public string DocSummary { get; set; }
}
