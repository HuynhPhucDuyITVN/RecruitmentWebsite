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
        [Display(Name = "Mã số CV")]
        public int Cvid { get; set; }
        
        [Column("UngVienID")]
        [Display(Name = "Ứng viên")]
        public int UngVienId { get; set; }
        [StringLength(100)]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }
        [Column("FileURL")]
        [StringLength(255)]
        [Display(Name = "Đường dẫn chứa File")]
        public string FileUrl { get; set; }
        [Column(TypeName = "datetime")]
        [Display(Name = "Thời gian lưu")]
        public DateTime? ThoiGianTao { get; set; }

        [ForeignKey(nameof(UngVienId))]
        [InverseProperty("Cv")]
        [Display(Name = "Ứng viên")]
        public virtual UngVien UngVien { get; set; }
    }
}
