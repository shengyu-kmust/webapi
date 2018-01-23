using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapi.Entities;


namespace webapi.Services
{
    public class AuthorizeService:BaseService
    {
        public AuthorizeService(DB db) : base(db)
        {
        }
        /// <summary>
        /// 获取资源的角色名数组
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public string[] GetResourceRoleNames(string resourceName)
        {
            var resource=_db.Resources.FirstOrDefault(a => a.Name == resourceName);
            var roleIds = _db.Permissions.Where(a => a.ResourceId == resource.Id).Select(a => a.RoleId).ToArray();
            var roleNames = _db.Roles.Where(a => roleIds.Contains(a.Id)).Select(a => a.Name).ToArray();
            return roleNames;
        }
        /// <summary>
        /// 获取所有资源的角色
        /// </summary>
        /// <returns></returns>
        public List<(string resourceName, string roleNames)> GetAllResourceRoleNames()
        {
            var result=new List<(string resourceName, string roleNames)>();
            var query = from a in _db.Permissions
                join b in _db.Resources on a.ResourceId equals b.Id 
                join c in _db.Roles on a.RoleId equals c.Id 
                group new{a,b,c} by b.Name into g
                select new
                {
                    resourceName=g.Key,
                    roleNames=g.Select(i => i.c.Name)
                };
            
            var list = query.ToList().Select(a => new
            {
                a.resourceName,
                roleNames=string.Join(",", a.roleNames.ToArray().Distinct())
            });
            foreach (var x1 in list)
            {
                result.Add((x1.resourceName,x1.roleNames));
            }
            return result;
        }
    }
}