using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using MyAbpProject.Recharge.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Recharge
{
    public class RechargeAppService : ApplicationService, IRechargeAppService
    {
        private readonly IRepository<RechargeField> _rechargeFieldRepository;
        private readonly IRepository<RechargeRecord, long> _rechargeRecordRepository;

        public RechargeAppService(IRepository<RechargeField> rechargeFieldRepository,
            IRepository<RechargeRecord, long> rechargeRecordRepository)
        {
            _rechargeFieldRepository = rechargeFieldRepository;
            _rechargeRecordRepository = rechargeRecordRepository;
        }

        public GetRechargeRecordListOutput GetRechargeRecordList(GetRechargeRecordListInput input)
        {
            var records = _rechargeRecordRepository.GetAllList();

            return new GetRechargeRecordListOutput()
            {
                RechargeRecord = Mapper.Map<List<RechargeDto>>(records)
            };
        }
    }
}