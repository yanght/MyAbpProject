using Abp.Application.Services;
using Abp.Domain.Repositories;
using MyAbpProject.Recharge.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Recharge
{
    public interface IRechargeAppService : IApplicationService
    {
        GetRechargeRecordListOutput GetRechargeRecordList(GetRechargeRecordListInput input);
    }
}
