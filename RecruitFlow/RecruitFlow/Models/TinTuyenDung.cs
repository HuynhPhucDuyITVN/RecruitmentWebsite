using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecruitFlow.Models
{
    public partial class TinTuyenDung
    {
        public TinTuyenDung()
        {
            DonUngTuyen = new HashSet<DonUngTuyen>();
            GhiChuAdmin = new HashSet<GhiChuAdmin>();
            PhanLoaiNganhNghe = new HashSet<PhanLoaiNganhNghe>();
        }

        [Key]
        [Column("TinTuyenDungID")]
        public int TinTuyenDungId { get; set; }
        [Required]
        [StringLength(200)]
        public string TieuDe { get; set; }
        [StringLength(100)]
        public string BoPhan { get; set; }
        [StringLength(20)]
        public string LoaiCongViec { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? LuongTu { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? LuongDen { get; set; }
        [StringLength(100)]
        public string DiaDiem { get; set; }
        [StringLength(100)]
        public string CapDoKinhNghiem { get; set; }
        public string MoTa { get; set; }
        public string YeuCau { get; set; }
        public string PhucLoi { get; set; }
        [Column(TypeName = "date")]
        public DateTime? HanChot { get; set; }
        public bool? DaCongKhai { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGianCongKhai { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGianTao { get; set; }

        [InverseProperty("TinTuyenDung")]
        public virtual ICollection<DonUngTuyen> DonUngTuyen { get; set; }
        [InverseProperty("TinTuyenDung")]
        public virtual ICollection<GhiChuAdmin> GhiChuAdmin { get; set; }
        [InverseProperty("TinTuyenDung")]
        public virtual ICollection<PhanLoaiNganhNghe> PhanLoaiNganhNghe { get; set; }
    }
}
