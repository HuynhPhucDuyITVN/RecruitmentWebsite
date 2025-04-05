using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecruitFlow.Models
{
    public partial class ThongBao
    {
        [Key]
        [Column("ThongBaoID")]
        public int ThongBaoId { get; set; }
        [Column("NguoiDungID")]
        public int NguoiDungId { get; set; }
        [StringLength(50)]
        public string LoaiSuKien { get; set; }
        public int? MaDinhDanhLienQuan { get; set; }
        public string NoiDungThongBao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGianGui { get; set; }

        [ForeignKey(nameof(NguoiDungId))]
        [InverseProperty("ThongBao")]
        public virtual NguoiDung NguoiDung { get; set; }
    }
}
