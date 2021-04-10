USE [master]
GO
/****** Object:  Database [testdb]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE DATABASE [testdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'testdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\testdb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'testdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\testdb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [testdb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [testdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [testdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [testdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [testdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [testdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [testdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [testdb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [testdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [testdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [testdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [testdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [testdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [testdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [testdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [testdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [testdb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [testdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [testdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [testdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [testdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [testdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [testdb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [testdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [testdb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [testdb] SET  MULTI_USER 
GO
ALTER DATABASE [testdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [testdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [testdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [testdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [testdb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [testdb] SET QUERY_STORE = OFF
GO
USE [testdb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[IsEnabled] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Barang]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Barang](
	[IdBarang] [int] IDENTITY(1,1) NOT NULL,
	[NamaBarang] [nvarchar](max) NULL,
	[Harga] [int] NOT NULL,
	[Stok] [smallint] NOT NULL,
	[IdKatBarang] [int] NOT NULL,
	[Keterangan] [nvarchar](max) NULL,
	[Minstok] [int] NOT NULL,
	[KatBarangIdKategori] [int] NOT NULL,
 CONSTRAINT [PK_Barang] PRIMARY KEY CLUSTERED 
(
	[IdBarang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Beli]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beli](
	[IdBeli] [int] IDENTITY(1,1) NOT NULL,
	[Tanggal] [datetime2](7) NOT NULL,
	[NamaPembelian] [nvarchar](max) NULL,
	[Keterangan] [nvarchar](max) NULL,
	[TenantID] [nvarchar](450) NULL,
	[TotalHarga] [int] NOT NULL,
 CONSTRAINT [PK_Beli] PRIMARY KEY CLUSTERED 
(
	[IdBeli] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetailBeli]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailBeli](
	[DetailBeliId] [nvarchar](450) NOT NULL,
	[IdBeli] [int] NOT NULL,
	[Tanggal] [datetime2](7) NOT NULL,
	[IdBarang] [int] NOT NULL,
	[Qty] [smallint] NOT NULL,
	[Harga] [int] NOT NULL,
	[TotalHarga] [int] NOT NULL,
 CONSTRAINT [PK_DetailBeli] PRIMARY KEY CLUSTERED 
(
	[DetailBeliId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetailPasien]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailPasien](
	[DetailPasienID] [int] IDENTITY(1,1) NOT NULL,
	[Registrasi] [datetime2](7) NOT NULL,
	[RwPenyakit] [nvarchar](max) NULL,
	[Username] [nvarchar](450) NULL,
	[IdPasien] [nvarchar](max) NULL,
 CONSTRAINT [PK_DetailPasien] PRIMARY KEY CLUSTERED 
(
	[DetailPasienID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetailPegawai]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailPegawai](
	[DetailPegawaiID] [int] IDENTITY(1,1) NOT NULL,
	[Jabatan] [nvarchar](max) NULL,
	[Gaji] [int] NOT NULL,
	[TanggalJoin] [datetime2](7) NOT NULL,
	[Username] [nvarchar](450) NULL,
 CONSTRAINT [PK_DetailPegawai] PRIMARY KEY CLUSTERED 
(
	[DetailPegawaiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetailPenggajian]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetailPenggajian](
	[IdDetailGaji] [int] IDENTITY(1,1) NOT NULL,
	[IdGaji] [int] NOT NULL,
	[IdTransaksi] [int] NOT NULL,
 CONSTRAINT [PK_DetailPenggajian] PRIMARY KEY CLUSTERED 
(
	[IdDetailGaji] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JenisTindakan]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JenisTindakan](
	[IdJenisTindakan] [int] IDENTITY(1,1) NOT NULL,
	[IdKatJenis] [int] NOT NULL,
	[Jenis] [nvarchar](max) NULL,
	[Biaya] [int] NOT NULL,
	[Keterangan] [nvarchar](max) NULL,
	[TenantID] [nvarchar](450) NULL,
 CONSTRAINT [PK_JenisTindakan] PRIMARY KEY CLUSTERED 
(
	[IdJenisTindakan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jual]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jual](
	[IdJual] [int] IDENTITY(1,1) NOT NULL,
	[IdTransaksi] [int] NOT NULL,
	[TenantID] [nvarchar](450) NULL,
	[Harga] [int] NOT NULL,
	[IdBarang] [int] NOT NULL,
	[Qty] [smallint] NOT NULL,
 CONSTRAINT [PK_Jual] PRIMARY KEY CLUSTERED 
(
	[IdJual] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KatBarang]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KatBarang](
	[IdKategori] [int] IDENTITY(1,1) NOT NULL,
	[NamaKategori] [nvarchar](max) NULL,
	[TenantID] [nvarchar](450) NULL,
 CONSTRAINT [PK_KatBarang] PRIMARY KEY CLUSTERED 
(
	[IdKategori] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KatJenis]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KatJenis](
	[IdKatJenis] [int] IDENTITY(1,1) NOT NULL,
	[KategoriName] [nvarchar](max) NULL,
	[TenantID] [nvarchar](450) NULL,
 CONSTRAINT [PK_KatJenis] PRIMARY KEY CLUSTERED 
(
	[IdKatJenis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Penggajian]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Penggajian](
	[IdGaji] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](450) NULL,
	[TanggalGaji] [datetime2](7) NOT NULL,
	[TanggalAwal] [datetime2](7) NULL,
	[TanggalAkhir] [datetime2](7) NULL,
	[TotalGaji] [int] NOT NULL,
	[MasaWaktu] [nvarchar](max) NULL,
	[TenantID] [nvarchar](450) NULL,
	[DetailPegawaiID] [int] NOT NULL,
 CONSTRAINT [PK_Penggajian] PRIMARY KEY CLUSTERED 
(
	[IdGaji] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pengguna]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pengguna](
	[Username] [nvarchar](450) NOT NULL,
	[IdPasien] [nvarchar](max) NULL,
	[Nama] [nvarchar](max) NULL,
	[Gender] [nvarchar](max) NULL,
	[Umur] [smallint] NOT NULL,
	[Alamat] [nvarchar](max) NULL,
	[Kota] [nvarchar](max) NULL,
	[NoTelpon] [nvarchar](max) NULL,
	[NoHP] [nvarchar](max) NULL,
	[rolename] [nvarchar](max) NULL,
	[Prosentase] [float] NOT NULL,
	[Email] [nvarchar](max) NULL,
	[TenantID] [nvarchar](450) NULL,
 CONSTRAINT [PK_Pengguna] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pilihGIgi]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pilihGIgi](
	[IdTindakan] [int] NOT NULL,
	[idposisiGigi] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_pilihGIgi] PRIMARY KEY CLUSTERED 
(
	[IdTindakan] ASC,
	[idposisiGigi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PosisiGigi]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PosisiGigi](
	[id] [nvarchar](450) NOT NULL,
	[gigiPosisi] [int] NOT NULL,
	[kuadran] [nvarchar](max) NULL,
 CONSTRAINT [PK_PosisiGigi] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prosentase]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prosentase](
	[IdProsentase] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](450) NULL,
	[IdJenisTindakan] [int] NOT NULL,
	[Prosen] [float] NOT NULL,
	[TenantID] [nvarchar](450) NULL,
	[DetailPegawaiID] [int] NULL,
 CONSTRAINT [PK_Prosentase] PRIMARY KEY CLUSTERED 
(
	[IdProsentase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tenant]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenant](
	[TenantID] [nvarchar](450) NOT NULL,
	[TenantName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tenant] PRIMARY KEY CLUSTERED 
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TenantPengguna]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TenantPengguna](
	[TenantPenggunaID] [nvarchar](450) NOT NULL,
	[TenantID] [nvarchar](450) NULL,
	[Username] [nvarchar](450) NULL,
	[StatusTenant] [bit] NOT NULL,
 CONSTRAINT [PK_TenantPengguna] PRIMARY KEY CLUSTERED 
(
	[TenantPenggunaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tindakan]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tindakan](
	[IdTindakan] [int] IDENTITY(1,1) NOT NULL,
	[IdTransaksi] [int] NOT NULL,
	[IdJenisTindakan] [int] NOT NULL,
	[Biaya] [int] NOT NULL,
	[Persenan] [int] NOT NULL,
	[Diagnosis] [nvarchar](max) NULL,
	[BiayaDasar] [int] NOT NULL,
	[Status] [nvarchar](max) NULL,
	[TenantID] [nvarchar](450) NULL,
 CONSTRAINT [PK_Tindakan] PRIMARY KEY CLUSTERED 
(
	[IdTindakan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaksi]    Script Date: 4/10/2021 7:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaksi](
	[IdTransaksi] [int] IDENTITY(1,1) NOT NULL,
	[IdPasien] [nvarchar](max) NULL,
	[Username] [nvarchar](450) NULL,
	[Tanggal] [datetime2](7) NOT NULL,
	[Anamnesis] [nvarchar](max) NULL,
	[Resep] [nvarchar](max) NULL,
	[TenantID] [nvarchar](450) NULL,
	[DetailPasienID] [int] NOT NULL,
 CONSTRAINT [PK_Transaksi] PRIMARY KEY CLUSTERED 
(
	[IdTransaksi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Barang_KatBarangIdKategori]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Barang_KatBarangIdKategori] ON [dbo].[Barang]
(
	[KatBarangIdKategori] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Beli_TenantID]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Beli_TenantID] ON [dbo].[Beli]
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetailBeli_IdBarang]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_DetailBeli_IdBarang] ON [dbo].[DetailBeli]
(
	[IdBarang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DetailPasien_Username]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_DetailPasien_Username] ON [dbo].[DetailPasien]
(
	[Username] ASC
)
WHERE ([Username] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_DetailPegawai_Username]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_DetailPegawai_Username] ON [dbo].[DetailPegawai]
(
	[Username] ASC
)
WHERE ([Username] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetailPenggajian_IdGaji]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_DetailPenggajian_IdGaji] ON [dbo].[DetailPenggajian]
(
	[IdGaji] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DetailPenggajian_IdTransaksi]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_DetailPenggajian_IdTransaksi] ON [dbo].[DetailPenggajian]
(
	[IdTransaksi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_JenisTindakan_IdKatJenis]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_JenisTindakan_IdKatJenis] ON [dbo].[JenisTindakan]
(
	[IdKatJenis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_JenisTindakan_TenantID]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_JenisTindakan_TenantID] ON [dbo].[JenisTindakan]
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Jual_IdBarang]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Jual_IdBarang] ON [dbo].[Jual]
(
	[IdBarang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Jual_IdTransaksi]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Jual_IdTransaksi] ON [dbo].[Jual]
(
	[IdTransaksi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Jual_TenantID]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Jual_TenantID] ON [dbo].[Jual]
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_KatBarang_TenantID]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_KatBarang_TenantID] ON [dbo].[KatBarang]
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_KatJenis_TenantID]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_KatJenis_TenantID] ON [dbo].[KatJenis]
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Penggajian_DetailPegawaiID]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Penggajian_DetailPegawaiID] ON [dbo].[Penggajian]
(
	[DetailPegawaiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Penggajian_TenantID]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Penggajian_TenantID] ON [dbo].[Penggajian]
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Penggajian_Username]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Penggajian_Username] ON [dbo].[Penggajian]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Pengguna_TenantID]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Pengguna_TenantID] ON [dbo].[Pengguna]
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_pilihGIgi_idposisiGigi]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_pilihGIgi_idposisiGigi] ON [dbo].[pilihGIgi]
(
	[idposisiGigi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Prosentase_DetailPegawaiID]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Prosentase_DetailPegawaiID] ON [dbo].[Prosentase]
(
	[DetailPegawaiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Prosentase_IdJenisTindakan]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Prosentase_IdJenisTindakan] ON [dbo].[Prosentase]
(
	[IdJenisTindakan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Prosentase_TenantID]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Prosentase_TenantID] ON [dbo].[Prosentase]
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Prosentase_Username]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Prosentase_Username] ON [dbo].[Prosentase]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TenantPengguna_TenantID]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_TenantPengguna_TenantID] ON [dbo].[TenantPengguna]
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TenantPengguna_Username]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_TenantPengguna_Username] ON [dbo].[TenantPengguna]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tindakan_IdJenisTindakan]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tindakan_IdJenisTindakan] ON [dbo].[Tindakan]
(
	[IdJenisTindakan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Tindakan_IdTransaksi]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tindakan_IdTransaksi] ON [dbo].[Tindakan]
(
	[IdTransaksi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Tindakan_TenantID]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Tindakan_TenantID] ON [dbo].[Tindakan]
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transaksi_DetailPasienID]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Transaksi_DetailPasienID] ON [dbo].[Transaksi]
(
	[DetailPasienID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Transaksi_TenantID]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Transaksi_TenantID] ON [dbo].[Transaksi]
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Transaksi_Username]    Script Date: 4/10/2021 7:17:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Transaksi_Username] ON [dbo].[Transaksi]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Jual] ADD  DEFAULT ((0)) FOR [Harga]
GO
ALTER TABLE [dbo].[Jual] ADD  DEFAULT ((0)) FOR [IdBarang]
GO
ALTER TABLE [dbo].[Jual] ADD  DEFAULT (CONVERT([smallint],(0))) FOR [Qty]
GO
ALTER TABLE [dbo].[TenantPengguna] ADD  DEFAULT ((0)) FOR [StatusTenant]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Barang]  WITH CHECK ADD  CONSTRAINT [FK_Barang_KatBarang_KatBarangIdKategori] FOREIGN KEY([KatBarangIdKategori])
REFERENCES [dbo].[KatBarang] ([IdKategori])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Barang] CHECK CONSTRAINT [FK_Barang_KatBarang_KatBarangIdKategori]
GO
ALTER TABLE [dbo].[Beli]  WITH CHECK ADD  CONSTRAINT [FK_Beli_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[Beli] CHECK CONSTRAINT [FK_Beli_Tenant_TenantID]
GO
ALTER TABLE [dbo].[DetailBeli]  WITH CHECK ADD  CONSTRAINT [FK_DetailBeli_Barang_IdBarang] FOREIGN KEY([IdBarang])
REFERENCES [dbo].[Barang] ([IdBarang])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetailBeli] CHECK CONSTRAINT [FK_DetailBeli_Barang_IdBarang]
GO
ALTER TABLE [dbo].[DetailBeli]  WITH CHECK ADD  CONSTRAINT [FK_DetailBeli_Beli_IdBeli] FOREIGN KEY([IdBeli])
REFERENCES [dbo].[Beli] ([IdBeli])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetailBeli] CHECK CONSTRAINT [FK_DetailBeli_Beli_IdBeli]
GO
ALTER TABLE [dbo].[DetailPasien]  WITH CHECK ADD  CONSTRAINT [FK_DetailPasien_Pengguna_Username] FOREIGN KEY([Username])
REFERENCES [dbo].[Pengguna] ([Username])
GO
ALTER TABLE [dbo].[DetailPasien] CHECK CONSTRAINT [FK_DetailPasien_Pengguna_Username]
GO
ALTER TABLE [dbo].[DetailPegawai]  WITH CHECK ADD  CONSTRAINT [FK_DetailPegawai_Pengguna_Username] FOREIGN KEY([Username])
REFERENCES [dbo].[Pengguna] ([Username])
GO
ALTER TABLE [dbo].[DetailPegawai] CHECK CONSTRAINT [FK_DetailPegawai_Pengguna_Username]
GO
ALTER TABLE [dbo].[DetailPenggajian]  WITH CHECK ADD  CONSTRAINT [FK_DetailPenggajian_Penggajian_IdGaji] FOREIGN KEY([IdGaji])
REFERENCES [dbo].[Penggajian] ([IdGaji])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetailPenggajian] CHECK CONSTRAINT [FK_DetailPenggajian_Penggajian_IdGaji]
GO
ALTER TABLE [dbo].[DetailPenggajian]  WITH CHECK ADD  CONSTRAINT [FK_DetailPenggajian_Transaksi_IdTransaksi] FOREIGN KEY([IdTransaksi])
REFERENCES [dbo].[Transaksi] ([IdTransaksi])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DetailPenggajian] CHECK CONSTRAINT [FK_DetailPenggajian_Transaksi_IdTransaksi]
GO
ALTER TABLE [dbo].[JenisTindakan]  WITH CHECK ADD  CONSTRAINT [FK_JenisTindakan_KatJenis_IdKatJenis] FOREIGN KEY([IdKatJenis])
REFERENCES [dbo].[KatJenis] ([IdKatJenis])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[JenisTindakan] CHECK CONSTRAINT [FK_JenisTindakan_KatJenis_IdKatJenis]
GO
ALTER TABLE [dbo].[JenisTindakan]  WITH CHECK ADD  CONSTRAINT [FK_JenisTindakan_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[JenisTindakan] CHECK CONSTRAINT [FK_JenisTindakan_Tenant_TenantID]
GO
ALTER TABLE [dbo].[Jual]  WITH CHECK ADD  CONSTRAINT [FK_Jual_Barang_IdBarang] FOREIGN KEY([IdBarang])
REFERENCES [dbo].[Barang] ([IdBarang])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Jual] CHECK CONSTRAINT [FK_Jual_Barang_IdBarang]
GO
ALTER TABLE [dbo].[Jual]  WITH CHECK ADD  CONSTRAINT [FK_Jual_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[Jual] CHECK CONSTRAINT [FK_Jual_Tenant_TenantID]
GO
ALTER TABLE [dbo].[Jual]  WITH CHECK ADD  CONSTRAINT [FK_Jual_Transaksi_IdTransaksi] FOREIGN KEY([IdTransaksi])
REFERENCES [dbo].[Transaksi] ([IdTransaksi])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Jual] CHECK CONSTRAINT [FK_Jual_Transaksi_IdTransaksi]
GO
ALTER TABLE [dbo].[KatBarang]  WITH CHECK ADD  CONSTRAINT [FK_KatBarang_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[KatBarang] CHECK CONSTRAINT [FK_KatBarang_Tenant_TenantID]
GO
ALTER TABLE [dbo].[KatJenis]  WITH CHECK ADD  CONSTRAINT [FK_KatJenis_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[KatJenis] CHECK CONSTRAINT [FK_KatJenis_Tenant_TenantID]
GO
ALTER TABLE [dbo].[Penggajian]  WITH CHECK ADD  CONSTRAINT [FK_Penggajian_DetailPegawai_DetailPegawaiID] FOREIGN KEY([DetailPegawaiID])
REFERENCES [dbo].[DetailPegawai] ([DetailPegawaiID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Penggajian] CHECK CONSTRAINT [FK_Penggajian_DetailPegawai_DetailPegawaiID]
GO
ALTER TABLE [dbo].[Penggajian]  WITH CHECK ADD  CONSTRAINT [FK_Penggajian_Pengguna_Username] FOREIGN KEY([Username])
REFERENCES [dbo].[Pengguna] ([Username])
GO
ALTER TABLE [dbo].[Penggajian] CHECK CONSTRAINT [FK_Penggajian_Pengguna_Username]
GO
ALTER TABLE [dbo].[Penggajian]  WITH CHECK ADD  CONSTRAINT [FK_Penggajian_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[Penggajian] CHECK CONSTRAINT [FK_Penggajian_Tenant_TenantID]
GO
ALTER TABLE [dbo].[Pengguna]  WITH CHECK ADD  CONSTRAINT [FK_Pengguna_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[Pengguna] CHECK CONSTRAINT [FK_Pengguna_Tenant_TenantID]
GO
ALTER TABLE [dbo].[pilihGIgi]  WITH CHECK ADD  CONSTRAINT [FK_pilihGIgi_PosisiGigi_idposisiGigi] FOREIGN KEY([idposisiGigi])
REFERENCES [dbo].[PosisiGigi] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[pilihGIgi] CHECK CONSTRAINT [FK_pilihGIgi_PosisiGigi_idposisiGigi]
GO
ALTER TABLE [dbo].[pilihGIgi]  WITH CHECK ADD  CONSTRAINT [FK_pilihGIgi_Tindakan_IdTindakan] FOREIGN KEY([IdTindakan])
REFERENCES [dbo].[Tindakan] ([IdTindakan])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[pilihGIgi] CHECK CONSTRAINT [FK_pilihGIgi_Tindakan_IdTindakan]
GO
ALTER TABLE [dbo].[Prosentase]  WITH CHECK ADD  CONSTRAINT [FK_Prosentase_DetailPegawai_DetailPegawaiID] FOREIGN KEY([DetailPegawaiID])
REFERENCES [dbo].[DetailPegawai] ([DetailPegawaiID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Prosentase] CHECK CONSTRAINT [FK_Prosentase_DetailPegawai_DetailPegawaiID]
GO
ALTER TABLE [dbo].[Prosentase]  WITH CHECK ADD  CONSTRAINT [FK_Prosentase_JenisTindakan_IdJenisTindakan] FOREIGN KEY([IdJenisTindakan])
REFERENCES [dbo].[JenisTindakan] ([IdJenisTindakan])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Prosentase] CHECK CONSTRAINT [FK_Prosentase_JenisTindakan_IdJenisTindakan]
GO
ALTER TABLE [dbo].[Prosentase]  WITH CHECK ADD  CONSTRAINT [FK_Prosentase_Pengguna_Username] FOREIGN KEY([Username])
REFERENCES [dbo].[Pengguna] ([Username])
GO
ALTER TABLE [dbo].[Prosentase] CHECK CONSTRAINT [FK_Prosentase_Pengguna_Username]
GO
ALTER TABLE [dbo].[Prosentase]  WITH CHECK ADD  CONSTRAINT [FK_Prosentase_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[Prosentase] CHECK CONSTRAINT [FK_Prosentase_Tenant_TenantID]
GO
ALTER TABLE [dbo].[TenantPengguna]  WITH CHECK ADD  CONSTRAINT [FK_TenantPengguna_Pengguna_Username] FOREIGN KEY([Username])
REFERENCES [dbo].[Pengguna] ([Username])
GO
ALTER TABLE [dbo].[TenantPengguna] CHECK CONSTRAINT [FK_TenantPengguna_Pengguna_Username]
GO
ALTER TABLE [dbo].[TenantPengguna]  WITH CHECK ADD  CONSTRAINT [FK_TenantPengguna_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[TenantPengguna] CHECK CONSTRAINT [FK_TenantPengguna_Tenant_TenantID]
GO
ALTER TABLE [dbo].[Tindakan]  WITH CHECK ADD  CONSTRAINT [FK_Tindakan_JenisTindakan_IdJenisTindakan] FOREIGN KEY([IdJenisTindakan])
REFERENCES [dbo].[JenisTindakan] ([IdJenisTindakan])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tindakan] CHECK CONSTRAINT [FK_Tindakan_JenisTindakan_IdJenisTindakan]
GO
ALTER TABLE [dbo].[Tindakan]  WITH CHECK ADD  CONSTRAINT [FK_Tindakan_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[Tindakan] CHECK CONSTRAINT [FK_Tindakan_Tenant_TenantID]
GO
ALTER TABLE [dbo].[Tindakan]  WITH CHECK ADD  CONSTRAINT [FK_Tindakan_Transaksi_IdTransaksi] FOREIGN KEY([IdTransaksi])
REFERENCES [dbo].[Transaksi] ([IdTransaksi])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tindakan] CHECK CONSTRAINT [FK_Tindakan_Transaksi_IdTransaksi]
GO
ALTER TABLE [dbo].[Transaksi]  WITH CHECK ADD  CONSTRAINT [FK_Transaksi_DetailPasien_DetailPasienID] FOREIGN KEY([DetailPasienID])
REFERENCES [dbo].[DetailPasien] ([DetailPasienID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transaksi] CHECK CONSTRAINT [FK_Transaksi_DetailPasien_DetailPasienID]
GO
ALTER TABLE [dbo].[Transaksi]  WITH CHECK ADD  CONSTRAINT [FK_Transaksi_Pengguna_Username] FOREIGN KEY([Username])
REFERENCES [dbo].[Pengguna] ([Username])
GO
ALTER TABLE [dbo].[Transaksi] CHECK CONSTRAINT [FK_Transaksi_Pengguna_Username]
GO
ALTER TABLE [dbo].[Transaksi]  WITH CHECK ADD  CONSTRAINT [FK_Transaksi_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[Transaksi] CHECK CONSTRAINT [FK_Transaksi_Tenant_TenantID]
GO
USE [master]
GO
ALTER DATABASE [testdb] SET  READ_WRITE 
GO
