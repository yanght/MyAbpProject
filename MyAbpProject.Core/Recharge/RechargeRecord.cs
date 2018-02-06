using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Recharge
{
    public class RechargeRecord : Entity<long>, IHasCreationTime, ISoftDelete
    {
        public RechargeRecord()
        {
            CreationTime = Clock.Now;
        }
        /// <summary>
        /// 充值档位Id
        /// </summary>
        public int RechargeFieldId { get; set; }

        [ForeignKey("RechargeFieldId")]
        public RechargeField RechargeField { get; set; }

        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal RechargeAmount { get; set; }
        /// <summary>
        /// 增值金额
        /// </summary>
        public decimal IncrementAmount { get; set; }
        /// <summary>
        /// 赠送积分
        /// </summary>
        public double Integral { get; set; }
        /// <summary>
        /// 商店代码
        /// </summary>
        public string StoreNumber { get; set; }
        /// <summary>
        /// 店员代码
        /// </summary>
        public string SalesManNumber { get; set; }

        public DateTime CreationTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
