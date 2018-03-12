using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Data;
using Abp.Domain.Entities.Auditing;
using DapperExtensions;
using MyAbpProject.Systems;
using MyAbpProject.Systems.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using Abp.Collections.Extensions;
using Dapper;

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
            DapperExtensions.Sql.SqlServerDialect sqldic = new DapperExtensions.Sql.SqlServerDialect();

            //IList<IPredicate> predList = new List<IPredicate>();
            //predList.Add(Predicates.Field<AuditLogDto>(p => p.Name, Operator.Like, "不知道%"));
            //predList.Add(Predicates.Field<AuditLogDto>(p => p.ID, Operator.Eq, 1));
            //IPredicateGroup predGroup = Predicates.Group(GroupOperator.And, predList.ToArray());


            //var audi = GetAllPaged(m => m.BrowserInfo != "", input.PageIndex, input.MaxResultCount, true, m => m.ExecutionTime).ToList();

            string executeQuery = @"WITH pagintable AS(
                                        SELECT ROW_NUMBER() OVER(ORDER BY [AbpAuditLogs].ID DESC )AS RowID, 
                                        [AbpAuditLogs].*,[dbo].[AbpTenants].TenancyName,
                                        [dbo].[AbpUsers].UserName from [dbo].[AbpAuditLogs]
                                        left join[dbo].[AbpTenants]
                                        on[dbo].[AbpAuditLogs].TenantId=[dbo].[AbpTenants].Id
                                        left join[dbo].[AbpUsers]
                                        on[AbpAuditLogs].UserId=[dbo].[AbpUsers].Id
                                        WHERE 1= 1) 
                                        SELECT * FROM pagintable where RowID 
                                        between ((@CurrentPageIndex - 1)  * @PageSize) + 1 
                                        and (@CurrentPageIndex  * @PageSize)";

            string executeCount = "SELECT COUNT(*) FROM AbpAuditLogs WHERE 1= 1";

            var mixCondition = new
            {
                CurrentPageIndex = input.PageIndex,
                PageSize = input.MaxResultCount
            };

            var logs = Query<AuditLogDto>(executeQuery, mixCondition).ToList();

            var count = Connection.ExecuteScalar<int>(executeCount, transaction: ActiveTransaction);

            return new PagedResultDto<AuditLogDto>(count, logs);

        }

    }
}
