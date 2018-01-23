using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi.Common
{
    /// <summary>
    /// 数据删除标志
    /// </summary>
    public enum DeleteMark
    {
        Deleted = -1,
        NotDeleted = 0
    }
    /// <summary>
    /// 性别约定值
    /// </summary>
    public enum Gender
    {
        Unknow = 0,
        Male = 1,
        Female = 2
    }

    /// <summary>
    /// 用户类型
    /// </summary>
    public enum UserType
    {
        /// <summary>
        /// 超级管理员
        /// </summary>
        SuperAdmin,
        /// <summary>
        /// 管理员
        /// </summary>
        Admin,
        /// <summary>
        /// 普通用户
        /// </summary>
        User
    }

    public enum ResourceCategory
    {
        WebApi,
        Menu
    }
}