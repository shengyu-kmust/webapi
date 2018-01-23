using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using webapi.Common;
using webapi.Entities;
using webapi.Security;

namespace webapi.Services
{
    public class ResourceService : BaseService
    {
        public ResourceService(DB db) : base(db)
        {
        }

        public string[] GetResourceRoles(string resourceId)
        {
            return new string[] { };
        }

        /// <summary>
        /// 增加或修改资源
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="category"></param>
        public void AddOrUpdateResource(string name, string description, string category)
        {
            var resource = _db.Resources.FirstOrDefault(a => a.Name == name);
            if (resource == null)
            {
                resource = new Resource()
                {
                    Id = IdManager.NewResourceId(),
                    Name = name,
                    Description = description,
                    Category = category,
                    CreateTime = DateTime.Now,
                    DeleteMark = (int)DeleteMark.NotDeleted
                };
            }
            else
            {
                resource.Description = string.IsNullOrEmpty(description) ? resource.Description : description;
                resource.Name = string.IsNullOrEmpty(name) ? resource.Name : name;
                resource.Category = string.IsNullOrEmpty(category) ? resource.Category : category; ;
            }
            _db.Resources.AddOrUpdate(resource);
            _db.SaveChanges();
        }

      /// <summary>
      /// 更新webapi的权限资源到数据库
      /// </summary>
        public void UpdateWebApiResource()
        {
            var resources = GetAllWebApiResource();
            resources.ForEach(a =>
            {
                AddOrUpdateResource(a.Name, a.Description, a.Category);
            });
        }

        /// <summary>
        /// 获取所有webapi的授权资源列表
        /// </summary>
        /// <returns></returns>
        public List<Resource> GetAllWebApiResource()
        {
            var allController = Assembly.GetExecutingAssembly().ExportedTypes
                .Where(a => a.IsSubclassOf(typeof(ApiController))).ToList();
            var resources = new List<Resource>();
            allController.ForEach(controller =>
            {
                if (Attribute.IsDefined(controller, typeof(RBAuthorizeAttribute)))
                {
                    var description = ((RBAuthorizeAttribute)controller.GetCustomAttribute(typeof(RBAuthorizeAttribute))).Description;
                    resources.Add(new Resource()
                    {
                        Category = ResourceCategory.WebApi.ToString(),
                        CreateUser = Configs.Config.SysUser,
                        Description = description,
                        Name = controller.Name
                    });
                }
                controller.GetMethods().Where(b => Attribute.IsDefined(b, typeof(RBAuthorizeAttribute))).ToList().ForEach(
                    action =>
                    {
                        var description = ((RBAuthorizeAttribute)action.GetCustomAttribute(typeof(RBAuthorizeAttribute))).Description;
                        resources.Add(new Resource()
                        {
                            Category = ResourceCategory.WebApi.ToString(),
                            CreateUser = Configs.Config.SysUser,
                            Description = description,
                            Name = action.Name
                        });
                    });
            });
            return resources;
        }
    }
}