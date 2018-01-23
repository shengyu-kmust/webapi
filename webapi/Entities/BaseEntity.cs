using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace webapi.Entities
{
    public class BaseEntity
    {

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? CreateTime { set; get; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Column(TypeName = "varchar"), MaxLength(50)]
        public string CreateUser { set; get; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Column(TypeName = "int"), DefaultValue(webapi.Common.DeleteMark.NotDeleted)]
        public int DeleteMark { get; set; }
    }
}