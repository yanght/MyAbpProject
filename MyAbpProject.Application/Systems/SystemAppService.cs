﻿using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using MyAbpProject.Systems.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Abp.Extensions;


namespace MyAbpProject.Systems
{
    public class SystemAppService : ISystemAppService
    {
        private readonly IRepository<AuditLog, long> _auditLogRepository;

        public SystemAppService(IRepository<AuditLog, long> auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;

        }
        public PagedResultDto<AuditInfo> GetAuditLogs(GetAuditLogsInput input)
        {
            var query = _auditLogRepository.GetAll();

            query = !string.IsNullOrEmpty(input.Sorting) ? query.OrderBy(input.Sorting) : query.OrderByDescending(t => t.ExecutionTime);

            var count = _auditLogRepository.Count();

            var audityLogs = query.PageBy(input).ToList();

            return new PagedResultDto<AuditInfo>(count, audityLogs.MapTo<List<AuditInfo>>());
        }
    }
}
