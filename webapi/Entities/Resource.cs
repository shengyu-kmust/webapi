using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Entities
{
    /// <summary>
    /// 需要做权限控制的资源
    /// </summary>
    [Table("Resource")]
    public class Resource:BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key,Column(TypeName = "varchar"),MaxLength(50)]
        public string Id { set; get; }
        /// <summary>
        /// 资源类型，如webapi接口，菜单等
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(20)]
        public string Category { set; get; }
        /// <summary>
        /// 资源名（唯一性），如“ControllerName.ActionName”，或是“url地址”
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(100)]
        public string Name { set; get; }
        /// <summary>
        /// 资源描述
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(200)]
        public string Description { set; get; }
    }
}