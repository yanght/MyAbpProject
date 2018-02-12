using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.EntityFramework.Repositories
{
    public abstract class MyAbpProjectDapperRepositoryBase<TEntity, TPrimaryKey> : AbpDapperRepositoryBase<MyAbpProjectDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {

    }
}
