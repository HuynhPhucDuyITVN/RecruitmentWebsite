using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RecruitFlow.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace RecruitFlow.Data
{
    public partial class DATA_WEBContext : DbContext
    {
        public DATA_WEBContext()
        {
        }

        public DATA_WEBContext(DbContextOptions<DATA_WEBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Cv> Cv { get; set; }
        public virtual DbSet<DonUngTuyen> DonUngTuyen { get; set; }
        public virtual DbSet<GhiChuAdmin> GhiChuAdmin { get; set; }
        public virtual DbSet<LichPhongVan> LichPhongVan { get; set; }
        public virtual DbSet<NganhNghe> NganhNghe { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<PhanLoaiNganhNghe> PhanLoaiNganhNghe { get; set; }
        public virtual DbSet<ThongBao> ThongBao { get; set; }
        public virtual DbSet<TinTuyenDung> TinTuyenDung { get; set; }
        public virtual DbSet<UngVien> UngVien { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-173GO3D\\SQLEXPRESS;Initial Catalog=DATA_WEB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 

            modelBuilder.Entity<Cv>(entity =>
            {
                entity.Property(e => e.ThoiGianTao).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.UngVien)
                    .WithMany(p => p.Cv)
                    .HasForeignKey(d => d.UngVienId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CV__UngVienID__24927208");
            });

            modelBuilder.Entity<DonUngTuyen>(entity =>
            {
                entity.Property(e => e.ThoiGianNop).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TrangThai).HasDefaultValueSql("('DangCho')");

                entity.HasOne(d => d.TinTuyenDung)
                    .WithMany(p => p.DonUngTuyen)
                    .HasForeignKey(d => d.TinTuyenDungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DonUngTuy__TinTu__1FCDBCEB");

                entity.HasOne(d => d.UngVien)
                    .WithMany(p => p.DonUngTuyen)
                    .HasForeignKey(d => d.UngVienId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DonUngTuy__UngVi__20C1E124");
            });

            modelBuilder.Entity<GhiChuAdmin>(entity =>
            {
                entity.HasKey(e => e.GhiChuId)
                    .HasName("PK__GhiChuAd__C4712D2110C59127");

                entity.Property(e => e.ThoiGianTao).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.NguoiTao)
                    .WithMany(p => p.GhiChuAdmin)
                    .HasForeignKey(d => d.NguoiTaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GhiChuAdm__Nguoi__300424B4");

                entity.HasOne(d => d.TinTuyenDung)
                    .WithMany(p => p.GhiChuAdmin)
                    .HasForeignKey(d => d.TinTuyenDungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GhiChuAdm__TinTu__2F10007B");

                entity.HasOne(d => d.UngVien)
                    .WithMany(p => p.GhiChuAdmin)
                    .HasForeignKey(d => d.UngVienId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GhiChuAdm__UngVi__2E1BDC42");
            });

            modelBuilder.Entity<LichPhongVan>(entity =>
            {
                entity.Property(e => e.ThoiGianTao).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.DonUngTuyen)
                    .WithMany(p => p.LichPhongVan)
                    .HasForeignKey(d => d.DonUngTuyenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LichPhong__DonUn__33D4B598");
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__NguoiDun__A9D105343B7FC075")
                    .IsUnique();

                entity.Property(e => e.ThoiGianTao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PhanLoaiNganhNghe>(entity =>
            {
                entity.HasKey(e => new { e.TinTuyenDungId, e.NganhNgheId })
                    .HasName("PK__PhanLoai__1A25D343645301AE");

                entity.HasOne(d => d.NganhNghe)
                    .WithMany(p => p.PhanLoaiNganhNghe)
                    .HasForeignKey(d => d.NganhNgheId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PhanLoaiN__Nganh__2A4B4B5E");

                entity.HasOne(d => d.TinTuyenDung)
                    .WithMany(p => p.PhanLoaiNganhNghe)
                    .HasForeignKey(d => d.TinTuyenDungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PhanLoaiN__TinTu__29572725");
            });

            modelBuilder.Entity<ThongBao>(entity =>
            {
                entity.Property(e => e.ThoiGianGui).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.NguoiDung)
                    .WithMany(p => p.ThongBao)
                    .HasForeignKey(d => d.NguoiDungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ThongBao__NguoiD__37A5467C");
            });

            modelBuilder.Entity<TinTuyenDung>(entity =>
            {
                entity.Property(e => e.DaCongKhai).HasDefaultValueSql("((0))");

                entity.Property(e => e.ThoiGianTao).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<UngVien>(entity =>
            {
                entity.HasOne(d => d.NguoiDung)
                    .WithMany(p => p.UngVien)
                    .HasForeignKey(d => d.NguoiDungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UngVien__NguoiDu__15502E78");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
