using MyAbpProject.Authorization;
using MyAbpProject.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbpProject.Migrations.SeedData
{
    public class DefaultPermissionDefinedCreator
    {
        private readonly MyAbpProjectDbContext _context;

        public DefaultPermissionDefinedCreator(MyAbpProjectDbContext context)
        {
            _context = context;
        }

        public  void Create()
        {
            if (_context.PermissioDefineds.FirstOrDefault() == null)
            {
                PermissionDefined usrpermission = new PermissionDefined()
                {
                    Description = "用户管理",
                    Name = "用户管理"
                };
                _context.PermissioDefineds.Add(usrpermission);
                _context.SaveChanges();


                PermissionDefined usrpermission_create = new PermissionDefined()
                {
                    Description = "新增用户",
                    Name = "新增用户",
                    //Parent = usrpermission,
                    ParentId = usrpermission.Id
                };
                _context.PermissioDefineds.Add(usrpermission_create);

                PermissionDefined usrpermission_update = new PermissionDefined()
                {
                    Description = "修改用户",
                    Name = "修改用户",
                    //Parent = usrpermission,
                    ParentId = usrpermission.Id
                };
                _context.PermissioDefineds.Add(usrpermission_update);

                PermissionDefined usrpermission_delete = new PermissionDefined()
                {
                    Description = "删除用户",
                    Name = "删除用户",
                    // Parent = usrpermission,
                    ParentId = usrpermission.Id
                };
                _context.PermissioDefineds.Add(usrpermission_delete);
                _context.SaveChanges();
            }
        }
    }
}
