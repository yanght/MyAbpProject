using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Recharge.Dtos
{
    public class RechargeDto : EntityDto
    {
        public long RechargeFieldId { get; set; }
        public decimal RechargeAmount { get; set; }
        public decimal IncrementAmount { get; set; }
        public double Integral { get; set; }
        public string StoreNumber { get; set; }
        public string SalesManNumber { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
