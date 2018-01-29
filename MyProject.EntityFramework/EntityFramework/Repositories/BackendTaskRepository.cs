using Abp.EntityFramework;
using MyProject.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.EntityFramework.Repositories
{
    public class BackendTaskRepository : MyProjectRepositoryBase<MyProject.Tasks.Task>, IBackendTaskRepository
    {
        public BackendTaskRepository(IDbContextProvider<MyProjectDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public List<MyProject.Tasks.Task> GetTaskByAssignedPersonId(long personId)
        {
            var query = GetAll();

            if (personId > 0)
            {
                query = query.Where(t => t.AssignedPersonId == personId);
            }

            return query.ToList();
        }
    }
}
