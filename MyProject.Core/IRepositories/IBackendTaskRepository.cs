using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.IRepositories
{
    public interface IBackendTaskRepository : IRepository<MyProject.Tasks.Task>
    {
        /// <summary>
        /// 获取某个用户分配了哪些任务
        /// </summary>
        /// <param name="personId">用户Id</param>
        /// <returns>任务列表</returns>
        List<MyProject.Tasks.Task> GetTaskByAssignedPersonId(long personId);
    }
}
