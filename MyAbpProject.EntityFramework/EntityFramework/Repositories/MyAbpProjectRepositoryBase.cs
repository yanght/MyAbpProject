using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace MyAbpProject.EntityFramework.Repositories
{
    public abstract class MyAbpProjectRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<MyAbpProjectDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected MyAbpProjectRepositoryBase(IDbContextProvider<MyAbpProjectDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class MyAbpProjectRepositoryBase<TEntity> : MyAbpProjectRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected MyAbpProjectRepositoryBase(IDbContextProvider<MyAbpProjectDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
