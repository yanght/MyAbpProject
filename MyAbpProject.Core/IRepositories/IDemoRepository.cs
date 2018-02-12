using Abp.Dapper.Repositories;
using MyAbpProject.Recharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.IRepositories
{
    public interface IDemoRepository : IDapperRepository<RechargeField>
    {
        List<RechargeField> GetFields();
    }
}
