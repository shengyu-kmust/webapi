using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Entities
{
    /// <summary>
    /// 角色表
    /// </summary>
    [Table("Role")]
    public partial class Role:BaseEntity
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [Key, Column(TypeName = "varchar"), MaxLength(50)]
        public string Id { get; set; }
        /// <summary>
        /// 角色名
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(20)]
        public string Name { get; set; }
       
    }
}