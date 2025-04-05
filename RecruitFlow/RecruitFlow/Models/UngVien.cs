using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecruitFlow.Models
{
    public partial class UngVien
    {
        public UngVien()
        {
            Cv = new HashSet<Cv>();
            DonUngTuyen = new HashSet<DonUngTuyen>();
            GhiChuAdmin = new HashSet<GhiChuAdmin>();
        }

        [Key]
        [Column("UngVienID")]
        public int UngVienId { get; set; }
        [Column("NguoiDungID")]
        public int NguoiDungId { get; set; }
        [StringLength(10)]
        public string GioiTinh { get; set; }
        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string TomTatHoSo { get; set; }

        [ForeignKey(nameof(NguoiDungId))]
        [InverseProperty("UngVien")]
        public virtual NguoiDung NguoiDung { get; set; }
        [InverseProperty("UngVien")]
        public virtual ICollection<Cv> Cv { get; set; }
        [InverseProperty("UngVien")]
        public virtual ICollection<DonUngTuyen> DonUngTuyen { get; set; }
        [InverseProperty("UngVien")]
        public virtual ICollection<GhiChuAdmin> GhiChuAdmin { get; set; }
    }
}
