﻿using Abp.Auditing;
using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Mapper
{
    public class RechargeMapper : ClassMapper<Recharge.RechargeField>
    {
        public RechargeMapper()
        {
            Table("RechargeFields");
            AutoMap();
        }
    }

    public class AuditLogMapper : ClassMapper<AuditLog>
    {
        public AuditLogMapper()
        {
            Table("AbpAuditLogs");
            AutoMap();
        }
    }
}
