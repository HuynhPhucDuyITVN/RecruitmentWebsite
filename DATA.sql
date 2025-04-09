CREATE DATABASE DATA_WEB
GO
--DROP DATABASE DATA_WEB
USE DATA_WEB
GO


-- ============================================
-- 1. NGUOI_DUNG: Thong tin nguoi dung (ung vien, admin)
-- ============================================
CREATE TABLE NguoiDung (
    NguoiDungID INT IDENTITY(1,1) PRIMARY KEY, -- Ma dinh danh duy nhat cua nguoi dung
    Email NVARCHAR(100) UNIQUE NOT NULL, -- Dia chi email cua nguoi dung, phai la duy nhat
    MatKhauHash NVARCHAR(255) NOT NULL, -- Ma bam cua mat khau nguoi dung
    TenDayDu NVARCHAR(100), -- Ten day du cua nguoi dung
    SoDienThoai NVARCHAR(15), -- So dien thoai cua nguoi dung
    VaiTro NVARCHAR(20) CHECK (VaiTro IN ('UngVien', 'Admin')) NOT NULL, -- Vai tro cua nguoi dung: 'UngVien' (ung vien) hoac 'Admin' (quan tri vien)
    ThoiGianTao DATETIME DEFAULT GETDATE() -- Thoi gian nguoi dung duoc tao tai khoan
);

-- ============================================
-- 2. UNG_VIEN: Ho so chi tiet ung vien
-- ============================================
CREATE TABLE UngVien (
    UngVienID INT IDENTITY(1,1) PRIMARY KEY, -- Ma dinh danh duy nhat cua ung vien
    NguoiDungID INT NOT NULL, -- Lien ket toi bang NguoiDung de xac dinh nguoi dung la ung vien
    GioiTinh NVARCHAR(10), -- Gioi tinh cua ung vien
    NgaySinh DATE, -- Ngay sinh cua ung vien
    DiaChi NVARCHAR(MAX), -- Dia chi cua ung vien
    TomTatHoSo NVARCHAR(MAX), -- Tom tat ho so cua ung vien
    FOREIGN KEY (NguoiDungID) REFERENCES NguoiDung(NguoiDungID) -- Lien ket toi bang NguoiDung de xac dinh nguoi dung la ung vien
);

-- ============================================
-- 3. TIN_TUYEN_DUNG: Tin tuyen dung noi bo
-- ============================================
CREATE TABLE TinTuyenDung (
    TinTuyenDungID INT IDENTITY(1,1) PRIMARY KEY, -- Ma dinh danh duy nhat cua tin tuyen dung
    TieuDe NVARCHAR(200) NOT NULL, -- Tieu de cong viec
    BoPhan NVARCHAR(100), -- Bo phan tuyen dung
    LoaiCongViec NVARCHAR(200) CHECK (LoaiCongViec IN (N'Toàn thời gian', N'Bán thời gian', N'Thực tập')), -- Loai cong viec: 'ToanThoiGian', 'BanThoiGian', hoac 'ThucTap'
    LuongTu DECIMAL(10,2), -- Muc luong bat dau cua cong viec
    LuongDen DECIMAL(10,2), -- Muc luong toi da cua cong viec
    DiaDiem NVARCHAR(100), -- Dia diem lam viec
    CapDoKinhNghiem NVARCHAR(100), -- Cap do kinh nghiem yeu cau cho cong viec
    MoTa NVARCHAR(MAX), -- Mo ta cong viec
    YeuCau NVARCHAR(MAX), -- Yeu cau cho cong viec
    PhucLoi NVARCHAR(MAX), -- Phuc loi khi lam viec
    HanChot DATE, -- Han chot nop ho so
    DaCongKhai BIT DEFAULT 0, -- Trang thai cong khai cua tin tuyen dung
    ThoiGianCongKhai DATETIME, -- Thoi gian cong khai tin tuyen dung
    ThoiGianTao DATETIME DEFAULT GETDATE() -- Thoi gian tao tin tuyen dung
);


-- ============================================
-- 4. DON_UNG_TUYEN: Don ung tuyen
-- ============================================
CREATE TABLE DonUngTuyen (
    DonUngTuyenID INT IDENTITY(1,1) PRIMARY KEY, -- Ma dinh danh duy nhat cua don ung tuyen
    TinTuyenDungID INT NOT NULL, -- Lien ket toi bang TinTuyenDung, xac dinh cong viec ma ung vien da ung tuyen
    UngVienID INT NOT NULL, -- Lien ket toi bang UngVien, xac dinh ung vien nop don
    CVURL NVARCHAR(255), -- Lien ket toi CV cua ung vien
    ThuXinViec NVARCHAR(MAX), -- Thu xin viec cua ung vien
    ThoiGianNop DATETIME DEFAULT GETDATE(), -- Thoi gian ung vien nop don
    TrangThai NVARCHAR(200) CHECK (TrangThai IN (N'Đang chờ', N'Đã xem', N'Phỏng vấn', N'Từ chối', N'Chấp nhận')) DEFAULT N'Đang chờ', -- Trang thai cua don ung tuyen
    FOREIGN KEY (TinTuyenDungID) REFERENCES TinTuyenDung(TinTuyenDungID), -- Lien ket toi bang TinTuyenDung
    FOREIGN KEY (UngVienID) REFERENCES UngVien(UngVienID) -- Lien ket toi bang UngVien
);

-- ============================================
-- 5. CV: CV cua ung vien
-- ============================================
CREATE TABLE CV (
    CVID INT IDENTITY(1,1) PRIMARY KEY, -- Ma dinh danh duy nhat cua CV
    UngVienID INT NOT NULL, -- Lien ket toi bang UngVien, xac dinh ung vien co CV nay
    TieuDe NVARCHAR(100), -- Tieu de cua CV
    FileURL NVARCHAR(255), -- Duong dan toi file CV
    ThoiGianTao DATETIME DEFAULT GETDATE(), -- Thoi gian tao CV
    FOREIGN KEY (UngVienID) REFERENCES UngVien(UngVienID) -- Lien ket toi bang UngVien
);

-- ============================================
-- 6. NGANH_NGHE: Nganh nghe
-- ============================================
CREATE TABLE NganhNghe (
    NganhNgheID INT IDENTITY(1,1) PRIMARY KEY, -- Ma dinh danh duy nhat cua nganh nghe
    TenNganhNghe NVARCHAR(100) -- Ten nganh nghe (vi du: IT, Marketing, Sales, v.v.)
);

-- ============================================
-- 7. PHAN_LOAI_NGANH_NGHE: Phan loai nganh nghe cho job
-- ============================================
CREATE TABLE PhanLoaiNganhNghe (
    TinTuyenDungID INT NOT NULL, -- Lien ket toi bang TinTuyenDung, xac dinh cong viec
    NganhNgheID INT NOT NULL, -- Lien ket toi bang NganhNghe, xac dinh nganh nghe cua cong viec
    PRIMARY KEY (TinTuyenDungID, NganhNgheID), -- Khoa chinh bao gom ca TinTuyenDungID va NganhNgheID
    FOREIGN KEY (TinTuyenDungID) REFERENCES TinTuyenDung(TinTuyenDungID), -- Lien ket toi bang TinTuyenDung
    FOREIGN KEY (NganhNgheID) REFERENCES NganhNghe(NganhNgheID) -- Lien ket toi bang NganhNghe
);

-- ============================================
-- 8. GHI_CHU_ADMIN: Ghi chu cua HR voi ung vien
-- ============================================
CREATE TABLE GhiChuAdmin (
    GhiChuID INT IDENTITY(1,1) PRIMARY KEY, -- Ma dinh danh duy nhat cua ghi chu
    UngVienID INT NOT NULL, -- Lien ket toi bang UngVien, xac dinh ung vien duoc ghi chu
    TinTuyenDungID INT NOT NULL, -- Lien ket toi bang TinTuyenDung, xac dinh cong viec ma ung vien ung tuyen
    NguoiTaoID INT NOT NULL, -- Lien ket toi bang NguoiDung, xac dinh nguoi tao ghi chu (thuong la admin hoac HR)
    GhiChu NVARCHAR(MAX), -- Noi dung ghi chu cua HR
    ThoiGianTao DATETIME DEFAULT GETDATE(), -- Thoi gian ghi chu duoc tao
    FOREIGN KEY (UngVienID) REFERENCES UngVien(UngVienID), -- Lien ket toi bang UngVien
    FOREIGN KEY (TinTuyenDungID) REFERENCES TinTuyenDung(TinTuyenDungID), -- Lien ket toi bang TinTuyenDung
    FOREIGN KEY (NguoiTaoID) REFERENCES NguoiDung(NguoiDungID) -- Lien ket toi bang NguoiDung
);

-- ============================================
-- 9. LICH_PHONG_VAN: Lich phong van
-- ============================================
CREATE TABLE LichPhongVan (
    LichPhongVanID INT IDENTITY(1,1) PRIMARY KEY, -- Ma dinh danh duy nhat cua lich phong van
    DonUngTuyenID INT NOT NULL, -- Lien ket toi bang DonUngTuyen, xac dinh don ung tuyen co lich phong van
    ThoiGianPhongVan DATETIME NOT NULL, -- Thoi gian phong van
    HinhThucPhongVan NVARCHAR(50), -- Hinh thuc phong van (vi du: truc tiep, qua video)
    DiaDiemPhongVan NVARCHAR(255), -- Dia diem phong van
    NguoiPhongVan NVARCHAR(100), -- Nguoi phong van
    GhiChu NVARCHAR(MAX), -- Các ghi chú về phỏng vấn
    ThoiGianTao DATETIME DEFAULT GETDATE(), -- Thời gian tạo lịch phỏng vấn
    FOREIGN KEY (DonUngTuyenID) REFERENCES DonUngTuyen(DonUngTuyenID) -- Liên kết tới bảng DonUngTuyen
);

-- ============================================
-- 10. THONG_BAO: Lich su gui email/thong bao
-- ============================================
CREATE TABLE ThongBao (
    ThongBaoID INT IDENTITY(1,1) PRIMARY KEY, -- Ma dinh danh duy nhat cua su kien thong bao
    NguoiDungID INT NOT NULL, -- Lien ket toi bang NguoiDung, xac dinh nguoi nhan thong bao
    LoaiSuKien NVARCHAR(50), -- Loai su kien thong bao (vi du: 'PhongVanLichMoi', 'DonUngTuyenBiTuChoi')
    MaDinhDanhLienQuan INT, -- Ma dinh danh cua doi tuong lien quan den su kien (co the la TinTuyenDungID, DonUngTuyenID, v.v.)
    NoiDungThongBao NVARCHAR(MAX), -- Noi dung thong bao
    ThoiGianGui DATETIME DEFAULT GETDATE(), -- Thoi gian thong bao duoc gui
    FOREIGN KEY (NguoiDungID) REFERENCES NguoiDung(NguoiDungID) -- Lien ket toi bang NguoiDung
);
