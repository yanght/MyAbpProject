using Abp.Domain.Repositories;
using MyAbpProject.Recharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.IRepositories
{
    public interface IRechargeRepository : IRepository<RechargeField, int>
    {
        List<RechargeField> GetRechargeFields();
    }
}
