
using Abp.Dapper.Repositories;
using Abp.Data;
using Abp.EntityFramework;
using MyAbpProject.IRepositories;
using MyAbpProject.Recharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.EntityFramework.Repositories
{
    public class RechargeRepository : MyAbpProjectRepositoryBase<RechargeField, int>, IRechargeRepository
    {
        public RechargeRepository(IDbContextProvider<MyAbpProjectDbContext> dbContextProvider)
          : base(dbContextProvider)
        {
        }

        public List<RechargeField> GetRechargeFields()
        {
            var query = GetAll();
            query = query.Where(m => m.IsDeleted == false);
            return query.ToList();
        }
    }
}
