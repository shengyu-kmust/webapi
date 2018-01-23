using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Entities
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Table("User")]
    public partial class User:BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, Column(TypeName = "varchar"), MaxLength(50)]
        public string Id { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(50)]
        public string LoginName { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 密码，用于存储密码的md5加密
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(50)]
        public string Pwd { get; set; }
        /// <summary>
        /// 性别，1男2女，对应Gender枚举
        /// </summary>
        [Column(TypeName = "int")]
        public int? Gender { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(50)]
        public string IdentityCard { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(50)]
        public string Tel { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? Birthdate { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(500)]
        public string UserPic { get; set; }
    }
}