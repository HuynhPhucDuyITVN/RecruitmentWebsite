USE DATA_WEB
GO
-- 1. NguoiDung
INSERT INTO NguoiDung (Email, MatKhauHash, TenDayDu, SoDienThoai, VaiTro) VALUES
('user1@gmail.com', 'hash1', N'Nguyễn Văn A', '0900000001', 'UngVien'),
('user2@gmail.com', 'hash2', N'Lê Thị B', '0900000002', 'UngVien'),
('user3@gmail.com', 'hash3', N'Trần Văn C', '0900000003', 'UngVien'),
('user4@gmail.com', 'hash4', N'Phạm Thị D', '0900000004', 'UngVien'),
('user5@gmail.com', 'hash5', N'Hoàng Văn E', '0900000005', 'UngVien'),
('user6@gmail.com', 'hash6', N'Đặng Thị F', '0900000006', 'UngVien'),
('admin1@corp.com', 'hash7', N'Admin One', '0900000007', 'Admin'),
('admin2@corp.com', 'hash8', N'Admin Two', '0900000008', 'Admin'),
('hr1@corp.com', 'hash9', N'HR Manager', '0900000009', 'Admin'),
('hr2@corp.com', 'hash10', N'HR Assistant', '0900000010', 'Admin');

-- 2. UngVien
INSERT INTO UngVien (NguoiDungID, GioiTinh, NgaySinh, DiaChi, TomTatHoSo) VALUES
(1, N'Nam', '1995-01-01', N'Cần Thơ', N'Kinh nghiệm IT'),
(2, N'Nữ', '1996-02-02', N'Hà Nội', N'Marketing sáng tạo'),
(3, N'Nam', '1994-03-03', N'Đà Nẵng', N'UX/UI design'),
(4, N'Nữ', '1993-04-04', N'Sài Gòn', N'HR chuyên nghiệp'),
(5, N'Nam', '1992-05-05', N'Hải Phòng', N'QA kỹ lưỡng'),
(6, N'Nữ', '1990-06-06', N'Cần Thơ', N'Thực tập sinh tài năng');

-- 3. TinTuyenDung
INSERT INTO TinTuyenDung (TieuDe, BoPhan, LoaiCongViec, LuongTu, LuongDen, DiaDiem, CapDoKinhNghiem, MoTa, YeuCau, PhucLoi, HanChot, DaCongKhai, ThoiGianCongKhai) VALUES
(N'Lập trình viên .NET', N'IT', 'ToanThoiGian', 10000000, 20000000, N'Cần Thơ', N'Trên 1 năm', N'Mô tả 1', N'Yêu cầu 1', N'Phúc lợi 1', '2025-04-30', 1, GETDATE()),
(N'Chuyên viên Marketing', N'Marketing', 'ToanThoiGian', 8000000, 12000000, N'Hà Nội', N'Trên 2 năm', N'Mô tả 2', N'Yêu cầu 2', N'Phúc lợi 2', '2025-05-05', 1, GETDATE()),
(N'Thực tập sinh IT', N'IT', 'ThucTap', 2000000, 4000000, N'Sài Gòn', N'Mới tốt nghiệp', N'Mô tả 3', N'Yêu cầu 3', N'Phúc lợi 3', '2025-04-28', 1, GETDATE()),
(N'Nhân viên QA', N'QA', 'ToanThoiGian', 9000000, 15000000, N'Đà Nẵng', N'1-2 năm', N'Mô tả 4', N'Yêu cầu 4', N'Phúc lợi 4', '2025-05-01', 1, GETDATE()),
(N'HR Executive', N'HR', 'ToanThoiGian', 10000000, 18000000, N'Hồ Chí Minh', N'Trên 3 năm', N'Mô tả 5', N'Yêu cầu 5', N'Phúc lợi 5', '2025-05-10', 1, GETDATE()),
(N'Thực tập sinh QA', N'QA', 'ThucTap', 3000000, 5000000, N'Cần Thơ', N'Fresher', N'Mô tả 6', N'Yêu cầu 6', N'Phúc lợi 6', '2025-05-15', 1, GETDATE());

-- 4. NganhNghe
INSERT INTO NganhNghe (TenNganhNghe) VALUES
(N'Công nghệ thông tin'), (N'Marketing'), (N'Nhân sự'), (N'QA'), (N'UX/UI'),
(N'Phát triển phần mềm'), (N'Kinh doanh'), (N'Tư vấn'), (N'Dịch vụ khách hàng'), (N'Kế toán');

-- 5. PhanLoaiNganhNghe
INSERT INTO PhanLoaiNganhNghe (TinTuyenDungID, NganhNgheID) VALUES
(1, 1), (2, 2), (3, 1), (4, 4), (5, 3), (6, 4);

-- 6. DonUngTuyen
INSERT INTO DonUngTuyen (TinTuyenDungID, UngVienID, CVURL, ThuXinViec, TrangThai) VALUES
(1, 1, 'cv_user1.pdf', N'Xin việc vị trí IT', 'DaXem'),
(2, 2, 'cv_user2.pdf', N'Tôi tự tin làm Marketing', 'DangCho'),
(3, 3, 'cv_user3.pdf', N'Muốn học hỏi thực tế', 'PhongVan'),
(4, 4, 'cv_user4.pdf', N'Đã có kinh nghiệm QA', 'ChapNhan'),
(5, 5, 'cv_user5.pdf', N'Tôi đam mê ngành HR', 'TuChoi'),
(6, 6, 'cv_user6.pdf', N'Muốn thử sức với QA', 'DangCho');

-- 7. CV
INSERT INTO CV (UngVienID, TieuDe, FileURL) VALUES
(1, N'CV IT 1', 'cv_user1.pdf'),
(2, N'CV Marketing', 'cv_user2.pdf'),
(3, N'CV Thực tập', 'cv_user3.pdf'),
(4, N'CV QA', 'cv_user4.pdf'),
(5, N'CV HR', 'cv_user5.pdf'),
(6, N'CV QA Fresher', 'cv_user6.pdf');

-- 8. GhiChuAdmin
INSERT INTO GhiChuAdmin (UngVienID, TinTuyenDungID, NguoiTaoID, GhiChu) VALUES
(1, 1, 7, N'Ứng viên có kinh nghiệm tốt'),
(2, 2, 8, N'Cần đánh giá thêm qua phỏng vấn'),
(3, 3, 9, N'Tiềm năng, định hướng tốt'),
(4, 4, 10, N'Có thể thử sức với QA manual'),
(5, 5, 7, N'Kiến thức HR ổn, thiếu kỹ năng mềm'),
(6, 6, 8, N'Mong muốn học hỏi cao');

-- 9. LichPhongVan
INSERT INTO LichPhongVan (DonUngTuyenID, ThoiGianPhongVan, HinhThucPhongVan, DiaDiemPhongVan, NguoiPhongVan, GhiChu) VALUES
(3, '2025-04-10 10:00', N'Trực tiếp', N'Văn phòng Cần Thơ', N'HR Manager', N'Lưu ý đúng giờ'),
(4, '2025-04-12 15:00', N'Video call', N'Trên Google Meet', N'Admin One', N'Phỏng vấn online'),
(2, '2025-04-11 09:30', N'Trực tiếp', N'Hà Nội', N'HR Assistant', N'Test kỹ năng giao tiếp');

-- 10. ThongBao
INSERT INTO ThongBao (NguoiDungID, LoaiSuKien, MaDinhDanhLienQuan, NoiDungThongBao) VALUES
(1, 'PhongVanLichMoi', 3, N'Bạn có lịch phỏng vấn ngày 10/04'),
(2, 'PhongVanLichMoi', 2, N'Bạn có lịch phỏng vấn ngày 11/04'),
(3, 'PhongVanLichMoi', 4, N'Phỏng vấn đã lên lịch cho bạn'),
(4, 'DonUngTuyenChapNhan', 4, N'Đơn ứng tuyển của bạn đã được chấp nhận'),
(5, 'DonUngTuyenBiTuChoi', 5, N'Rất tiếc đơn ứng tuyển của bạn bị từ chối'),
(6, 'DonUngTuyenDangCho', 6, N'Đơn của bạn đang chờ xử lý');
