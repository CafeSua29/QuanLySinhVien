USE [master]
GO
/****** Object:  Database [QuanLySinhVien]    Script Date: 10/19/2023 9:56:19 AM ******/
CREATE DATABASE [QuanLySinhVien]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLySinhVien', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\QuanLySinhVien.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLySinhVien_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\QuanLySinhVien_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QuanLySinhVien] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLySinhVien].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLySinhVien] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLySinhVien] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLySinhVien] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLySinhVien] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLySinhVien] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLySinhVien] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLySinhVien] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLySinhVien] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLySinhVien] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLySinhVien] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLySinhVien] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLySinhVien] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLySinhVien] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLySinhVien] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLySinhVien] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLySinhVien] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLySinhVien] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLySinhVien] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLySinhVien] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLySinhVien] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLySinhVien] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLySinhVien] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLySinhVien] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLySinhVien] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLySinhVien] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLySinhVien] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLySinhVien] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLySinhVien] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLySinhVien] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLySinhVien] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QuanLySinhVien] SET QUERY_STORE = ON
GO
ALTER DATABASE [QuanLySinhVien] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QuanLySinhVien]
GO
/****** Object:  Table [dbo].[ChucNang]    Script Date: 10/19/2023 9:56:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucNang](
	[MaCN] [varchar](50) NOT NULL,
	[TenCN] [nvarchar](50) NULL,
 CONSTRAINT [PK_ChucNang] PRIMARY KEY CLUSTERED 
(
	[MaCN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KetQua]    Script Date: 10/19/2023 9:56:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KetQua](
	[MaSV] [nvarchar](50) NOT NULL,
	[MaMH] [nvarchar](50) NOT NULL,
	[Diem] [real] NULL,
 CONSTRAINT [FK_MaSV_MaMH] PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC,
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Khoa]    Script Date: 10/19/2023 9:56:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Khoa](
	[MaKhoa] [nvarchar](50) NOT NULL,
	[TenKhoa] [nvarchar](50) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_Khoa] PRIMARY KEY CLUSTERED 
(
	[MaKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lop]    Script Date: 10/19/2023 9:56:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[MaLop] [nvarchar](50) NOT NULL,
	[TenLop] [nvarchar](50) NULL,
	[TrangThai] [bit] NULL,
	[MaKhoa] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Lop] PRIMARY KEY CLUSTERED 
(
	[MaLop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 10/19/2023 9:56:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[MaMH] [nvarchar](50) NOT NULL,
	[TenMH] [nvarchar](50) NULL,
	[SoTin] [int] NULL,
	[BaoLuu] [bit] NULL,
 CONSTRAINT [PK_MonHoc] PRIMARY KEY CLUSTERED 
(
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 10/19/2023 9:56:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[MaVT] [varchar](50) NOT NULL,
	[MaCN] [varchar](50) NOT NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhanQuyen] PRIMARY KEY CLUSTERED 
(
	[MaVT] ASC,
	[MaCN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuanTriVien]    Script Date: 10/19/2023 9:56:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanTriVien](
	[UserName] [varchar](50) NOT NULL,
	[TenQTV] [nvarchar](50) NULL,
 CONSTRAINT [PK_QuanTriVien] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 10/19/2023 9:56:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[MaSV] [nvarchar](50) NOT NULL,
	[HoSV] [nvarchar](50) NULL,
	[TenSV] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[QueQuan] [nvarchar](50) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
	[MaLop] [nvarchar](50) NULL,
 CONSTRAINT [PK_SinhVien] PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 10/19/2023 9:56:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThanhVien]    Script Date: 10/19/2023 9:56:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThanhVien](
	[UserName] [varchar](50) NOT NULL,
	[HoTV] [nvarchar](50) NULL,
	[TenTV] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[QueQuan] [nvarchar](50) NULL,
	[SoDienThoai] [int] NULL,
	[MaVT] [varchar](50) NULL,
 CONSTRAINT [PK_ThanhVien] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VaiTro]    Script Date: 10/19/2023 9:56:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VaiTro](
	[MaVT] [varchar](50) NOT NULL,
	[TenVT] [nvarchar](50) NULL,
 CONSTRAINT [PK_VaiTro] PRIMARY KEY CLUSTERED 
(
	[MaVT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChucNang] ([MaCN], [TenCN]) VALUES (N'CTSV', N'Xem danh sách sinh viên')
INSERT [dbo].[ChucNang] ([MaCN], [TenCN]) VALUES (N'DSSV', N'Xem danh sách sinnh viên')
INSERT [dbo].[ChucNang] ([MaCN], [TenCN]) VALUES (N'SSV', N'Sửa sinh viên')
INSERT [dbo].[ChucNang] ([MaCN], [TenCN]) VALUES (N'TKSV', N'Tìm kiếm sinh viên')
INSERT [dbo].[ChucNang] ([MaCN], [TenCN]) VALUES (N'TSV', N'Thêm sinh viên')
INSERT [dbo].[ChucNang] ([MaCN], [TenCN]) VALUES (N'XFE', N'Xuất file excel')
INSERT [dbo].[ChucNang] ([MaCN], [TenCN]) VALUES (N'XSV', N'Xóa sinh viên')
GO
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa], [TrangThai]) VALUES (N'KhoaCK', N'Cơ Khí', 0)
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa], [TrangThai]) VALUES (N'KhoaCNTT', N'Công nghệ thông tin', 0)
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa], [TrangThai]) VALUES (N'KhoaD-DT', N'Điện - Điện tử', 0)
INSERT [dbo].[Khoa] ([MaKhoa], [TenKhoa], [TrangThai]) VALUES (N'KhoaKTXD', N'Kĩ thuật xây dựng', 0)
GO
INSERT [dbo].[Lop] ([MaLop], [TenLop], [TrangThai], [MaKhoa]) VALUES (N'Lop66IT1', N'66IT1', 0, N'KhoaCNTT')
INSERT [dbo].[Lop] ([MaLop], [TenLop], [TrangThai], [MaKhoa]) VALUES (N'Lop66IT2', N'66IT2', 0, N'KhoaCNTT')
INSERT [dbo].[Lop] ([MaLop], [TenLop], [TrangThai], [MaKhoa]) VALUES (N'Lop66IT3', N'66IT3', 0, N'KhoaCNTT')
INSERT [dbo].[Lop] ([MaLop], [TenLop], [TrangThai], [MaKhoa]) VALUES (N'Lop66IT4', N'66IT4', 0, N'KhoaCNTT')
INSERT [dbo].[Lop] ([MaLop], [TenLop], [TrangThai], [MaKhoa]) VALUES (N'Lop66ME1', N'66ME1', 0, N'KhoaCK')
INSERT [dbo].[Lop] ([MaLop], [TenLop], [TrangThai], [MaKhoa]) VALUES (N'Lop66ME2', N'66ME2', 0, N'KhoaCK')
INSERT [dbo].[Lop] ([MaLop], [TenLop], [TrangThai], [MaKhoa]) VALUES (N'Lop66ME3', N'66ME3', 0, N'KhoaCK')
GO
INSERT [dbo].[PhanQuyen] ([MaVT], [MaCN], [GhiChu]) VALUES (N'QuanLiTat', N'CTSV', NULL)
INSERT [dbo].[PhanQuyen] ([MaVT], [MaCN], [GhiChu]) VALUES (N'QuanLiTat', N'DSSV', NULL)
INSERT [dbo].[PhanQuyen] ([MaVT], [MaCN], [GhiChu]) VALUES (N'QuanLiTat', N'SSV', NULL)
INSERT [dbo].[PhanQuyen] ([MaVT], [MaCN], [GhiChu]) VALUES (N'QuanLiTat', N'TKSV', NULL)
INSERT [dbo].[PhanQuyen] ([MaVT], [MaCN], [GhiChu]) VALUES (N'QuanLiTat', N'TSV', NULL)
INSERT [dbo].[PhanQuyen] ([MaVT], [MaCN], [GhiChu]) VALUES (N'QuanLiTat', N'XFE', NULL)
INSERT [dbo].[PhanQuyen] ([MaVT], [MaCN], [GhiChu]) VALUES (N'QuanLiTat', N'XSV', NULL)
GO
INSERT [dbo].[QuanTriVien] ([UserName], [TenQTV]) VALUES (N'admin', N'Quản trị viên')
GO
INSERT [dbo].[SinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [QueQuan], [SoDienThoai], [MaLop]) VALUES (N'0187065', N'a', N'duc', N'Nữ', CAST(N'2001-01-02' AS Date), N'đà nẵng', N'03946018', N'Lop66IT2')
GO
INSERT [dbo].[TaiKhoan] ([UserName], [Password]) VALUES (N'admin', N'Dangnon123')
INSERT [dbo].[TaiKhoan] ([UserName], [Password]) VALUES (N'duc', N'dangnpn1')
GO
INSERT [dbo].[ThanhVien] ([UserName], [HoTV], [TenTV], [GioiTinh], [NgaySinh], [QueQuan], [SoDienThoai], [MaVT]) VALUES (N'duc', NULL, NULL, N'Nam', CAST(N'2023-10-12' AS Date), NULL, 0, N'KhongCoVaiTro')
GO
INSERT [dbo].[VaiTro] ([MaVT], [TenVT]) VALUES (N'KhongCoVaiTro', N'Không có vai trò')
INSERT [dbo].[VaiTro] ([MaVT], [TenVT]) VALUES (N'QuanLiTat', N'Quản lí tất')
GO
ALTER TABLE [dbo].[Khoa] ADD  CONSTRAINT [DF_Khoa_TrangThai]  DEFAULT ((0)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[Lop] ADD  CONSTRAINT [DF_Lop_TrangThai]  DEFAULT ((0)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[KetQua]  WITH CHECK ADD  CONSTRAINT [FK_KetQua_MonHoc] FOREIGN KEY([MaMH])
REFERENCES [dbo].[MonHoc] ([MaMH])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KetQua] CHECK CONSTRAINT [FK_KetQua_MonHoc]
GO
ALTER TABLE [dbo].[KetQua]  WITH CHECK ADD  CONSTRAINT [FK_KetQua_SinhVien] FOREIGN KEY([MaSV])
REFERENCES [dbo].[SinhVien] ([MaSV])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KetQua] CHECK CONSTRAINT [FK_KetQua_SinhVien]
GO
ALTER TABLE [dbo].[Lop]  WITH CHECK ADD  CONSTRAINT [FK_Lop_Khoa] FOREIGN KEY([MaKhoa])
REFERENCES [dbo].[Khoa] ([MaKhoa])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Lop] CHECK CONSTRAINT [FK_Lop_Khoa]
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PhanQuyen_ChucNang] FOREIGN KEY([MaCN])
REFERENCES [dbo].[ChucNang] ([MaCN])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhanQuyen] CHECK CONSTRAINT [FK_PhanQuyen_ChucNang]
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PhanQuyen_VaiTro] FOREIGN KEY([MaVT])
REFERENCES [dbo].[VaiTro] ([MaVT])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhanQuyen] CHECK CONSTRAINT [FK_PhanQuyen_VaiTro]
GO
ALTER TABLE [dbo].[QuanTriVien]  WITH CHECK ADD  CONSTRAINT [FK_QuanTriVien_TaiKhoan] FOREIGN KEY([UserName])
REFERENCES [dbo].[TaiKhoan] ([UserName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[QuanTriVien] CHECK CONSTRAINT [FK_QuanTriVien_TaiKhoan]
GO
ALTER TABLE [dbo].[SinhVien]  WITH CHECK ADD  CONSTRAINT [FK_SinhVien_Lop] FOREIGN KEY([MaLop])
REFERENCES [dbo].[Lop] ([MaLop])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[SinhVien] CHECK CONSTRAINT [FK_SinhVien_Lop]
GO
ALTER TABLE [dbo].[ThanhVien]  WITH CHECK ADD  CONSTRAINT [FK_ThanhVien_TaiKhoan] FOREIGN KEY([UserName])
REFERENCES [dbo].[TaiKhoan] ([UserName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ThanhVien] CHECK CONSTRAINT [FK_ThanhVien_TaiKhoan]
GO
ALTER TABLE [dbo].[ThanhVien]  WITH CHECK ADD  CONSTRAINT [FK_ThanhVien_VaiTro] FOREIGN KEY([MaVT])
REFERENCES [dbo].[VaiTro] ([MaVT])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[ThanhVien] CHECK CONSTRAINT [FK_ThanhVien_VaiTro]
GO
USE [master]
GO
ALTER DATABASE [QuanLySinhVien] SET  READ_WRITE 
GO
