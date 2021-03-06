﻿using System.Reflection;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Modules;
using MyAbpProject.Authorization.Roles;
using MyAbpProject.Authorization.Users;
using MyAbpProject.Roles.Dto;
using MyAbpProject.Users.Dto;

namespace MyAbpProject
{
    [DependsOn(typeof(MyAbpProjectCoreModule), typeof(AbpAutoMapperModule))]
    public class MyAbpProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            // TODO: Is there somewhere else to store these, with the dto classes
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                // Role and permission
                cfg.CreateMap<Permission, string>().ConvertUsing(r => r.Name);
                cfg.CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

                cfg.CreateMap<CreateRoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
                cfg.CreateMap<RoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());

                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<UserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

                cfg.CreateMap<CreateUserDto, User>();
                cfg.CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());


                //解析依赖，并进行映射规则创建
                var mappers = IocManager.IocContainer.ResolveAll<IDtoMapping>();
                foreach (var dtomap in mappers)
                    dtomap.CreateMapping(cfg);

            });

        }
    }
}
