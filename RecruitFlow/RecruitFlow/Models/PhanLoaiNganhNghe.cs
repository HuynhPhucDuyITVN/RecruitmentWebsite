using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecruitFlow.Models
{
    public partial class PhanLoaiNganhNghe
    {
        [Key]
        [Column("TinTuyenDungID")]
        public int TinTuyenDungId { get; set; }
        [Key]
        [Column("NganhNgheID")]
        public int NganhNgheId { get; set; }

        [ForeignKey(nameof(NganhNgheId))]
        [InverseProperty("PhanLoaiNganhNghe")]
        public virtual NganhNghe NganhNghe { get; set; }
        [ForeignKey(nameof(TinTuyenDungId))]
        [InverseProperty("PhanLoaiNganhNghe")]
        public virtual TinTuyenDung TinTuyenDung { get; set; }
    }
}
