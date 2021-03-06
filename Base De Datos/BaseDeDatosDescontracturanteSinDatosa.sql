USE [master]
GO
/****** Object:  Database [Descontracturante]    Script Date: 06/05/2021 20:03:52 ******/
CREATE DATABASE [Descontracturante]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Descontracturante', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Descontracturante.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Descontracturante_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Descontracturante_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Descontracturante] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Descontracturante].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Descontracturante] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Descontracturante] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Descontracturante] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Descontracturante] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Descontracturante] SET ARITHABORT OFF 
GO
ALTER DATABASE [Descontracturante] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Descontracturante] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Descontracturante] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Descontracturante] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Descontracturante] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Descontracturante] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Descontracturante] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Descontracturante] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Descontracturante] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Descontracturante] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Descontracturante] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Descontracturante] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Descontracturante] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Descontracturante] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Descontracturante] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Descontracturante] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Descontracturante] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Descontracturante] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Descontracturante] SET  MULTI_USER 
GO
ALTER DATABASE [Descontracturante] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Descontracturante] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Descontracturante] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Descontracturante] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Descontracturante] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Descontracturante] SET QUERY_STORE = OFF
GO
USE [Descontracturante]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 06/05/2021 20:03:52 ******/
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
/****** Object:  Table [dbo].[Administrador]    Script Date: 06/05/2021 20:03:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrador](
	[Email] [nvarchar](450) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Administrador] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Audios]    Script Date: 06/05/2021 20:03:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Audios](
	[Nombre] [nvarchar](450) NOT NULL,
	[Duracion] [int] NOT NULL,
	[UnidadDeTiempo] [int] NOT NULL,
	[NombreCreador] [nvarchar](max) NULL,
	[UrlImagen] [nvarchar](max) NULL,
	[UrlMp3] [nvarchar](max) NULL,
 CONSTRAINT [PK_Audios] PRIMARY KEY CLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria_Playlist]    Script Date: 06/05/2021 20:03:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria_Playlist](
	[Categoria] [int] NOT NULL,
	[NombrePlaylist] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Categoria_Playlist] PRIMARY KEY CLUSTERED 
(
	[Categoria] ASC,
	[NombrePlaylist] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 06/05/2021 20:03:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[NombreCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[NombreCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cita]    Script Date: 06/05/2021 20:03:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cita](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmailPsicologo] [nvarchar](max) NULL,
	[NombrePsicologo] [nvarchar](max) NULL,
	[FechaConsulta] [datetime2](7) NOT NULL,
	[TipoDeConsulta] [int] NOT NULL,
	[Direccion] [nvarchar](max) NULL,
	[EmailPaciente] [nvarchar](max) NULL,
 CONSTRAINT [PK_Cita] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playlists]    Script Date: 06/05/2021 20:03:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlists](
	[Nombre] [nvarchar](450) NOT NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Url] [nvarchar](max) NULL,
 CONSTRAINT [PK_Playlists] PRIMARY KEY CLUSTERED 
(
	[Nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Playlists_Audio]    Script Date: 06/05/2021 20:03:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Playlists_Audio](
	[NombrePlaylist] [nvarchar](450) NOT NULL,
	[NombreAudio] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_Playlists_Audio] PRIMARY KEY CLUSTERED 
(
	[NombrePlaylist] ASC,
	[NombreAudio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Problematica_Psicologo]    Script Date: 06/05/2021 20:03:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Problematica_Psicologo](
	[Email] [nvarchar](450) NOT NULL,
	[NombreProblematica] [int] NOT NULL,
 CONSTRAINT [PK_Problematica_Psicologo] PRIMARY KEY CLUSTERED 
(
	[Email] ASC,
	[NombreProblematica] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Psicologo]    Script Date: 06/05/2021 20:03:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Psicologo](
	[Email] [nvarchar](450) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[TipoDeConsulta] [int] NOT NULL,
	[FechaIngreso] [datetime2](7) NOT NULL,
	[DireccionFisica] [nvarchar](max) NULL,
 CONSTRAINT [PK_Psicologo] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tokens]    Script Date: 06/05/2021 20:03:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tokens](
	[Id] [nvarchar](450) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Tokens] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Descontracturante] SET  READ_WRITE 
GO
