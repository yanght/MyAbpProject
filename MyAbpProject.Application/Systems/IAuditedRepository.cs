using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Auditing;
using MyAbpProject.Systems.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Systems
{
    public interface IAuditedRepository : IApplicationService
    {
        PagedResultDto<AuditLogDto> GetAuditLogs(GetAuditLogsInput input);
    }
}
