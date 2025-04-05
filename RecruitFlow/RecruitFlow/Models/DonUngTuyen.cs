using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecruitFlow.Models
{
    public partial class DonUngTuyen
    {
        public DonUngTuyen()
        {
            LichPhongVan = new HashSet<LichPhongVan>();
        }

        [Key]
        [Column("DonUngTuyenID")]
        public int DonUngTuyenId { get; set; }
        [Column("TinTuyenDungID")]
        public int TinTuyenDungId { get; set; }
        [Column("UngVienID")]
        public int UngVienId { get; set; }
        [Column("CVURL")]
        [StringLength(255)]
        public string Cvurl { get; set; }
        public string ThuXinViec { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGianNop { get; set; }
        [StringLength(20)]
        public string TrangThai { get; set; }

        [ForeignKey(nameof(TinTuyenDungId))]
        [InverseProperty("DonUngTuyen")]
        public virtual TinTuyenDung TinTuyenDung { get; set; }
        [ForeignKey(nameof(UngVienId))]
        [InverseProperty("DonUngTuyen")]
        public virtual UngVien UngVien { get; set; }
        [InverseProperty("DonUngTuyen")]
        public virtual ICollection<LichPhongVan> LichPhongVan { get; set; }
    }
}
