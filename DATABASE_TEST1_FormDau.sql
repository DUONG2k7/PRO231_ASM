DROP DATABASE IF EXISTS PRO231;
CREATE DATABASE PRO231;
GO
USE PRO231;
GO

-----------IT-------------------
-- Bảng ROLES
CREATE TABLE ROLES (
    IDRole NVARCHAR(50) NOT NULL PRIMARY KEY,
    Role NVARCHAR(50)
);
GO

-- Bảng phòng ban
CREATE TABLE PhongBan (
    IDPhong INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    TenPhong NVARCHAR(100),
	IDRole NVARCHAR(50),
	SiSo INT,
    FOREIGN KEY (IDRole) REFERENCES ROLES(IDRole)
);
GO

-- Bảng ACCOUNTS
CREATE TABLE ACCOUNTS (
    IDAcc NVARCHAR(50) PRIMARY KEY NOT NULL,
    Username NVARCHAR(50) NOT NULL,
    Password VARBINARY(MAX) NOT NULL,
    IDRole NVARCHAR(50),
    RoleBanDau NVARCHAR(50),
    Trangthai BIT,
    FOREIGN KEY (IDRole) REFERENCES ROLES(IDRole)
);
GO

-- Bảng IT
CREATE TABLE IT (
    IDIT NVARCHAR(50) NOT NULL PRIMARY KEY,
    IDPhong INT,
    IdAcc NVARCHAR(50),
    TenIT NVARCHAR(50),
    Email NVARCHAR(50),
    SoDT NVARCHAR(15),
    GioiTinh BIT,
    Diachi NVARCHAR(50),
    Hinh VARBINARY(MAX),
    FOREIGN KEY (IDPhong) REFERENCES PhongBan(IDPhong),
    FOREIGN KEY (IdAcc) REFERENCES ACCOUNTS(IdAcc)
);
GO

-- Bảng LoginHistory
CREATE TABLE LoginHistory (
    IDLogin INT IDENTITY(1,1) PRIMARY KEY,
    IdAcc NVARCHAR(50),
    LichSuLogin DATETIME NOT NULL,
    FOREIGN KEY (IdAcc) REFERENCES ACCOUNTS(IdAcc)
);
GO

-- Bảng Tin tức
CREATE TABLE NEWS (
    IDTin INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(255),
    Content NVARCHAR(MAX),
    NgayDang DATETIME,
    Hinh VARBINARY(MAX),
	Trangthai BIT
);
GO

-----------CBDT-------------------
-- Bảng CBDT
CREATE TABLE CBDT (
    IDCBDT NVARCHAR(50) NOT NULL PRIMARY KEY,
    IDPhong INT,
    TenCBDT NVARCHAR(50),
    IdAcc NVARCHAR(50),
    Email NVARCHAR(50),
    SoDT NVARCHAR(15),
    GioiTinh BIT,
    Diachi NVARCHAR(50),
    Hinh VARBINARY(MAX),
    FOREIGN KEY (IDPhong) REFERENCES PhongBan(IDPhong),
    FOREIGN KEY (IdAcc) REFERENCES ACCOUNTS(IdAcc)
);
GO

-- Bảng kỳ học
CREATE TABLE KyHoc (
    IDKyHoc INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    TenKy NVARCHAR(50),
	NamBatDau DATE,
	NamKetThuc DATE,
    Trangthai BIT
);
GO

-- Bảng Môn học
CREATE TABLE MonHoc (
    IDMonHoc INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    TenMon NVARCHAR(50),
    SoTiet INT
);
GO

-- Bảng TEACHERS
CREATE TABLE TEACHERS (
    IDGV NVARCHAR(50) NOT NULL PRIMARY KEY,
    TenGV NVARCHAR(50),
    IdAcc NVARCHAR(50),
    Email NVARCHAR(50),
    SoDT NVARCHAR(15),
    GioiTinh BIT,
    Diachi NVARCHAR(50),
    Hinh VARBINARY(MAX),
    FOREIGN KEY (IdAcc) REFERENCES ACCOUNTS(IdAcc)
);
GO

-- Bảng CLASSES
CREATE TABLE CLASSES (
    IDLop NVARCHAR(50) NOT NULL PRIMARY KEY,
    ClassName NVARCHAR(50),
    SiSo INT, -- Số lượng học sinh trong lớp
	BuoiHoc BIT,
	Trangthai BIT
);
GO

-- Bảng STUDENTS
CREATE TABLE STUDENTS (
    IDSV NVARCHAR(50) NOT NULL PRIMARY KEY,
    IDLop NVARCHAR(50) NOT NULL, -- Mỗi học sinh thuộc một lớp
    TenSV NVARCHAR(50),
    IdAcc NVARCHAR(50),
    Email NVARCHAR(50),
    SoDT NVARCHAR(15),
    GioiTinh BIT,
    Diachi NVARCHAR(50),
    Hinh VARBINARY(MAX),
    FOREIGN KEY (IDLop) REFERENCES CLASSES(IDLop),
    FOREIGN KEY (IdAcc) REFERENCES ACCOUNTS(IdAcc)
);
GO

-- Bảng trung gian để thể hiện mối quan hệ nhiều - nhiều giữa Lớp học và Giáo viên
CREATE TABLE Class_Teacher (
    IDKyHoc INT NOT NULL,
    IDLop NVARCHAR(50) NOT NULL,
    IDGV NVARCHAR(50) NOT NULL,
	NgayChotLop DATE NOT NULL,
    PRIMARY KEY (IDKyHoc, IDLop, IDGV),
    FOREIGN KEY (IDKyHoc) REFERENCES KyHoc(IDKyHoc),
    FOREIGN KEY (IDLop) REFERENCES CLASSES(IDLop),
    FOREIGN KEY (IDGV) REFERENCES TEACHERS(IDGV)
);
GO

-- Bảng trung gian để thể hiện mối quan hệ nhiều - nhiều giữa Môn học và Giảng viên và kỳ học
CREATE TABLE MonHoc_GiangVien (
    IDKyHoc INT NOT NULL,
    IDMonHoc INT NOT NULL,
    IDGV NVARCHAR(50) NOT NULL,
	NgayChotViec DATE NOT NULL,
    PRIMARY KEY (IDKyHoc, IDMonHoc, IDGV),
    FOREIGN KEY (IDKyHoc) REFERENCES KyHoc(IDKyHoc),
    FOREIGN KEY (IDMonHoc) REFERENCES MonHoc(IDMonHoc),
    FOREIGN KEY (IDGV) REFERENCES TEACHERS(IDGV)
);
GO

-- Bảng trung gian để thể hiện mối quan hệ nhiều - nhiều giữa Môn học và Kỳ học
CREATE TABLE MonHoc_KyHoc (
    IDMonHoc INT NOT NULL,
    IDKyHoc INT NOT NULL,
    Trangthai BIT,
    PRIMARY KEY (IDMonHoc, IDKyHoc),
    FOREIGN KEY (IDMonHoc) REFERENCES MonHoc(IDMonHoc),
    FOREIGN KEY (IDKyHoc) REFERENCES KyHoc(IDKyHoc)
);
GO

-- Bảng điểm
CREATE TABLE Diem (
    IDDiem INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	IDKyHoc INT NOT NULL,
    IDSV NVARCHAR(50) NOT NULL,
	IDMonHoc INT NOT NULL,
    diem_lab FLOAT,
    diem_asm FLOAT,
    diem_thi FLOAT,
    diem_tb AS (ROUND(diem_lab * 0.2 + diem_asm * 0.3 + diem_thi * 0.5, 2)) PERSISTED,
    FOREIGN KEY (IDKyHoc) REFERENCES KyHoc(IDKyHoc),
    FOREIGN KEY (IDSV) REFERENCES STUDENTS(IDSV),
    FOREIGN KEY (IDMonHoc) REFERENCES MonHoc(IDMonHoc)
);
GO
-----------CBQL-------------------
-- Bảng CBQL
CREATE TABLE CBQL (
    IDCBQL NVARCHAR(50) NOT NULL PRIMARY KEY,
    IDPhong INT,
    TenCBQL NVARCHAR(50),
    IdAcc NVARCHAR(50),
    Email NVARCHAR(50),
    SoDT NVARCHAR(15),
    GioiTinh BIT,
    Diachi NVARCHAR(50),
    Hinh VARBINARY(MAX),
    FOREIGN KEY (IDPhong) REFERENCES PhongBan(IDPhong),
    FOREIGN KEY (IdAcc) REFERENCES ACCOUNTS(IdAcc)
);
GO

-- Bảng Lịch học
CREATE TABLE LichHoc (
    IDLichHoc INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    IDLop NVARCHAR(50) NOT NULL, -- Lớp học
    IDMonHoc INT NOT NULL, -- Môn học
    IDGV NVARCHAR(50) NOT NULL, -- Giáo viên giảng dạy
    IDKyHoc INT NOT NULL, -- Kỳ học
    LoaiNgay BIT NOT NULL,
    Ngay DATE NOT NULL, -- Ngày
    GioBatDau TIME NOT NULL, -- Giờ bắt đầu
    GioKetThuc TIME NOT NULL, -- Giờ kết thúc
    FOREIGN KEY (IDLop) REFERENCES CLASSES(IDLop),
    FOREIGN KEY (IDMonHoc) REFERENCES MonHoc(IDMonHoc),
    FOREIGN KEY (IDGV) REFERENCES TEACHERS(IDGV),
    FOREIGN KEY (IDKyHoc) REFERENCES KyHoc(IDKyHoc)
);
GO

-- Bảng Điểm Danh
CREATE TABLE DIEMDANH (
    IDDiemDanh INT IDENTITY(1,1) PRIMARY KEY,
    IDLichHoc INT NOT NULL,
    IDGV NVARCHAR(50) NOT NULL,
    IDSV NVARCHAR(50) NOT NULL,
    ThoiGianDiemDanh DATETIME NOT NULL,
    TrangThai BIT NOT NULL,
    GhiChu NVARCHAR(255),
    FOREIGN KEY (IDSV) REFERENCES STUDENTS(IDSV),
    FOREIGN KEY (IDGV) REFERENCES TEACHERS(IDGV),
    FOREIGN KEY (IDLichHoc) REFERENCES LichHoc(IDLichHoc)
);
GO

-- Thêm dữ liệu vào bảng ROLES
INSERT INTO ROLES (IDRole, Role)
VALUES 
('R00', 'ADMIN'),
('R01', 'IT'),
('R02', 'CBDT'),
('R03', 'CBQL'),
('R04', 'GV'),
('R05', 'SV'),
('R06', 'GLOBALBAN');
GO

-- Thêm dữ liệu vào bảng PhongBan
INSERT INTO PhongBan(TenPhong, IDRole)
VALUES 
('IT', 'R01'),
('CBDT', 'R02'),
('CBQL', 'R03');
GO

-- Thêm dữ liệu vào bảng ACCOUNTS
INSERT INTO ACCOUNTS (IdAcc, Username, Password, IDRole, Trangthai)
VALUES 
('A00', 'A', HASHBYTES('SHA2_256', 'A'), 'R00', 0),

('A01', 'I', HASHBYTES('SHA2_256', 'I'), 'R01', 0),
('A02', 'ADMIN2', HASHBYTES('SHA2_256', 'ADMIN2'), 'R01', 0),
('A03', 'ADMIN3', HASHBYTES('SHA2_256', 'ADMIN3'), 'R01', 0),

('A04', 'DT', HASHBYTES('SHA2_256', 'DT'), 'R02', 0),
('A05', 'CBDT2', HASHBYTES('SHA2_256', 'CBDT2'), 'R02', 0),
('A06', 'CBDT3', HASHBYTES('SHA2_256', 'CBDT3'), 'R02', 0),

('A07', 'QL', HASHBYTES('SHA2_256', 'QL'), 'R03', 0),

('A08', 'GV', HASHBYTES('SHA2_256', 'GV'), 'R04', 0),
('A09', 'GV2', HASHBYTES('SHA2_256', 'GV2'), 'R04', 0),
('A10', 'GV3', HASHBYTES('SHA2_256', 'GV3'), 'R04', 0),

('A11', 'SV', HASHBYTES('SHA2_256', 'SV'), 'R05', 0),
('A12', 'SV1', HASHBYTES('SHA2_256', 'SV1'), 'R05', 0),
('A13', 'SV2', HASHBYTES('SHA2_256', 'SV2'), 'R05', 0),
('A14', 'SV3', HASHBYTES('SHA2_256', 'SV3'), 'R05', 0),
('A15', 'SV4', HASHBYTES('SHA2_256', 'SV4'), 'R05', 0),
('A16', 'SV5', HASHBYTES('SHA2_256', 'SV5'), 'R05', 0);
GO

-- Thêm dữ liệu vào bảng CLASSES
INSERT INTO CLASSES (IDLop, ClassName, BuoiHoc, Trangthai)
VALUES 
('L00', N'Chưa phân lớp', 0, 0),
('L01', N'Lớp Toán A', 1, 0),
('L02', N'Lớp Văn B', 1, 0),
('L03', N'Lớp Anh C', 0, 0);
GO

-- Thêm dữ liệu vào bảng IT
INSERT INTO IT (IDIT, IDPhong, TenIT, IdAcc, Email, SoDT, GioiTinh, Diachi, Hinh)
VALUES ('IT01', 1, N'Trần Thị C', 'A01', 'c@example.com', '0987654321', 0, N'TP.HCM', NULL);

-- Thêm dữ liệu vào bảng CBDT
INSERT INTO CBDT (IDCBDT, IDPhong, TenCBDT, IdAcc, Email, SoDT, GioiTinh, Diachi, Hinh)
VALUES ('DT01', 2, N'Trần Thị B', 'A04', 'b@example.com', '0987654321', 0, N'TP.HCM', NULL);

-- Thêm dữ liệu vào bảng CBQL
INSERT INTO CBQL (IDCBQL, IDPhong, TenCBQL, IdAcc, Email, SoDT, GioiTinh, Diachi, Hinh)
VALUES ('QL01', 3, N'Nguyễn Văn A', 'A07', 'a@example.com', '0123456789', 1, N'Hà Nội', NULL);

-- Thêm dữ liệu vào bảng TEACHERS
INSERT INTO TEACHERS (IDGV, TenGV, IdAcc, Email, SoDT, Gioitinh, Diachi, Hinh)
VALUES 
('GV01', N'Nguyễn Văn A', 'A08', 'nguyenvana@gmail.com', '0987654321', 1, N'Hà Nội', NULL),
('GV02', N'Lê Thị B', 'A09', 'lethib@gmail.com', '0912345678', 0, N'Hồ Chí Minh', NULL),
('GV03', N'Phạm Văn C', 'A10', 'phamvanc@gmail.com', '0923456789', 1, N'Đà Nẵng', NULL),
('GV04', N'Trần Thị D', NULL, 'tranthid@gmail.com', '0934567890', 0, N'Cần Thơ', NULL),
('GV05', N'Hoàng Văn E', NULL, 'hoangvane@gmail.com', '0945678901', 1, N'Hải Phòng', NULL),
('GV06', N'Vũ Thị F', NULL, 'vuthif@gmail.com', '0956789012', 0, N'Bình Dương', NULL),
('GV07', N'Đặng Văn G', NULL, 'dangvang@gmail.com', '0967890123', 1, N'Nha Trang', NULL),
('GV08', N'Phan Thị H', NULL, 'phanthih@gmail.com', '0978901234', 0, N'Đà Lạt', NULL);
GO


-- Thêm dữ liệu vào bảng STUDENTS với tổng 60 sinh viên, sắp xếp IDSV tăng dần
INSERT INTO STUDENTS (IDSV, IDLop, TenSV, IdAcc, Email, SoDT, Gioitinh, Diachi, Hinh)
VALUES 
-- 12 sinh viên chưa phân lớp (L00)
('SV01', 'L00', N'Nguyễn Văn A', 'A11', 'nguyenvana@gmail.com', '0987654321', 1, N'Hà Nội', NULL),
('SV02', 'L00', N'Lê Thị B', 'A12', 'lethib@gmail.com', '0912345678', 0, N'Hồ Chí Minh', NULL),
('SV03', 'L00', N'Phạm Văn C', 'A13', 'phamvanc@gmail.com', '0923456789', 1, N'Đà Nẵng', NULL),
('SV04', 'L00', N'Trần Thị D', 'A14', 'tranthid@gmail.com', '0934567890', 0, N'Cần Thơ', NULL),
('SV05', 'L00', N'Hoàng Văn E', 'A15', 'hoangvane@gmail.com', '0945678901', 1, N'Hải Phòng', NULL),
('SV06', 'L00', N'Vũ Thị F', 'A16', 'vuthif@gmail.com', '0956789012', 0, N'Bình Dương', NULL),
('SV07', 'L00', N'Đặng Văn G', NULL, 'dangvang@gmail.com', '0967890123', 1, N'Nha Trang', NULL),
('SV08', 'L00', N'Phan Thị H', NULL, 'phanthih@gmail.com', '0978901234', 0, N'Đà Lạt', NULL),
('SV09', 'L00', N'Ngô Văn I', NULL, 'ngovani@gmail.com', '0989012345', 1, N'Huế', NULL),
('SV10', 'L00', N'Bùi Thị J', NULL, 'buithij@gmail.com', '0990123456', 0, N'Hà Nam', NULL),
('SV11', 'L00', N'Đỗ Văn K', NULL, 'dovank@gmail.com', '0901234567', 1, N'Thái Bình', NULL),
('SV12', 'L00', N'Đinh Thị L', NULL, 'dinhthil@gmail.com', '0913456789', 0, N'Bắc Giang', NULL),

-- 12 sinh viên lớp L01
('SV13', 'L01', N'Trần Văn D', NULL, 'tranvand@gmail.com', '0967891234', 1, N'Hà Nội', NULL),
('SV14', 'L01', N'Nguyễn Thị E', NULL, 'nguyenthie@gmail.com', '0934567890', 0, N'Hà Nội', NULL),
('SV15', 'L01', N'Lê Văn A', NULL, 'levana@gmail.com', '0978123456', 1, N'Hà Nội', NULL),
('SV16', 'L01', N'Phạm Thị B', NULL, 'phamthib@gmail.com', '0956784321', 0, N'Hà Nội', NULL),
('SV17', 'L01', N'Hoàng Văn C', NULL, 'hoangvanc@gmail.com', '0912345678', 1, N'Hà Nội', NULL),
('SV18', 'L01', N'Vũ Thị D', NULL, 'vuthid@gmail.com', '0987654321', 0, N'Hà Nội', NULL),
('SV19', 'L01', N'Đặng Văn E', NULL, 'dangvane@gmail.com', '0938765432', 1, N'Hà Nội', NULL),
('SV20', 'L01', N'Bùi Thị F', NULL, 'buithif@gmail.com', '0965432187', 0, N'Hà Nội', NULL),
('SV21', 'L01', N'Ngô Văn G', NULL, 'ngovang@gmail.com', '0976543210', 1, N'Hà Nội', NULL),
('SV22', 'L01', N'Đỗ Thị H', NULL, 'dothih@gmail.com', '0954321890', 0, N'Hà Nội', NULL),
('SV23', 'L01', N'Đinh Văn I', NULL, 'dinhvani@gmail.com', '0987894561', 1, N'Hà Nội', NULL),
('SV24', 'L01', N'Phan Thị J', NULL, 'phanthij@gmail.com', '0923456789', 0, N'Hà Nội', NULL),

-- 12 sinh viên lớp L02
('SV25', 'L02', N'Nguyễn Văn K', NULL, 'nguyenvank@gmail.com', '0943216789', 1, N'Hồ Chí Minh', NULL),
('SV26', 'L02', N'Lý Thị L', NULL, 'lythil@gmail.com', '0969876543', 0, N'Hồ Chí Minh', NULL),
('SV27', 'L02', N'Hoàng Văn M', NULL, 'hoangvanm@gmail.com', '0932109876', 1, N'Hồ Chí Minh', NULL),
('SV28', 'L02', N'Vũ Thị N', NULL, 'vuthin@gmail.com', '0910987654', 0, N'Hồ Chí Minh', NULL),
('SV29', 'L02', N'Đặng Văn O', NULL, 'dangvano@gmail.com', '0956781234', 1, N'Hồ Chí Minh', NULL),
('SV30', 'L02', N'Bùi Thị P', NULL, 'buithip@gmail.com', '0987656789', 0, N'Hồ Chí Minh', NULL),
('SV31', 'L02', N'Ngô Văn Q', NULL, 'ngovanq@gmail.com', '0967896543', 1, N'Hồ Chí Minh', NULL),
('SV32', 'L02', N'Đỗ Thị R', NULL, 'dothir@gmail.com', '0954321678', 0, N'Hồ Chí Minh', NULL),
('SV33', 'L02', N'Đinh Văn S', NULL, 'dinhvans@gmail.com', '0932105678', 1, N'Hồ Chí Minh', NULL),
('SV34', 'L02', N'Phan Thị T', NULL, 'phanthit@gmail.com', '0978654321', 0, N'Hồ Chí Minh', NULL),
('SV35', 'L02', N'Nguyễn Văn U', NULL, 'nguyenvanu@gmail.com', '0998765432', 1, N'Hồ Chí Minh', NULL),
('SV36', 'L02', N'Lê Thị V', NULL, 'lethiv@gmail.com', '0923456781', 0, N'Hồ Chí Minh', NULL),

-- 12 sinh viên lớp L03
('SV37', 'L03', N'Nguyễn Văn W', NULL, 'nguyenvanw@gmail.com', '0967890987', 1, N'Đà Nẵng', NULL),
('SV38', 'L03', N'Trần Thị X', NULL, 'tranthix@gmail.com', '0956785432', 0, N'Đà Nẵng', NULL),
('SV39', 'L03', N'Hoàng Văn Y', NULL, 'hoangvany@gmail.com', '0912348756', 1, N'Đà Nẵng', NULL),
('SV40', 'L03', N'Phạm Thị Z', NULL, 'phamthiz@gmail.com', '0934561897', 0, N'Đà Nẵng', NULL),
('SV41', 'L03', N'Lê Văn A1', NULL, 'levana1@gmail.com', '0987651342', 1, N'Đà Nẵng', NULL),
('SV42', 'L03', N'Vũ Thị B1', NULL, 'vuthib1@gmail.com', '0943216781', 0, N'Đà Nẵng', NULL),
('SV43', 'L03', N'Đặng Văn C1', NULL, 'dangvanc1@gmail.com', '0932107856', 1, N'Đà Nẵng', NULL),
('SV44', 'L03', N'Bùi Thị D1', NULL, 'buithid1@gmail.com', '0910987653', 0, N'Đà Nẵng', NULL),
('SV45', 'L03', N'Ngô Văn E1', NULL, 'ngovane1@gmail.com', '0956781232', 1, N'Đà Nẵng', NULL),
('SV46', 'L03', N'Đỗ Thị F1', NULL, 'dothif1@gmail.com', '0987656779', 0, N'Đà Nẵng', NULL),
('SV47', 'L03', N'Đinh Văn G1', NULL, 'dinhvang1@gmail.com', '0967896523', 1, N'Đà Nẵng', NULL),
('SV48', 'L03', N'Phan Thị H1', NULL, 'phanthih1@gmail.com', '0954321654', 0, N'Đà Nẵng', NULL);

-- Thêm dữ liệu vào bảng KyHoc
INSERT INTO KyHoc (TenKy, NamBatDau, NamKetThuc, Trangthai)
VALUES 
(N'Học kỳ 1', '2024-09-01', '2025-01-31', 1),
(N'Học kỳ 2', '2025-02-01', '2025-06-30', 0),
(N'Học kỳ 3', '2025-09-01', '2026-01-31', 0),
(N'Học kỳ 4', '2026-02-01', '2026-06-30', 0);

-- Thêm dữ liệu vào bảng MonHoc
INSERT INTO MonHoc (TenMon, SoTiet)
VALUES 
(N'Toán', 3),
(N'Văn', 2),
(N'Anh Văn', 3),
(N'Lý', 3),
(N'Hóa', 3);

-- Tạo Trigger INSERT
DROP TRIGGER IF EXISTS trg_Insert_KyHoc_TrangThai;
GO
CREATE TRIGGER trg_Insert_KyHoc_TrangThai
ON KyHoc
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM inserted WHERE Trangthai = 1)
    BEGIN
        UPDATE KyHoc
        SET Trangthai = 0
        WHERE IDKyHoc NOT IN (SELECT IDKyHoc FROM inserted WHERE Trangthai = 1);
    END
END;
GO

-- Tạo Trigger UPDATE
DROP TRIGGER IF EXISTS trg_Update_KyHoc_TrangThai;
GO
CREATE TRIGGER trg_Update_KyHoc_TrangThai
ON KyHoc
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM inserted WHERE Trangthai = 1)
    BEGIN
        UPDATE KyHoc
        SET Trangthai = 0
        WHERE IDKyHoc NOT IN (SELECT IDKyHoc FROM inserted WHERE Trangthai = 1);
    END
END;
GO

-- Xóa các bảng có khóa ngoại trước
DROP TABLE IF EXISTS DIEMDANH;
DROP TABLE IF EXISTS LichHoc;
DROP TABLE IF EXISTS PhongBan;
DROP TABLE IF EXISTS CBQL;
DROP TABLE IF EXISTS Diem;
DROP TABLE IF EXISTS MonHoc_KyHoc;
DROP TABLE IF EXISTS MonHoc_GiangVien;
DROP TABLE IF EXISTS Class_Teacher;
DROP TABLE IF EXISTS STUDENTS;
DROP TABLE IF EXISTS CLASSES;
DROP TABLE IF EXISTS TEACHERS;
DROP TABLE IF EXISTS MonHoc;
DROP TABLE IF EXISTS KyHoc;
DROP TABLE IF EXISTS CBDT;
DROP TABLE IF EXISTS NEWS;
DROP TABLE IF EXISTS LoginHistory;
DROP TABLE IF EXISTS IT;
DROP TABLE IF EXISTS ACCOUNTS;
DROP TABLE IF EXISTS ROLES;