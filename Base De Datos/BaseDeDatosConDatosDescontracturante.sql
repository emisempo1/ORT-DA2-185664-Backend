USE [master]
GO
/****** Object:  Database [Descontracturante]    Script Date: 06/05/2021 20:08:36 ******/
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 06/05/2021 20:08:36 ******/
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
/****** Object:  Table [dbo].[Administrador]    Script Date: 06/05/2021 20:08:36 ******/
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
/****** Object:  Table [dbo].[Audios]    Script Date: 06/05/2021 20:08:36 ******/
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
/****** Object:  Table [dbo].[Categoria_Playlist]    Script Date: 06/05/2021 20:08:36 ******/
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
/****** Object:  Table [dbo].[Categorias]    Script Date: 06/05/2021 20:08:36 ******/
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
/****** Object:  Table [dbo].[Cita]    Script Date: 06/05/2021 20:08:36 ******/
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
/****** Object:  Table [dbo].[Playlists]    Script Date: 06/05/2021 20:08:36 ******/
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
/****** Object:  Table [dbo].[Playlists_Audio]    Script Date: 06/05/2021 20:08:36 ******/
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
/****** Object:  Table [dbo].[Problematica_Psicologo]    Script Date: 06/05/2021 20:08:36 ******/
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
/****** Object:  Table [dbo].[Psicologo]    Script Date: 06/05/2021 20:08:36 ******/
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
/****** Object:  Table [dbo].[Tokens]    Script Date: 06/05/2021 20:08:36 ******/
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210429184228_1', N'5.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210430121020_2', N'5.0.5')
GO
INSERT [dbo].[Administrador] ([Email], [Nombre], [Password]) VALUES (N'root', N'root', N'root')
GO
INSERT [dbo].[Audios] ([Nombre], [Duracion], [UnidadDeTiempo], [NombreCreador], [UrlImagen], [UrlMp3]) VALUES (N'Besame', 4, 0, N'El Reja', N'https://res.cloudinary.com/bidoware/image/upload/v1618153761/ImagenesAudios/elrejabesame_s4zdgd.jpg', N'https://res.cloudinary.com/bidoware/video/upload/v1618153735/Audios/El_Reja_-_Besame_dxvxwg.mp3')
INSERT [dbo].[Audios] ([Nombre], [Duracion], [UnidadDeTiempo], [NombreCreador], [UrlImagen], [UrlMp3]) VALUES (N'Insegura', 2, 0, N'Vas', N'https://res.cloudinary.com/bidoware/image/upload/v1619909204/ImagenesAudios/vas_insegura_idw9t8.jpg', N'https://res.cloudinary.com/bidoware/video/upload/v1619909789/Audios/vas-insegura_drntat.mp3')
INSERT [dbo].[Audios] ([Nombre], [Duracion], [UnidadDeTiempo], [NombreCreador], [UrlImagen], [UrlMp3]) VALUES (N'Soltero Hasta la Tumba', 3, 0, N'El Reja', N'https://res.cloudinary.com/bidoware/image/upload/v1618094458/ImagenesAudios/ElRejaSolteroHastaLaTumba_ajfvmk.jpg', N'https://res.cloudinary.com/bidoware/video/upload/v1618091230/Audios/ElRejaSolteroHastaLaTumba_uirmx4.mp3')
GO
INSERT [dbo].[Categoria_Playlist] ([Categoria], [NombrePlaylist]) VALUES (2, N'Cachengue')
INSERT [dbo].[Categoria_Playlist] ([Categoria], [NombrePlaylist]) VALUES (2, N'Cumbia Cheta')
GO
SET IDENTITY_INSERT [dbo].[Cita] ON 

INSERT [dbo].[Cita] ([ID], [EmailPsicologo], [NombrePsicologo], [FechaConsulta], [TipoDeConsulta], [Direccion], [EmailPaciente]) VALUES (7, N'carlitoselpsicologo@gmail.com', N'Carlos', CAST(N'2021-04-30T00:00:00.0000000' AS DateTime2), 0, N'cerrolargo 2040', N'anibal@gmail.com')
INSERT [dbo].[Cita] ([ID], [EmailPsicologo], [NombrePsicologo], [FechaConsulta], [TipoDeConsulta], [Direccion], [EmailPaciente]) VALUES (8, N'elviejopsicologo@gmail.com', N'Roku', CAST(N'2021-04-30T00:00:00.0000000' AS DateTime2), 0, N'yaguaron 1415', N'martita@gmail.com')
INSERT [dbo].[Cita] ([ID], [EmailPsicologo], [NombrePsicologo], [FechaConsulta], [TipoDeConsulta], [Direccion], [EmailPaciente]) VALUES (9, N'elviejopsicologo@gmail.com', N'Roku', CAST(N'2021-04-30T00:00:00.0000000' AS DateTime2), 0, N'yaguaron 1415', N'martita@gmail.com')
INSERT [dbo].[Cita] ([ID], [EmailPsicologo], [NombrePsicologo], [FechaConsulta], [TipoDeConsulta], [Direccion], [EmailPaciente]) VALUES (10, N'elviejopsicologo@gmail.com', N'Roku', CAST(N'2021-04-30T00:00:00.0000000' AS DateTime2), 0, N'yaguaron 1415', N'martita@gmail.com')
INSERT [dbo].[Cita] ([ID], [EmailPsicologo], [NombrePsicologo], [FechaConsulta], [TipoDeConsulta], [Direccion], [EmailPaciente]) VALUES (11, N'elviejopsicologo@gmail.com', N'Roku', CAST(N'2021-04-30T00:00:00.0000000' AS DateTime2), 0, N'yaguaron 1415', N'martita@gmail.com')
INSERT [dbo].[Cita] ([ID], [EmailPsicologo], [NombrePsicologo], [FechaConsulta], [TipoDeConsulta], [Direccion], [EmailPaciente]) VALUES (12, N'elviejopsicologo@gmail.com', N'Roku', CAST(N'2021-04-30T00:00:00.0000000' AS DateTime2), 0, N'yaguaron 1415', N'anibal@gmail.com')
INSERT [dbo].[Cita] ([ID], [EmailPsicologo], [NombrePsicologo], [FechaConsulta], [TipoDeConsulta], [Direccion], [EmailPaciente]) VALUES (13, N'carlitoselpsicologo@gmail.com', N'Carlos', CAST(N'2021-04-30T00:00:00.0000000' AS DateTime2), 0, N'cerrolargo 2040', N'anibal@gmail.com')
INSERT [dbo].[Cita] ([ID], [EmailPsicologo], [NombrePsicologo], [FechaConsulta], [TipoDeConsulta], [Direccion], [EmailPaciente]) VALUES (14, N'carlitoselpsicologo@gmail.com', N'Carlos', CAST(N'2021-04-30T00:00:00.0000000' AS DateTime2), 0, N'cerrolargo 2040', N'anibal@gmail.com')
INSERT [dbo].[Cita] ([ID], [EmailPsicologo], [NombrePsicologo], [FechaConsulta], [TipoDeConsulta], [Direccion], [EmailPaciente]) VALUES (15, N'carlitoselpsicologo@gmail.com', N'Carlos', CAST(N'2021-04-30T00:00:00.0000000' AS DateTime2), 0, N'cerrolargo 2040', N'anibal@gmail.com')
INSERT [dbo].[Cita] ([ID], [EmailPsicologo], [NombrePsicologo], [FechaConsulta], [TipoDeConsulta], [Direccion], [EmailPaciente]) VALUES (16, N'carlitoselpsicologo@gmail.com', N'Carlos', CAST(N'2021-04-30T00:00:00.0000000' AS DateTime2), 0, N'cerrolargo 2040', N'anibal@gmail.com')
INSERT [dbo].[Cita] ([ID], [EmailPsicologo], [NombrePsicologo], [FechaConsulta], [TipoDeConsulta], [Direccion], [EmailPaciente]) VALUES (17, N'elviejopsicologo@gmail.com', N'Roku', CAST(N'2021-05-03T00:00:00.0000000' AS DateTime2), 0, N'yaguaron 1415', N'maxi@gmail.com')
INSERT [dbo].[Cita] ([ID], [EmailPsicologo], [NombrePsicologo], [FechaConsulta], [TipoDeConsulta], [Direccion], [EmailPaciente]) VALUES (18, N'elviejopsicologo@gmail.com', N'Roku', CAST(N'2021-05-06T00:00:00.0000000' AS DateTime2), 0, N'yaguaron 1415', N'maxi@gmail.com')
SET IDENTITY_INSERT [dbo].[Cita] OFF
GO
INSERT [dbo].[Playlists] ([Nombre], [Descripcion], [Url]) VALUES (N'Buenas vibras', N'Para vibrar bien', N'https://res.cloudinary.com/bidoware/image/upload/v1618094494/ImagenesPlaylist/cachengue_f86nkw.jpg')
INSERT [dbo].[Playlists] ([Nombre], [Descripcion], [Url]) VALUES (N'Cachengue', N'Para Escabiar y pasarla bien con tus panas', N'https://res.cloudinary.com/bidoware/image/upload/v1618094494/ImagenesPlaylist/cachengue_f86nkw.jpg')
INSERT [dbo].[Playlists] ([Nombre], [Descripcion], [Url]) VALUES (N'Cumbia Cheta', N'Para escuchar con tu chica', N'https://res.cloudinary.com/bidoware/image/upload/v1619909467/ImagenesPlaylist/cumbia_cheta_gbvg7j.jpg')
GO
INSERT [dbo].[Playlists_Audio] ([NombrePlaylist], [NombreAudio]) VALUES (N'Cachengue', N'Besame')
INSERT [dbo].[Playlists_Audio] ([NombrePlaylist], [NombreAudio]) VALUES (N'Cachengue', N'Soltero Hasta la Tumba')
INSERT [dbo].[Playlists_Audio] ([NombrePlaylist], [NombreAudio]) VALUES (N'Cumbia Cheta', N'Insegura')
GO
INSERT [dbo].[Problematica_Psicologo] ([Email], [NombreProblematica]) VALUES (N'carlitoselpsicologo@gmail.com', 0)
INSERT [dbo].[Problematica_Psicologo] ([Email], [NombreProblematica]) VALUES (N'carlitoselpsicologo@gmail.com', 1)
INSERT [dbo].[Problematica_Psicologo] ([Email], [NombreProblematica]) VALUES (N'carlitoselpsicologo@gmail.com', 2)
INSERT [dbo].[Problematica_Psicologo] ([Email], [NombreProblematica]) VALUES (N'elviejopsicologo@gmail.com', 0)
INSERT [dbo].[Problematica_Psicologo] ([Email], [NombreProblematica]) VALUES (N'elviejopsicologo@gmail.com', 1)
INSERT [dbo].[Problematica_Psicologo] ([Email], [NombreProblematica]) VALUES (N'elviejopsicologo@gmail.com', 2)
INSERT [dbo].[Problematica_Psicologo] ([Email], [NombreProblematica]) VALUES (N'luissuarez@gmail.com', 3)
INSERT [dbo].[Problematica_Psicologo] ([Email], [NombreProblematica]) VALUES (N'luissuarez@gmail.com', 4)
INSERT [dbo].[Problematica_Psicologo] ([Email], [NombreProblematica]) VALUES (N'luissuarez@gmail.com', 5)
GO
INSERT [dbo].[Psicologo] ([Email], [Nombre], [TipoDeConsulta], [FechaIngreso], [DireccionFisica]) VALUES (N'carlitoselpsicologo@gmail.com', N'Carlos', 0, CAST(N'2020-05-05T00:00:00.0000000' AS DateTime2), N'cerrolargo 2040')
INSERT [dbo].[Psicologo] ([Email], [Nombre], [TipoDeConsulta], [FechaIngreso], [DireccionFisica]) VALUES (N'elviejopsicologo@gmail.com', N'Roku', 0, CAST(N'1995-05-05T00:00:00.0000000' AS DateTime2), N'yaguaron 1415')
GO
INSERT [dbo].[Tokens] ([Id], [Fecha]) VALUES (N'98dd8635-868b-46bb-b599-23c57a3c966c', CAST(N'2021-04-29T18:32:22.4428426' AS DateTime2))
GO
USE [master]
GO
ALTER DATABASE [Descontracturante] SET  READ_WRITE 
GO
