using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Systems.Dto
{
    [AutoMapFrom(typeof(AuditLog))]
    public class AuditLogDto : AuditInfo
    {
        public string TenancyName { get; set; }
        public string UserName { get; set; }
    }
}
