USE [master]
GO
/****** Object:  Database [QuanLySinhVien]    Script Date: 12/14/2023 9:59:09 AM ******/
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
/****** Object:  Table [dbo].[BangDiemRenLuyen]    Script Date: 12/14/2023 9:59:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangDiemRenLuyen](
	[MaBangDRL] [int] IDENTITY(1,1) NOT NULL,
	[DiemToiDa] [int] NULL,
	[DiemTong] [int] NULL,
	[MaHK_NH] [int] NULL,
	[MaSV] [nvarchar](50) NULL,
 CONSTRAINT [PK_DiemRenLuyen] PRIMARY KEY CLUSTERED 
(
	[MaBangDRL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietTieuChi]    Script Date: 12/14/2023 9:59:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietTieuChi](
	[MaBangDRL] [int] NOT NULL,
	[MaTieuChi] [int] NOT NULL,
	[Diem] [int] NULL,
 CONSTRAINT [PK_ChiTietTieuChi] PRIMARY KEY CLUSTERED 
(
	[MaBangDRL] ASC,
	[MaTieuChi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucNang]    Script Date: 12/14/2023 9:59:09 AM ******/
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
/****** Object:  Table [dbo].[HocKy]    Script Date: 12/14/2023 9:59:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocKy](
	[MaHocKy] [int] IDENTITY(1,1) NOT NULL,
	[TenHocKy] [nvarchar](50) NULL,
 CONSTRAINT [PK_HocKy] PRIMARY KEY CLUSTERED 
(
	[MaHocKy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocKy_NamHoc]    Script Date: 12/14/2023 9:59:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocKy_NamHoc](
	[MaHK_NH] [int] IDENTITY(1,1) NOT NULL,
	[TenHK_NH] [nvarchar](50) NULL,
	[MaHocKy] [int] NULL,
	[MaNamHoc] [int] NULL,
 CONSTRAINT [PK_HocKy_NamHoc] PRIMARY KEY CLUSTERED 
(
	[MaHK_NH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KetQua]    Script Date: 12/14/2023 9:59:09 AM ******/
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
/****** Object:  Table [dbo].[Khoa]    Script Date: 12/14/2023 9:59:09 AM ******/
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
/****** Object:  Table [dbo].[Lop]    Script Date: 12/14/2023 9:59:09 AM ******/
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
/****** Object:  Table [dbo].[MonHoc]    Script Date: 12/14/2023 9:59:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[MaMH] [nvarchar](50) NOT NULL,
	[TenMH] [nvarchar](50) NULL,
	[SoTin] [int] NULL,
	[MaHK_NH] [int] NULL,
 CONSTRAINT [PK_MonHoc] PRIMARY KEY CLUSTERED 
(
	[MaMH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MucTieuChi]    Script Date: 12/14/2023 9:59:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MucTieuChi](
	[MaMucTieuChi] [int] IDENTITY(1,1) NOT NULL,
	[TenMucTieuChi] [nvarchar](200) NULL,
 CONSTRAINT [PK_MucTieuChi] PRIMARY KEY CLUSTERED 
(
	[MaMucTieuChi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NamHoc]    Script Date: 12/14/2023 9:59:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NamHoc](
	[MaNamHoc] [int] IDENTITY(1,1) NOT NULL,
	[TenNamHoc] [nvarchar](50) NULL,
 CONSTRAINT [PK_NamHoc] PRIMARY KEY CLUSTERED 
(
	[MaNamHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 12/14/2023 9:59:09 AM ******/
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
/****** Object:  Table [dbo].[QuanTriVien]    Script Date: 12/14/2023 9:59:09 AM ******/
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
/****** Object:  Table [dbo].[SinhVien]    Script Date: 12/14/2023 9:59:09 AM ******/
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
	[DiemTBHK] [real] NULL,
 CONSTRAINT [PK_SinhVien] PRIMARY KEY CLUSTERED 
(
	[MaSV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 12/14/2023 9:59:09 AM ******/
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
/****** Object:  Table [dbo].[ThanhVien]    Script Date: 12/14/2023 9:59:09 AM ******/
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
/****** Object:  Table [dbo].[TieuChi]    Script Date: 12/14/2023 9:59:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TieuChi](
	[MaTieuChi] [int] IDENTITY(1,1) NOT NULL,
	[TenTieuChi] [nvarchar](200) NULL,
	[DiemToiDa] [int] NULL,
	[MaMucTieuChi] [int] NULL,
 CONSTRAINT [PK_TieuChi] PRIMARY KEY CLUSTERED 
(
	[MaTieuChi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VaiTro]    Script Date: 12/14/2023 9:59:09 AM ******/
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
SET IDENTITY_INSERT [dbo].[BangDiemRenLuyen] ON 

INSERT [dbo].[BangDiemRenLuyen] ([MaBangDRL], [DiemToiDa], [DiemTong], [MaHK_NH], [MaSV]) VALUES (1, 40, 30, 1, N'0837137')
INSERT [dbo].[BangDiemRenLuyen] ([MaBangDRL], [DiemToiDa], [DiemTong], [MaHK_NH], [MaSV]) VALUES (2, 40, 20, 2, N'0837137')
SET IDENTITY_INSERT [dbo].[BangDiemRenLuyen] OFF
GO
INSERT [dbo].[ChiTietTieuChi] ([MaBangDRL], [MaTieuChi], [Diem]) VALUES (1, 1, 5)
INSERT [dbo].[ChiTietTieuChi] ([MaBangDRL], [MaTieuChi], [Diem]) VALUES (1, 2, 10)
INSERT [dbo].[ChiTietTieuChi] ([MaBangDRL], [MaTieuChi], [Diem]) VALUES (1, 3, 5)
INSERT [dbo].[ChiTietTieuChi] ([MaBangDRL], [MaTieuChi], [Diem]) VALUES (1, 4, 0)
INSERT [dbo].[ChiTietTieuChi] ([MaBangDRL], [MaTieuChi], [Diem]) VALUES (1, 5, 5)
INSERT [dbo].[ChiTietTieuChi] ([MaBangDRL], [MaTieuChi], [Diem]) VALUES (1, 6, 5)
INSERT [dbo].[ChiTietTieuChi] ([MaBangDRL], [MaTieuChi], [Diem]) VALUES (1, 7, 0)
INSERT [dbo].[ChiTietTieuChi] ([MaBangDRL], [MaTieuChi], [Diem]) VALUES (1, 8, 0)
INSERT [dbo].[ChiTietTieuChi] ([MaBangDRL], [MaTieuChi], [Diem]) VALUES (1, 9, 0)
INSERT [dbo].[ChiTietTieuChi] ([MaBangDRL], [MaTieuChi], [Diem]) VALUES (2, 1, 5)
INSERT [dbo].[ChiTietTieuChi] ([MaBangDRL], [MaTieuChi], [Diem]) VALUES (2, 2, 0)
INSERT [dbo].[ChiTietTieuChi] ([MaBangDRL], [MaTieuChi], [Diem]) VALUES (2, 3, 5)
INSERT [dbo].[ChiTietTieuChi] ([MaBangDRL], [MaTieuChi], [Diem]) VALUES (2, 4, 3)
INSERT [dbo].[ChiTietTieuChi] ([MaBangDRL], [MaTieuChi], [Diem]) VALUES (2, 5, 0)
INSERT [dbo].[ChiTietTieuChi] ([MaBangDRL], [MaTieuChi], [Diem]) VALUES (2, 6, 0)
INSERT [dbo].[ChiTietTieuChi] ([MaBangDRL], [MaTieuChi], [Diem]) VALUES (2, 7, 0)
INSERT [dbo].[ChiTietTieuChi] ([MaBangDRL], [MaTieuChi], [Diem]) VALUES (2, 8, 4)
INSERT [dbo].[ChiTietTieuChi] ([MaBangDRL], [MaTieuChi], [Diem]) VALUES (2, 9, 3)
GO
INSERT [dbo].[ChucNang] ([MaCN], [TenCN]) VALUES (N'CTSV', N'Xem chi tiết sinh viên')
INSERT [dbo].[ChucNang] ([MaCN], [TenCN]) VALUES (N'DRL', N'Điểm rèn luyện')
INSERT [dbo].[ChucNang] ([MaCN], [TenCN]) VALUES (N'DSSV', N'Xem danh sách sinh viên')
INSERT [dbo].[ChucNang] ([MaCN], [TenCN]) VALUES (N'HB', N'Học bổng')
INSERT [dbo].[ChucNang] ([MaCN], [TenCN]) VALUES (N'SSV', N'Sửa sinh viên')
INSERT [dbo].[ChucNang] ([MaCN], [TenCN]) VALUES (N'TKSV', N'Tìm kiếm sinh viên')
INSERT [dbo].[ChucNang] ([MaCN], [TenCN]) VALUES (N'TSV', N'Thêm sinh viên')
INSERT [dbo].[ChucNang] ([MaCN], [TenCN]) VALUES (N'XFE', N'Xuất file excel')
INSERT [dbo].[ChucNang] ([MaCN], [TenCN]) VALUES (N'XSV', N'Xóa sinh viên')
GO
SET IDENTITY_INSERT [dbo].[HocKy] ON 

INSERT [dbo].[HocKy] ([MaHocKy], [TenHocKy]) VALUES (1, N'Học kỳ 1')
INSERT [dbo].[HocKy] ([MaHocKy], [TenHocKy]) VALUES (2, N'Học kỳ 2')
SET IDENTITY_INSERT [dbo].[HocKy] OFF
GO
SET IDENTITY_INSERT [dbo].[HocKy_NamHoc] ON 

INSERT [dbo].[HocKy_NamHoc] ([MaHK_NH], [TenHK_NH], [MaHocKy], [MaNamHoc]) VALUES (1, N'HK1 2018-2019', 1, 1)
INSERT [dbo].[HocKy_NamHoc] ([MaHK_NH], [TenHK_NH], [MaHocKy], [MaNamHoc]) VALUES (2, N'HK2 2018-2019', 2, 1)
INSERT [dbo].[HocKy_NamHoc] ([MaHK_NH], [TenHK_NH], [MaHocKy], [MaNamHoc]) VALUES (3, N'HK1 2019-2020', 1, 2)
INSERT [dbo].[HocKy_NamHoc] ([MaHK_NH], [TenHK_NH], [MaHocKy], [MaNamHoc]) VALUES (4, N'HK2 2019-2020', 2, 2)
INSERT [dbo].[HocKy_NamHoc] ([MaHK_NH], [TenHK_NH], [MaHocKy], [MaNamHoc]) VALUES (5, N'HK1 2020-2021', 1, 3)
INSERT [dbo].[HocKy_NamHoc] ([MaHK_NH], [TenHK_NH], [MaHocKy], [MaNamHoc]) VALUES (6, N'HK2 2020-2021', 2, 3)
INSERT [dbo].[HocKy_NamHoc] ([MaHK_NH], [TenHK_NH], [MaHocKy], [MaNamHoc]) VALUES (7, N'HK1 2021-2022', 1, 4)
INSERT [dbo].[HocKy_NamHoc] ([MaHK_NH], [TenHK_NH], [MaHocKy], [MaNamHoc]) VALUES (8, N'HK2 2021-2022', 2, 4)
INSERT [dbo].[HocKy_NamHoc] ([MaHK_NH], [TenHK_NH], [MaHocKy], [MaNamHoc]) VALUES (9, N'HK1 2022-2023', 1, 5)
INSERT [dbo].[HocKy_NamHoc] ([MaHK_NH], [TenHK_NH], [MaHocKy], [MaNamHoc]) VALUES (10, N'HK2 2022-2023', 2, 5)
SET IDENTITY_INSERT [dbo].[HocKy_NamHoc] OFF
GO
INSERT [dbo].[KetQua] ([MaSV], [MaMH], [Diem]) VALUES (N'0187061', N'cnxh1', 6)
INSERT [dbo].[KetQua] ([MaSV], [MaMH], [Diem]) VALUES (N'0187061', N'dstt1', 8)
INSERT [dbo].[KetQua] ([MaSV], [MaMH], [Diem]) VALUES (N'0187061', N'gt1', 9)
INSERT [dbo].[KetQua] ([MaSV], [MaMH], [Diem]) VALUES (N'0187061', N'trr1', 8)
INSERT [dbo].[KetQua] ([MaSV], [MaMH], [Diem]) VALUES (N'0187061', N'tthcm1', 7)
INSERT [dbo].[KetQua] ([MaSV], [MaMH], [Diem]) VALUES (N'0187061', N'vl1', 5)
INSERT [dbo].[KetQua] ([MaSV], [MaMH], [Diem]) VALUES (N'0198348', N'cnxh1', 6)
INSERT [dbo].[KetQua] ([MaSV], [MaMH], [Diem]) VALUES (N'0198348', N'dstt1', 7)
INSERT [dbo].[KetQua] ([MaSV], [MaMH], [Diem]) VALUES (N'0198348', N'gt1', 9)
INSERT [dbo].[KetQua] ([MaSV], [MaMH], [Diem]) VALUES (N'0198348', N'trr1', 5)
INSERT [dbo].[KetQua] ([MaSV], [MaMH], [Diem]) VALUES (N'0198348', N'tthcm1', 6)
INSERT [dbo].[KetQua] ([MaSV], [MaMH], [Diem]) VALUES (N'0198348', N'vl1', 4)
INSERT [dbo].[KetQua] ([MaSV], [MaMH], [Diem]) VALUES (N'0837137', N'cnxh1', 8)
INSERT [dbo].[KetQua] ([MaSV], [MaMH], [Diem]) VALUES (N'0837137', N'dstt1', 7)
INSERT [dbo].[KetQua] ([MaSV], [MaMH], [Diem]) VALUES (N'0837137', N'gt1', 6)
INSERT [dbo].[KetQua] ([MaSV], [MaMH], [Diem]) VALUES (N'0837137', N'tthcm1', 3)
INSERT [dbo].[KetQua] ([MaSV], [MaMH], [Diem]) VALUES (N'0837137', N'vl1', 4)
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
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTin], [MaHK_NH]) VALUES (N'cnxh1', N'Chủ nghĩa xã hội', 2, 2)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTin], [MaHK_NH]) VALUES (N'dstt1', N'Đại số tuyến tính', 3, 1)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTin], [MaHK_NH]) VALUES (N'gt1', N'Giải tích', 3, 1)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTin], [MaHK_NH]) VALUES (N'trr1', N'Toán rời rạc', 3, 2)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTin], [MaHK_NH]) VALUES (N'tthcm1', N'Tư tưởng Hồ Chí Minh', 2, 1)
INSERT [dbo].[MonHoc] ([MaMH], [TenMH], [SoTin], [MaHK_NH]) VALUES (N'vl1', N'Vật lý', 2, 2)
GO
SET IDENTITY_INSERT [dbo].[MucTieuChi] ON 

INSERT [dbo].[MucTieuChi] ([MaMucTieuChi], [TenMucTieuChi]) VALUES (1, N'ĐÁNH GIÁ VỀ Ý THỨC HỌC TẬP')
INSERT [dbo].[MucTieuChi] ([MaMucTieuChi], [TenMucTieuChi]) VALUES (2, N'ĐÁNH GIÁ VỀ Ý THỨC CHẤP HÀNH NỘI QUY, QUY CHẾ, QUY ĐỊNH TRONG TRƯỜNG')
INSERT [dbo].[MucTieuChi] ([MaMucTieuChi], [TenMucTieuChi]) VALUES (3, N'')
SET IDENTITY_INSERT [dbo].[MucTieuChi] OFF
GO
SET IDENTITY_INSERT [dbo].[NamHoc] ON 

INSERT [dbo].[NamHoc] ([MaNamHoc], [TenNamHoc]) VALUES (1, N'2018-2019')
INSERT [dbo].[NamHoc] ([MaNamHoc], [TenNamHoc]) VALUES (2, N'2019-2020')
INSERT [dbo].[NamHoc] ([MaNamHoc], [TenNamHoc]) VALUES (3, N'2020-2021')
INSERT [dbo].[NamHoc] ([MaNamHoc], [TenNamHoc]) VALUES (4, N'2021-2022')
INSERT [dbo].[NamHoc] ([MaNamHoc], [TenNamHoc]) VALUES (5, N'2022-2023')
SET IDENTITY_INSERT [dbo].[NamHoc] OFF
GO
INSERT [dbo].[PhanQuyen] ([MaVT], [MaCN], [GhiChu]) VALUES (N'ad', N'DSSV', NULL)
INSERT [dbo].[PhanQuyen] ([MaVT], [MaCN], [GhiChu]) VALUES (N'ad', N'SSV', NULL)
INSERT [dbo].[PhanQuyen] ([MaVT], [MaCN], [GhiChu]) VALUES (N'ad', N'TKSV', NULL)
INSERT [dbo].[PhanQuyen] ([MaVT], [MaCN], [GhiChu]) VALUES (N'ad', N'XSV', NULL)
INSERT [dbo].[PhanQuyen] ([MaVT], [MaCN], [GhiChu]) VALUES (N'QuanLiTat', N'CTSV', NULL)
INSERT [dbo].[PhanQuyen] ([MaVT], [MaCN], [GhiChu]) VALUES (N'QuanLiTat', N'DRL', NULL)
INSERT [dbo].[PhanQuyen] ([MaVT], [MaCN], [GhiChu]) VALUES (N'QuanLiTat', N'DSSV', NULL)
INSERT [dbo].[PhanQuyen] ([MaVT], [MaCN], [GhiChu]) VALUES (N'QuanLiTat', N'SSV', NULL)
INSERT [dbo].[PhanQuyen] ([MaVT], [MaCN], [GhiChu]) VALUES (N'QuanLiTat', N'TKSV', NULL)
INSERT [dbo].[PhanQuyen] ([MaVT], [MaCN], [GhiChu]) VALUES (N'QuanLiTat', N'TSV', NULL)
INSERT [dbo].[PhanQuyen] ([MaVT], [MaCN], [GhiChu]) VALUES (N'QuanLiTat', N'XFE', NULL)
INSERT [dbo].[PhanQuyen] ([MaVT], [MaCN], [GhiChu]) VALUES (N'QuanLiTat', N'XSV', NULL)
GO
INSERT [dbo].[QuanTriVien] ([UserName], [TenQTV]) VALUES (N'admin', N'Quản trị viên')
GO
INSERT [dbo].[SinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [QueQuan], [SoDienThoai], [MaLop], [DiemTBHK]) VALUES (N'0187061', N'Đặng Phương', N'Bắc', N'Nam', CAST(N'2002-06-19' AS Date), N'đà nẵng', N'0312614362', N'Lop66ME1', NULL)
INSERT [dbo].[SinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [QueQuan], [SoDienThoai], [MaLop], [DiemTBHK]) VALUES (N'0198348', N'Nguyễn Phương', N'Nam', N'Nam', CAST(N'2003-12-12' AS Date), N'Hà Tĩnh', N'0188234732', N'Lop66ME2', NULL)
INSERT [dbo].[SinhVien] ([MaSV], [HoSV], [TenSV], [GioiTinh], [NgaySinh], [QueQuan], [SoDienThoai], [MaLop], [DiemTBHK]) VALUES (N'0837137', N'Phạm Văn', N'Đăng', N'Không xác định', CAST(N'2003-11-18' AS Date), N'Nghệ An', N'0189478122', N'Lop66IT3', NULL)
GO
INSERT [dbo].[TaiKhoan] ([UserName], [Password]) VALUES (N'admin', N'Dangnon123')
INSERT [dbo].[TaiKhoan] ([UserName], [Password]) VALUES (N'dang', N'Dangnon123')
INSERT [dbo].[TaiKhoan] ([UserName], [Password]) VALUES (N'duc', N'Dangnon123')
GO
INSERT [dbo].[ThanhVien] ([UserName], [HoTV], [TenTV], [GioiTinh], [NgaySinh], [QueQuan], [SoDienThoai], [MaVT]) VALUES (N'dang', NULL, NULL, N'Không xác định', NULL, NULL, 0, N'KhongCoVaiTro')
INSERT [dbo].[ThanhVien] ([UserName], [HoTV], [TenTV], [GioiTinh], [NgaySinh], [QueQuan], [SoDienThoai], [MaVT]) VALUES (N'duc', N'bùi ', N'đức', N'Nam', NULL, NULL, 0, N'QuanLiTat')
GO
SET IDENTITY_INSERT [dbo].[TieuChi] ON 

INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DiemToiDa], [MaMucTieuChi]) VALUES (1, N'Ý thức và thái độ trong học tập', 5, 1)
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DiemToiDa], [MaMucTieuChi]) VALUES (2, N'Kết quả học tập', 10, 1)
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DiemToiDa], [MaMucTieuChi]) VALUES (3, N'Ý thức chấp hành nội quy - quy chế thi', 5, 1)
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DiemToiDa], [MaMucTieuChi]) VALUES (4, N'Tham gia thi SVG cấp trường', 3, 1)
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DiemToiDa], [MaMucTieuChi]) VALUES (5, N'Tham gia thi Olympic', 5, 1)
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DiemToiDa], [MaMucTieuChi]) VALUES (6, N'Ý thức chấp hành các văn bản chỉ đạo của cấp trên: thực hiện nghĩa vụ tham gia đánh giá chất lượng giảng dạy của giảng viên', 5, 2)
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DiemToiDa], [MaMucTieuChi]) VALUES (7, N'Chấp hành các nội quy, quy chế của nhà trường', 5, 2)
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DiemToiDa], [MaMucTieuChi]) VALUES (8, N'Chấp hành quy định đóng học phí', 4, 2)
INSERT [dbo].[TieuChi] ([MaTieuChi], [TenTieuChi], [DiemToiDa], [MaMucTieuChi]) VALUES (9, N'Chấp hành quy định mượn, trả sách của thư viện', 3, 2)
SET IDENTITY_INSERT [dbo].[TieuChi] OFF
GO
INSERT [dbo].[VaiTro] ([MaVT], [TenVT]) VALUES (N'ad', N'ad')
INSERT [dbo].[VaiTro] ([MaVT], [TenVT]) VALUES (N'KhongCoVaiTro', N'Không có vai trò')
INSERT [dbo].[VaiTro] ([MaVT], [TenVT]) VALUES (N'ql', N'quản lí')
INSERT [dbo].[VaiTro] ([MaVT], [TenVT]) VALUES (N'QuanLiTat', N'Quản lí tất')
GO
ALTER TABLE [dbo].[Khoa] ADD  CONSTRAINT [DF_Khoa_TrangThai]  DEFAULT ((0)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[Lop] ADD  CONSTRAINT [DF_Lop_TrangThai]  DEFAULT ((0)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[BangDiemRenLuyen]  WITH CHECK ADD  CONSTRAINT [FK_BangDiemRenLuyen_HocKy_NamHoc] FOREIGN KEY([MaHK_NH])
REFERENCES [dbo].[HocKy_NamHoc] ([MaHK_NH])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[BangDiemRenLuyen] CHECK CONSTRAINT [FK_BangDiemRenLuyen_HocKy_NamHoc]
GO
ALTER TABLE [dbo].[BangDiemRenLuyen]  WITH CHECK ADD  CONSTRAINT [FK_BangDiemRenLuyen_SinhVien] FOREIGN KEY([MaSV])
REFERENCES [dbo].[SinhVien] ([MaSV])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[BangDiemRenLuyen] CHECK CONSTRAINT [FK_BangDiemRenLuyen_SinhVien]
GO
ALTER TABLE [dbo].[ChiTietTieuChi]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietTieuChi_BangDiemRenLuyen] FOREIGN KEY([MaBangDRL])
REFERENCES [dbo].[BangDiemRenLuyen] ([MaBangDRL])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietTieuChi] CHECK CONSTRAINT [FK_ChiTietTieuChi_BangDiemRenLuyen]
GO
ALTER TABLE [dbo].[ChiTietTieuChi]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietTieuChi_TieuChi] FOREIGN KEY([MaTieuChi])
REFERENCES [dbo].[TieuChi] ([MaTieuChi])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietTieuChi] CHECK CONSTRAINT [FK_ChiTietTieuChi_TieuChi]
GO
ALTER TABLE [dbo].[HocKy_NamHoc]  WITH CHECK ADD  CONSTRAINT [FK_HocKy_NamHoc_HocKy] FOREIGN KEY([MaHocKy])
REFERENCES [dbo].[HocKy] ([MaHocKy])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HocKy_NamHoc] CHECK CONSTRAINT [FK_HocKy_NamHoc_HocKy]
GO
ALTER TABLE [dbo].[HocKy_NamHoc]  WITH CHECK ADD  CONSTRAINT [FK_HocKy_NamHoc_NamHoc] FOREIGN KEY([MaNamHoc])
REFERENCES [dbo].[NamHoc] ([MaNamHoc])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HocKy_NamHoc] CHECK CONSTRAINT [FK_HocKy_NamHoc_NamHoc]
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
ALTER TABLE [dbo].[MonHoc]  WITH CHECK ADD  CONSTRAINT [FK_MonHoc_HocKy_NamHoc] FOREIGN KEY([MaHK_NH])
REFERENCES [dbo].[HocKy_NamHoc] ([MaHK_NH])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[MonHoc] CHECK CONSTRAINT [FK_MonHoc_HocKy_NamHoc]
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
ALTER TABLE [dbo].[TieuChi]  WITH CHECK ADD  CONSTRAINT [FK_TieuChi_MucTieuChi] FOREIGN KEY([MaMucTieuChi])
REFERENCES [dbo].[MucTieuChi] ([MaMucTieuChi])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[TieuChi] CHECK CONSTRAINT [FK_TieuChi_MucTieuChi]
GO
USE [master]
GO
ALTER DATABASE [QuanLySinhVien] SET  READ_WRITE 
GO
