using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecruitFlow.Models
{
    public partial class NguoiDung
    {
        public NguoiDung()
        {
            GhiChuAdmin = new HashSet<GhiChuAdmin>();
            ThongBao = new HashSet<ThongBao>();
            UngVien = new HashSet<UngVien>();
        }

        [Key]
        [Column("NguoiDungID")]
        public int NguoiDungId { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string MatKhauHash { get; set; }
        [StringLength(100)]
        public string TenDayDu { get; set; }
        [StringLength(15)]
        public string SoDienThoai { get; set; }
        [Required]
        [StringLength(20)]
        public string VaiTro { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGianTao { get; set; }

        [InverseProperty("NguoiTao")]
        public virtual ICollection<GhiChuAdmin> GhiChuAdmin { get; set; }
        [InverseProperty("NguoiDung")]
        public virtual ICollection<ThongBao> ThongBao { get; set; }
        [InverseProperty("NguoiDung")]
        public virtual ICollection<UngVien> UngVien { get; set; }
    }
}
