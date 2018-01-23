using System;
using System.Linq;
using webapi.Entities;

namespace webapi.Common
{
    public class IdManager
    {
        private static string _lastUserId;
        private static string _lastRoleId;
        private static string _lastResourceId;
        private static string _lastPermissionId;
        private static string _lastURMId;

        public static string NewUserId()
        {
            if (string.IsNullOrEmpty(_lastUserId))
            {
                using (DB db=new DB())
                {
                    var userId = db.Users.OrderByDescending(a => a.Id).FirstOrDefault()?.Id;
                    if (string.IsNullOrEmpty(userId))
                    {
                        _lastUserId = "1001";
                    }
                }   
            }
            _lastUserId = (int.Parse(_lastUserId) + 1).ToString();
            return _lastUserId;
        }

        public static string NewRoleId()
        {
            if (string.IsNullOrEmpty(_lastRoleId))
            {
                using (DB db = new DB())
                {
                    var roleId = db.Roles.OrderByDescending(a => a.Id).FirstOrDefault()?.Id;
                    if (string.IsNullOrEmpty(roleId))
                    {
                        _lastRoleId = "1";
                    }
                }
            }
            _lastRoleId = (int.Parse(_lastRoleId) + 1).ToString();
            return _lastRoleId;
        }

        public static string NewResourceId()
        {
            if (string.IsNullOrEmpty(_lastResourceId))
            {
                using (DB db = new DB())
                {
                    var ResourceId = db.Resources.OrderByDescending(a => a.Id).FirstOrDefault()?.Id;
                    if (string.IsNullOrEmpty(ResourceId))
                    {
                        _lastResourceId = "1";
                    }
                }
            }
            _lastResourceId = (int.Parse(_lastResourceId) + 1).ToString();
            return _lastResourceId;
        }

        public static string NewPermissionId()
        {
            if (string.IsNullOrEmpty(_lastPermissionId))
            {
                using (DB db = new DB())
                {
                    var PermissionId = db.Permissions.OrderByDescending(a => a.Id).FirstOrDefault()?.Id;
                    if (string.IsNullOrEmpty(PermissionId))
                    {
                        _lastPermissionId = "1";
                    }
                }
            }
            _lastPermissionId = (int.Parse(_lastPermissionId) + 1).ToString();
            return _lastPermissionId;
        }

        public static string NewURMId()
        {
            if (string.IsNullOrEmpty(_lastURMId))
            {
                using (DB db = new DB())
                {
                    var URMId = db.URMs.OrderByDescending(a => a.Id).FirstOrDefault()?.Id;
                    if (string.IsNullOrEmpty(URMId))
                    {
                        _lastURMId = "1";
                    }
                }
            }
            _lastURMId = (int.Parse(_lastURMId) + 1).ToString();
            return _lastURMId;
        }
    }
}