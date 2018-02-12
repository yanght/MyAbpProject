using Abp.Dapper.Repositories;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Dapper.Repositories
{
    public abstract class MyAbpProjectDapperRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<MyAbpProjectDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {

    }

    public abstract class MyAbpProjectDapperRepositoryBase<TEntity> : AbpDapperRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {

    }
}
