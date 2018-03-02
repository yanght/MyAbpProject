using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using MyAbpProject.Authorization;
using MyAbpProject.Authorization.Roles;
using MyAbpProject.Authorization.Users;
using MyAbpProject.MultiTenancy;
using MyAbpProject.Recharge;

namespace MyAbpProject.EntityFramework
{
    public class MyAbpProjectDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        public IDbSet<RechargeField> RechargeFields { get; set; }
        public IDbSet<RechargeRecord> RechargeRecords { get; set; }
        public IDbSet<PermissionDefined> PermissioDefineds { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public MyAbpProjectDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in MyAbpProjectDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of MyAbpProjectDbContext since ABP automatically handles it.
         */
        public MyAbpProjectDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public MyAbpProjectDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public MyAbpProjectDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
