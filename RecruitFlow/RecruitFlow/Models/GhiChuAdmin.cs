using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecruitFlow.Models
{
    public partial class GhiChuAdmin
    {
        [Key]
        [Column("GhiChuID")]
        public int GhiChuId { get; set; }
        [Column("UngVienID")]
        [Display(Name = "Ứng viên")]
        public int UngVienId { get; set; }
        [Column("TinTuyenDungID")]
        [Display(Name = "Tin tuyển dụng")]
        public int TinTuyenDungId { get; set; }
        [Column("NguoiTaoID")]
        [Display(Name = "Người ghi chú")]
        public int NguoiTaoId { get; set; }
        [Display(Name = "Nội dung ghi chú")]
        public string GhiChu { get; set; }
        [Column(TypeName = "datetime")]
        [Display(Name = "Ngày tạo")]
        public DateTime? ThoiGianTao { get; set; }

        [ForeignKey(nameof(NguoiTaoId))]
        [InverseProperty(nameof(NguoiDung.GhiChuAdmin))]
        [Display(Name = "Người ghi chú")]
        public virtual NguoiDung NguoiTao { get; set; }
        [ForeignKey(nameof(TinTuyenDungId))]
        [InverseProperty("GhiChuAdmin")]
        [Display(Name = "Tin tuyển dụng")]
        public virtual TinTuyenDung TinTuyenDung { get; set; }
        [ForeignKey(nameof(UngVienId))]
        [InverseProperty("GhiChuAdmin")]
        [Display(Name = "Ứng viên")]
        public virtual UngVien UngVien { get; set; }
    }
}
