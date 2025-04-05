using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecruitFlow.Models
{
    public partial class LichPhongVan
    {
        [Key]
        [Column("LichPhongVanID")]
        public int LichPhongVanId { get; set; }
        [Column("DonUngTuyenID")]
        public int DonUngTuyenId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ThoiGianPhongVan { get; set; }
        [StringLength(50)]
        public string HinhThucPhongVan { get; set; }
        [StringLength(255)]
        public string DiaDiemPhongVan { get; set; }
        [StringLength(100)]
        public string NguoiPhongVan { get; set; }
        public string GhiChu { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGianTao { get; set; }

        [ForeignKey(nameof(DonUngTuyenId))]
        [InverseProperty("LichPhongVan")]
        public virtual DonUngTuyen DonUngTuyen { get; set; }
    }
}
