using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Recharge
{
    /// <summary>
    /// 充值档位
    /// </summary>
    public class RechargeField : Entity, IHasCreationTime, ISoftDelete
    {
        public RechargeField()
        {
            Amount = 0;
            IncrementAmount = 0;
            Integral = 0;
            CreationTime = Clock.Now;
        }
        /// <summary>
        /// 充值金额
        /// </summary>
        [Required]
        public decimal Amount { get; set; }
        /// <summary>
        /// 增值金额
        /// </summary>
        [Required]
        public decimal IncrementAmount { get; set; }
        /// <summary>
        /// 赠送积分
        /// </summary>
        [Required]
        public double Integral { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
