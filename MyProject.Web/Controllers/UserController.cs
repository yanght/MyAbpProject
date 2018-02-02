using Abp.Auditing;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.WebApi.Controllers;
using MyProject.Tasks;
using MyProject.Tasks.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyProject.Web.Controllers
{
    [Audited]
    public class UserController : AbpApiController
    {
        private readonly IRepository<Task> _taskRepository;

        public UserController(IRepository<Task> taskRepository)
        {
            LocalizationSourceName = MyProjectConsts.LocalizationSourceName;
            _taskRepository = taskRepository;
        }

      
        public virtual List<Task> Get()
        {
            var tasks = _taskRepository.GetAll();

            return tasks.ToList();
        }
    }
}
