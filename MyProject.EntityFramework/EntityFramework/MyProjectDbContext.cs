﻿using System.Data.Common;
using System.Data.Entity;
using Abp.EntityFramework;

namespace MyProject.EntityFramework
{
    public class MyProjectDbContext :DbContext//AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...

        //Example:
        //public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Tasks.Task> Tasks { get; set; }
        public virtual IDbSet<Tasks.User> Users { get; set; }
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public MyProjectDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in MyProjectDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of MyProjectDbContext since ABP automatically handles it.
         */
        public MyProjectDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public MyProjectDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public MyProjectDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
