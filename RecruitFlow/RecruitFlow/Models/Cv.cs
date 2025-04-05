using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecruitFlow.Models
{
    [Table("CV")]
    public partial class Cv
    {
        [Key]
        [Column("CVID")]
        public int Cvid { get; set; }
        [Column("UngVienID")]
        public int UngVienId { get; set; }
        [StringLength(100)]
        public string TieuDe { get; set; }
        [Column("FileURL")]
        [StringLength(255)]
        public string FileUrl { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGianTao { get; set; }

        [ForeignKey(nameof(UngVienId))]
        [InverseProperty("Cv")]
        public virtual UngVien UngVien { get; set; }
    }
}
