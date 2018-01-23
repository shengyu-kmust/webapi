using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Entities
{
    /// <summary>
    /// 权限表，记录角色和资源的对应关系
    /// </summary>
    [Table("Permission")]
    public class Permission:BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, Column(TypeName = "varchar"), MaxLength(50)]
        public string Id { set; get; }
        /// <summary>
        /// 资源类型，如webapi接口，菜单等
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(50)]
        public string RoleId { set; get; }
        /// <summary>
        /// 资源名，如“ControllerName.ActionName”，或是“url地址”
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(50)]
        public string ResourceId { set; get; }
    }
}