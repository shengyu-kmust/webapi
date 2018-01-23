using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Entities
{
    /// <summary>
    /// 用户角色关系对应表，user role map
    /// </summary>
    [Table("URM")]
    public partial class URM:BaseEntity
    {
        /// <summary>
        /// ID主键
        /// </summary>
        [Key, Column(TypeName = "varchar"), MaxLength(50)]
        public string Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(50)]
        public string UserId { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(50)]
        public string RoleId { get; set; }
       
    }
}