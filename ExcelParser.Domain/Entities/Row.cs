using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExcelParser.Domain.Entities.Base;

namespace ExcelParser.Domain.Entities
{
    [Table("Spreadsheet")]
    public class Row : EntityBase
    {
        [Required]
        [Column("Hie")]
        public string Hie { get; set; }

        [Required]
        [Column("IDX")]
        public int IDX { get; set; }

        [Required]
        [Column("Level")]
        public int Level { get; set; }

        [Required]
        [Column("Parent")]
        public string Parent { get; set; }

        [Required]
        [Column("Node")]
        public string Node { get; set; }

        [Required]
        [Column("Description")]
        public string Description { get; set; }

        [Required]
        [Column("Method")]
        public string Method { get; set; }

        [Column("Contains_Att")]
        public string Contains_Att { get; set; }

        [Column("Contains_Val")]
        public string Contains_Val { get; set; }

        [Column("Between_Att")]
        public string Between_Att { get; set; }

        [Column(name: "Between_Lo", TypeName = "decimal(10, 4)")]
        public decimal? Between_Lo { get; set; }

        [Column(name: "Between_Hi", TypeName = "decimal(10, 4)")]
        public decimal? Between_Hi { get; set; }
    }
}
