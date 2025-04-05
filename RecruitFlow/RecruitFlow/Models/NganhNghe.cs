using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecruitFlow.Models
{
    public partial class NganhNghe
    {
        public NganhNghe()
        {
            PhanLoaiNganhNghe = new HashSet<PhanLoaiNganhNghe>();
        }

        [Key]
        [Column("NganhNgheID")]
        public int NganhNgheId { get; set; }
        [StringLength(100)]
        public string TenNganhNghe { get; set; }

        [InverseProperty("NganhNghe")]
        public virtual ICollection<PhanLoaiNganhNghe> PhanLoaiNganhNghe { get; set; }
    }
}
