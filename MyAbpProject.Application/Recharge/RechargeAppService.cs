using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using MyAbpProject.IRepositories;
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
        private readonly IRechargeRepository _rechargeRepository;
        private readonly IDemoRepository _demoRepository;

        public RechargeAppService(IRepository<RechargeField> rechargeFieldRepository,
            IRepository<RechargeRecord, long> rechargeRecordRepository,
            IRechargeRepository rechargeRepository,
            IDemoRepository demoRepository)
        {
            _rechargeFieldRepository = rechargeFieldRepository;
            _rechargeRecordRepository = rechargeRecordRepository;
            _rechargeRepository = rechargeRepository;
            _demoRepository = demoRepository;

        }

        public GetRechargeRecordListOutput GetRechargeRecordList(GetRechargeRecordListInput input)
        {
            var records = _rechargeRecordRepository.GetAllList();

            var files = _rechargeRepository.GetRechargeFields();

            var files1 = _demoRepository.GetFields();

            return new GetRechargeRecordListOutput()
            {
                RechargeRecord = Mapper.Map<List<RechargeDto>>(records)
            };
        }
    }
}