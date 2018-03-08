using Abp.Data;
using MyAbpProject.IRepositories;
using MyAbpProject.Recharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.EntityFramework.Repositories
{
    public class DemoRepository : MyAbpProjectDapperRepositoryBase<MyAbpProjectDbContext, RechargeField>, IDemoRepository
    {
        public DemoRepository(IActiveTransactionProvider activeTransactionProvider)
            : base(activeTransactionProvider)
        {

        }

        public List<RechargeField> GetFields()
        {
            
            var query = Query("select * from RechargeFields");
            return query.ToList();
        }
    }
}
