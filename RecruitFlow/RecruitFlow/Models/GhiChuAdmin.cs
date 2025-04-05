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
        public int UngVienId { get; set; }
        [Column("TinTuyenDungID")]
        public int TinTuyenDungId { get; set; }
        [Column("NguoiTaoID")]
        public int NguoiTaoId { get; set; }
        public string GhiChu { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGianTao { get; set; }

        [ForeignKey(nameof(NguoiTaoId))]
        [InverseProperty(nameof(NguoiDung.GhiChuAdmin))]
        public virtual NguoiDung NguoiTao { get; set; }
        [ForeignKey(nameof(TinTuyenDungId))]
        [InverseProperty("GhiChuAdmin")]
        public virtual TinTuyenDung TinTuyenDung { get; set; }
        [ForeignKey(nameof(UngVienId))]
        [InverseProperty("GhiChuAdmin")]
        public virtual UngVien UngVien { get; set; }
    }
}
