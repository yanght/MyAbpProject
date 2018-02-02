using Abp.Authorization.Users;
using MyProject.Authorization.Roles;
using MyProject.EntityFramework;
using MyProject.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Migrations.SeedData
{
    public class DefaultTenantRoleAndUserBuilder
    {
        private readonly MyProjectDbContext _context;

        public DefaultTenantRoleAndUserBuilder(MyProjectDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            CreateUserAndRoles();
        }

        public void CreateUserAndRoles()
        {
            //Admin role for tenancy owner
            var adminRoleForTenancyOwner = _context.Roles.FirstOrDefault(r => r.TenantId == null && r.Name == "Amdin");

            if (adminRoleForTenancyOwner == null)
            {
                adminRoleForTenancyOwner = _context.Roles.Add(new Role() { Name = "Amdin", DisplayName = "Amdin" });
                _context.SaveChanges();
            }

            //Admin user for tenancy owner
            var adminUserForTenancyOwer = _context.Users.FirstOrDefault(u => u.TenantId == null && u.UserName == "admin");
            if (adminUserForTenancyOwer == null)
            {
                adminUserForTenancyOwer = _context.Users.Add(new Users.User()
                {
                    TenantId = null,
                    UserName = "amidn",
                    Name = "System",
                    Surname = "Administrator",
                    EmailAddress = "yannis@live.com",
                    IsEmailConfirmed = true,
                    Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==" //123qwe
                });
                _context.SaveChanges();
                _context.UserRoles.Add(new UserRole(null, adminUserForTenancyOwer.Id, adminRoleForTenancyOwner.Id));
                _context.SaveChanges();
            }

            //Default tenant
            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == "Default");
            if (defaultTenant == null)
            {
                defaultTenant = _context.Tenants.Add(new Tenant() { TenancyName = "Default", Name = "Default" });
                _context.SaveChanges();
            }

            //Admin role for 'Default' tenant
            var adminRoleForDefaultTenant = _context.Roles.FirstOrDefault(r => r.TenantId == defaultTenant.Id && r.Name == "Admin");
            if (adminRoleForDefaultTenant == null)
            {
                adminRoleForDefaultTenant = _context.Roles.Add(new Role() { TenantId = defaultTenant.Id, Name = "Admin", DisplayName = "Admin" });
                _context.SaveChanges();
            }

            //Admin for 'Default' tenant
            var adminUserForDefaultTenant = _context.Users.FirstOrDefault(u => u.TenantId == defaultTenant.Id && u.UserName == "Amdin");
            if (adminUserForDefaultTenant == null)
            {
                adminUserForDefaultTenant = _context.Users.Add(new Users.User()
                {
                    TenantId = defaultTenant.Id,
                    UserName = "admin",
                    Name = "System",
                    Surname = "Administrator",
                    EmailAddress = "yannis@live.com",
                    IsEmailConfirmed = true,
                    Password = "AM4OLBpptxBYmM79lGOX9egzZk3vIQU3d/gFCJzaBjAPXzYIK3tQ2N7X4fcrHtElTw==" //123qwe
                });
                _context.SaveChanges();

                _context.UserRoles.Add(new UserRole(null, adminUserForDefaultTenant.Id, adminRoleForDefaultTenant.Id));

                _context.SaveChanges();
            }


        }

    }
}
