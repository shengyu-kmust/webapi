using System.Linq;
using webapi.Entities;

namespace webapi.Services
{
    public class PermissionService:BaseService
    {
        public PermissionService(DB db) : base(db)
        {
        }

        public string[] GetWebApiResourceRoleNames(string resourceName)
        {
            var resource = _db.Resources.FirstOrDefault(a => a.Name == resourceName);
            var roleIds= _db.Permissions.Where(a => a.ResourceId == resource.Id).Select(a => a.RoleId).ToArray();
            var roleNames = _db.Roles.Where(a => roleIds.Contains(a.Id)).Select(a => a.Name).ToArray();
            return roleNames;
        }
    }
}