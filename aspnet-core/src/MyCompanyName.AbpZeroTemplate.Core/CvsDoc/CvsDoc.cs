using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.CvsDocs
{
    [Table("NewDocs")]
    public class CvsDoc : FullAuditedEntity
    {
        public const int MaxTitleLength = 30;
        public const int MaxCodeLength = 30;
        public const int MaxPlaceLength = 255;

        [Required]
        [MaxLength(MaxTitleLength)]
        public virtual string docTitle { get; set; }

        [Required]
        [MaxLength(MaxCodeLength)]
        public virtual string docCode { get; set; }

        [Required]
        public virtual string docType { get; set; }

        public DateTime? docPublish { get; set; }

        [Required]
        public DateTime docValid { get; set; }

        [Required]
        public DateTime docExp { get; set; }

        [MaxLength(MaxPlaceLength)]
        public virtual string docPlace { get; set; }

        [Required]
        public string DocStatus { get; set; }

        public string docSummary { get; set; }
    }
}
