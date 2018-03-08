using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Data;
using Abp.Domain.Entities.Auditing;
using MyAbpProject.Systems;
using MyAbpProject.Systems.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.EntityFramework.Repositories
{
    public class AuditedRepository : MyAbpProjectDapperRepositoryBase<MyAbpProjectDbContext, AuditLog, long>, IAuditedRepository
    {
        public AuditedRepository(IActiveTransactionProvider activeTransactionProvider)
             : base(activeTransactionProvider)
        {

        }

        public PagedResultDto<AuditLogDto> GetAuditLogs(GetAuditLogsInput input)
        {
            return null;
        }

    }
}
