using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Entities
{
    [Table("Test")]
    public class TestTable
    {
        [Key,Column(TypeName = "varchar"),MaxLength(50)]
        public string Id { set; get; }
        [Column(TypeName = "int")]
        public int? Age { set; get; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDateTime { get; set; }
        [Column(TypeName = "varchar"), MaxLength(20)]
        public string AddColumn1 { set; get; }

        [Column(TypeName = "varchar"), MaxLength(20)]
        public string AddColumn2 { set; get; }
    }
}