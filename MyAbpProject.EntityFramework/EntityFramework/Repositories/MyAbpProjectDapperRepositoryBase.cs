using Abp.Dapper.Repositories;
using Abp.Data;
using Abp.Domain.Entities;
using Abp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.EntityFramework.Repositories
{
    public class MyAbpProjectDapperRepositoryBase<TDbContext, TEntity, TPrimaryKey> : DapperEfRepositoryBase<MyAbpProjectDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected MyAbpProjectDapperRepositoryBase(IActiveTransactionProvider activeTransactionProvider)
           : base(activeTransactionProvider)
        {

        }

        //add common methods for all repositories
    }

    public class MyAbpProjectDapperRepositoryBase<TDbContext, TEntity> : DapperEfRepositoryBase<MyAbpProjectDbContext, TEntity, int>
         where TEntity : class, IEntity<int>
    {
        protected MyAbpProjectDapperRepositoryBase(IActiveTransactionProvider activeTransactionProvider)
           : base(activeTransactionProvider)
        {

        }
        //do not add any method here, add to the class above (since this inherits it)
    }

}
