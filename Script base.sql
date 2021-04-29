USE [master]
GO
/****** Object:  Database [BombonesSqlFlamini]    Script Date: 29/04/2021 17:22:22 ******/
CREATE DATABASE [BombonesSqlFlamini]

GO
ALTER DATABASE [BombonesSqlFlamini] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BombonesSqlFlamini].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BombonesSqlFlamini] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BombonesSqlFlamini] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BombonesSqlFlamini] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BombonesSqlFlamini] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BombonesSqlFlamini] SET ARITHABORT OFF 
GO
ALTER DATABASE [BombonesSqlFlamini] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BombonesSqlFlamini] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BombonesSqlFlamini] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BombonesSqlFlamini] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BombonesSqlFlamini] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BombonesSqlFlamini] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BombonesSqlFlamini] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BombonesSqlFlamini] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BombonesSqlFlamini] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BombonesSqlFlamini] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BombonesSqlFlamini] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BombonesSqlFlamini] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BombonesSqlFlamini] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BombonesSqlFlamini] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BombonesSqlFlamini] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BombonesSqlFlamini] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BombonesSqlFlamini] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BombonesSqlFlamini] SET RECOVERY FULL 
GO
ALTER DATABASE [BombonesSqlFlamini] SET  MULTI_USER 
GO
ALTER DATABASE [BombonesSqlFlamini] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BombonesSqlFlamini] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BombonesSqlFlamini] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BombonesSqlFlamini] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BombonesSqlFlamini] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BombonesSqlFlamini', N'ON'
GO
ALTER DATABASE [BombonesSqlFlamini] SET QUERY_STORE = OFF
GO
USE [BombonesSqlFlamini]
GO
/****** Object:  Table [dbo].[Bombones]    Script Date: 29/04/2021 17:22:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bombones](
	[BombonId] [int] IDENTITY(1,1) NOT NULL,
	[NombreBombon] [nvarchar](255) NOT NULL,
	[TipoChocolateId] [int] NOT NULL,
	[TipoDeNuezId] [int] NOT NULL,
	[TipoRellenoId] [int] NOT NULL,
	[Descripcion] [nvarchar](255) NULL,
	[Costo] [money] NOT NULL,
	[CantidadEnExistencia] [int] NOT NULL,
 CONSTRAINT [PK_Bombones] PRIMARY KEY CLUSTERED 
(
	[BombonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cajas]    Script Date: 29/04/2021 17:22:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cajas](
	[CajaId] [int] IDENTITY(1,1) NOT NULL,
	[NombreCaja] [nvarchar](100) NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
	[PrecioVenta] [decimal](18, 2) NOT NULL,
	[UnidadesEnStock] [int] NOT NULL,
	[UnidadesEnPedido] [int] NOT NULL,
	[NivelDeReposicion] [int] NOT NULL,
	[Suspendido] [bit] NULL,
 CONSTRAINT [PK_Cajas] PRIMARY KEY CLUSTERED 
(
	[CajaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 29/04/2021 17:22:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[TipoDeDocumentoId] [int] NOT NULL,
	[NroDocumento] [nvarchar](10) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[LocalidadId] [int] NOT NULL,
	[ProvinciaId] [int] NOT NULL,
	[TelefonoFijo] [nvarchar](20) NULL,
	[TelefonoMovil] [nvarchar](20) NULL,
	[CorreoElectronico] [nvarchar](120) NULL,
	[FechaDeNacimiento] [date] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesVentas]    Script Date: 29/04/2021 17:22:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesVentas](
	[DetalleVentaId] [int] IDENTITY(1,1) NOT NULL,
	[VentaId] [int] NOT NULL,
	[BombonId] [int] NOT NULL,
	[Precio] [numeric](18, 2) NOT NULL,
	[Cantidad] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_DetallesVentas] PRIMARY KEY CLUSTERED 
(
	[DetalleVentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ItemsCajas]    Script Date: 29/04/2021 17:22:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemsCajas](
	[ItemCajaId] [int] IDENTITY(1,1) NOT NULL,
	[CajaId] [int] NOT NULL,
	[BombonId] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_ItemsCajas] PRIMARY KEY CLUSTERED 
(
	[ItemCajaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Localidades]    Script Date: 29/04/2021 17:22:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Localidades](
	[LocalidadId] [int] IDENTITY(1,1) NOT NULL,
	[ProvinciaId] [int] NOT NULL,
	[NombreLocalidad] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Localidades] PRIMARY KEY CLUSTERED 
(
	[LocalidadId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Provincias]    Script Date: 29/04/2021 17:22:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Provincias](
	[ProvinciaId] [int] IDENTITY(1,1) NOT NULL,
	[NombreProvincia] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Provincias] PRIMARY KEY CLUSTERED 
(
	[ProvinciaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDeNuez]    Script Date: 29/04/2021 17:22:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDeNuez](
	[TipoDeNuezId] [int] IDENTITY(1,1) NOT NULL,
	[NombreTipoDeNuez] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_TiposDeNuez] PRIMARY KEY CLUSTERED 
(
	[TipoDeNuezId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDeChocolate]    Script Date: 29/04/2021 17:22:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDeChocolate](
	[TipoChocolateId] [int] IDENTITY(1,1) NOT NULL,
	[NombreTipoChocolate] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_TiposDeChocolate] PRIMARY KEY CLUSTERED 
(
	[TipoChocolateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDeDocumentos]    Script Date: 29/04/2021 17:22:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDeDocumentos](
	[TipoDeDocumentoId] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[TipoDeDocumentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposDeRelleno]    Script Date: 29/04/2021 17:22:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposDeRelleno](
	[TipoRellenoId] [int] IDENTITY(1,1) NOT NULL,
	[NombreTipoRelleno] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_TiposDeRelleno] PRIMARY KEY CLUSTERED 
(
	[TipoRellenoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 29/04/2021 17:22:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[VentaId] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Ventas] PRIMARY KEY CLUSTERED 
(
	[VentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bombones] ON 
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (1, N'Almendra Ambrosia', 4, 1, 1, N'Avellana clásica con amaretto.', 44.0000, 30)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (2, N'Manzana Amore', 3, 1, 12, N'Cremoso chocolate con leche diseñado en forma de manzana con hojas de almendro.', 24.0000, 9)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (3, N'Almendra Suprema', 4, 1, 12, N'Almendras enteras inmersas en chocolate oscuro.', 30.0000, 2)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (4, N'Extasis Crepuscular', 1, 2, 6, N'Almendra con crema de moca recubierto de chocolate agridulce', 33.0000, 29)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (5, N'Anacardo Suprema', 4, 2, 12, N'Almendra gigante rodeada de chocolate oscuro.', 33.0000, 3)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (6, N'Avellana Amaretto', 3, 3, 1, N'Avellana clásica y amaretto envueltos en chocolate con leche.', 36.0000, 12)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (7, N'Avellana Virgen', 3, 3, 5, N'Las avellanas más suaves cubiertas por un cremoso chocolate con leche.', 26.0000, 0)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (8, N'Avellana Moca', 3, 3, 6, N'Avellana clásica y crema de moca suavizados con chocolate con leche.', 33.0000, 4)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (9, N'Avellana Amarga', 1, 3, 12, N'Clásica Avellana cubierta de chocolate Agridulce', 24.0000, 8)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (10, N'Corazón Destrozado', 2, 3, 12, N'Dos mitades de bombón bañadas en chocolate blando con avellanas', 30.0000, 19)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (11, N'Avellana Suprema', 4, 3, 12, N'Avellanas enteras inmersas en chocolate oscuro.', 21.0000, 8)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (12, N'Brasileño Supremo', 2, 4, 12, N'Una castaña del Brasil entera bañada en chocolate blanco.', 28.0000, 3)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (13, N'Chocolate Kiwi', 4, 4, 12, N'Castaña del Brasil rodeada de oscuro chocolate, una sección transversal parecida a la del fruto del kiwi.', 29.0000, 30)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (14, N'Macadamia Suprema', 3, 5, 12, N'Macadamia entera rodeada de chocolate con leche.', 40.0000, 6)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (15, N'Baya Agridulce', 1, 6, 2, N'Bayas de las Islas Orcas cubiertas con chocolate amargodulce', 25.0000, 14)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (16, N'Baya Dulce', 3, 6, 2, N'Bayas de las islas Orcas endulzadas con cremoso chocolate con leche.', 26.0000, 20)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (17, N'Cereza Agridulce', 1, 6, 3, N'Cereza Ana Real cubierto con chocolate Agridulce para conseguir ese toque de realeza.', 26.0000, 18)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (18, N'Cereza Dulce', 3, 6, 3, N'Cerezas Royal Anne endulzadas con cremoso chocolate con leche.', 27.0000, 17)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (19, N'Cereza Clásica', 4, 6, 3, N'Cereza entera en chocolate oscuro clásico', 28.0000, 30)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (20, N'Palma Tropical', 3, 6, 4, N'Chocolate con leche en forma de palma tropical rellena con coco.', 23.0000, 24)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (21, N'Corazón Amante', 3, 6, 5, N'Chocolate con leche en forma de corazón con dulce crema de cerezas a modo de relleno..', 25.0000, 21)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (22, N'Corazón Envuelto', 4, 6, 5, N'Chocolate oscuro con un coración de crema de cereza.', 32.0000, 24)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (23, N'Frambuesa Agridulce', 1, 6, 7, N'Fabulosas fresas salvajes cubiertas con chocolate agridulce para darles ese toque alpino.', 23.0000, 13)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (24, N'Frambuesa dulce', 5, 6, 7, N'Fabulosas fresas salvajes endulzadas con un cremoso chocolate con leche', 20.0000, 30)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (25, N'Delicia Mantequilla Cacahuate', 3, 6, 8, N'Duave y cremosa mantequilla de cacahuete de los más finos cacahuetes del Senegal, envuelta en chocolate con leche.', 21.0000, 2)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (26, N'Mazapán Hoja de roble', 1, 6, 9, N'Mazapán con la legendaria forma de hoja de roble con una cubierta de suave chocolate', 40.0000, 28)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (27, N'Golondrina de Mazapán', 2, 6, 9, N'Mazapán con forma de golondrina con alas de chocolate blanco.', 34.0000, 19)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (28, N'Arce de Mazapán', 3, 6, 9, N'Mazapán con forma de hoja de arce con un envoltorio de chocolate con leche.', 37.0000, 26)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (29, N'Maravilla Mazapán', 3, 6, 9, N'Mazapán en forma de almendra con una capa de chocolate con leche ', 33.0000, 25)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (30, N'Mazapán Pinzón', 3, 6, 9, N'Mazapán con pistachos, bañados en chocolate con leche', 32.0000, 15)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (31, N'Mazapán Delicia', 4, 6, 9, N'Delicioso mazapán con chocolate oscuro.', 38.0000, 23)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (32, N'Mermelada Agridulce', 1, 6, 10, N'Mermelada recubierta con chocolate Agridulce para conseguir ese toque británico.', 17.0000, 18)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (33, N'Mermelada Dulce', 3, 6, 10, N'Mermelada hecha con naranjas valencianas endulzada con cremoso chocolate con leche.', 18.0000, 30)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (34, N'Mora Agridulce', 1, 6, 11, N'Moras de las montañas Cascadas cubiertas con chocolate agridulce para darle ese toque alpino.', 25.0000, 5)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (35, N'No me olvides', 3, 6, 11, N'Bayas rellenas de chocolate con leche inolvidables, envueltas en delicados no me olvides.', 19.0000, 26)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (36, N'Calla Lily', 2, 6, 12, N'Elegante chocolate blando esculpido con forma de lirio.', 27.0000, 16)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (37, N'Belleza Americana', 4, 6, 12, N'Riquísimo chocolate oscuro esculpido con la forma de un capullo de rosa Belleza Americana.', 24.0000, 16)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (38, N'Nuez  Moca', 5, 7, 6, N'Dulce y cremosa moca con nueces', 19.0000, 3)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (39, N'Pistacho Moca', 5, 8, 6, N'Dulce y cremosa moca con pistachos', 21.0000, 28)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (40, N'Pistacho Supremo', 3, 8, 12, N'Conjunto de frutos de pistacho rodeados de chocolate con leche.', 30.0000, 5)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (43, N'Frutilla Blanca', 2, 6, 15, N'Chocolate blanco relleno de frutilla', 30.0000, 10)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (44, N'Fresa Delicia', 2, 6, 7, N'Chocolate blanco con un delicioso relleno de fresas', 35.0000, 15)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (45, N'Banana', 6, 6, 14, N'Chocolate semiamargo relleno de banana', 28.0000, 12)
GO
INSERT [dbo].[Bombones] ([BombonId], [NombreBombon], [TipoChocolateId], [TipoDeNuezId], [TipoRellenoId], [Descripcion], [Costo], [CantidadEnExistencia]) VALUES (53, N'kale', 1, 1, 4, N'', 12.0000, 3)
GO
SET IDENTITY_INSERT [dbo].[Bombones] OFF
GO
SET IDENTITY_INSERT [dbo].[Cajas] ON 
GO
INSERT [dbo].[Cajas] ([CajaId], [NombreCaja], [Descripcion], [PrecioVenta], [UnidadesEnStock], [UnidadesEnPedido], [NivelDeReposicion], [Suspendido]) VALUES (1, N'Mix Avellanas', N'Variado de Avellanas', CAST(357.00 AS Decimal(18, 2)), 20, 2, 10, 0)
GO
INSERT [dbo].[Cajas] ([CajaId], [NombreCaja], [Descripcion], [PrecioVenta], [UnidadesEnStock], [UnidadesEnPedido], [NivelDeReposicion], [Suspendido]) VALUES (2, N'Sin Relleno', N'', CAST(200.00 AS Decimal(18, 2)), 10, 0, 5, 0)
GO
INSERT [dbo].[Cajas] ([CajaId], [NombreCaja], [Descripcion], [PrecioVenta], [UnidadesEnStock], [UnidadesEnPedido], [NivelDeReposicion], [Suspendido]) VALUES (3, N'Sin Nuez', N'', CAST(150.00 AS Decimal(18, 2)), 6, 0, 3, 0)
GO
INSERT [dbo].[Cajas] ([CajaId], [NombreCaja], [Descripcion], [PrecioVenta], [UnidadesEnStock], [UnidadesEnPedido], [NivelDeReposicion], [Suspendido]) VALUES (4, N'La Bomba', N'De Todo', CAST(900.00 AS Decimal(18, 2)), 3, 0, 2, 0)
GO
INSERT [dbo].[Cajas] ([CajaId], [NombreCaja], [Descripcion], [PrecioVenta], [UnidadesEnStock], [UnidadesEnPedido], [NivelDeReposicion], [Suspendido]) VALUES (5, N'Mix Frutal', N'Variado de rellenos frutales', CAST(650.00 AS Decimal(18, 2)), 4, 1, 2, 0)
GO
SET IDENTITY_INSERT [dbo].[Cajas] OFF
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico], [FechaDeNacimiento]) VALUES (2, N'Juan', N'Perez', 1, N'14444455', N'Calle 1', 18, 1, N'', N'15151515', N'Juan@123.com', CAST(N'2021-04-28' AS Date))
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico], [FechaDeNacimiento]) VALUES (7, N'juan', N'Aguirre', 1, N'1111', N'Peron 12', 5, 1, N'', N'', N'', CAST(N'1987-04-27' AS Date))
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico], [FechaDeNacimiento]) VALUES (8, N'Maria', N'Martinez', 1, N'23564854', N'Sarmiento 44', 1, 1, N'425789', N'15456456', N'maria@axp.com', CAST(N'1985-04-27' AS Date))
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico], [FechaDeNacimiento]) VALUES (10, N'Martin', N'Gibesi', 1, N'152525', N'Arenales 45', 5, 1, N'425635', N'', N'', CAST(N'1999-04-28' AS Date))
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico], [FechaDeNacimiento]) VALUES (11, N'Marcela', N'Gomez', 1, N'125125', N'Azul 24', 5, 1, N'125125', N'128478', N'Mar@drt.com', CAST(N'1985-04-28' AS Date))
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico], [FechaDeNacimiento]) VALUES (14, N'Diego', N'Peralta', 1, N'35120230', N'Cardoner 25', 5, 1, N'425365', N'15456456', N'Peralta@wen.com', CAST(N'2021-04-29' AS Date))
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico], [FechaDeNacimiento]) VALUES (18, N'Maricel', N'Aguirre', 1, N'32805306', N'Arrecifes 765', 18, 1, N'423701', N'15465867', N'Mari@fx.com', CAST(N'2021-04-29' AS Date))
GO
INSERT [dbo].[Clientes] ([ClienteId], [Nombre], [Apellido], [TipoDeDocumentoId], [NroDocumento], [Direccion], [LocalidadId], [ProvinciaId], [TelefonoFijo], [TelefonoMovil], [CorreoElectronico], [FechaDeNacimiento]) VALUES (19, N'Carolina', N'Garcia', 1, N'25145123', N'Sarmiento 55', 24, 1, N'', N'', N'', CAST(N'1985-04-29' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[DetallesVentas] ON 
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (1, 1, 1, CAST(44.00 AS Numeric(18, 2)), CAST(1.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (2, 1, 2, CAST(24.00 AS Numeric(18, 2)), CAST(2.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (3, 1, 3, CAST(30.00 AS Numeric(18, 2)), CAST(3.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (4, 1, 4, CAST(33.00 AS Numeric(18, 2)), CAST(4.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (5, 1, 5, CAST(33.00 AS Numeric(18, 2)), CAST(5.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (6, 1, 6, CAST(36.00 AS Numeric(18, 2)), CAST(6.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (7, 1, 7, CAST(26.00 AS Numeric(18, 2)), CAST(7.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (8, 1, 8, CAST(33.00 AS Numeric(18, 2)), CAST(8.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (9, 1, 9, CAST(24.00 AS Numeric(18, 2)), CAST(9.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (10, 1, 10, CAST(30.00 AS Numeric(18, 2)), CAST(10.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (11, 1, 11, CAST(21.00 AS Numeric(18, 2)), CAST(11.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (12, 1, 12, CAST(28.00 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (13, 1, 13, CAST(29.00 AS Numeric(18, 2)), CAST(13.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (14, 1, 14, CAST(40.00 AS Numeric(18, 2)), CAST(14.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (15, 1, 15, CAST(25.00 AS Numeric(18, 2)), CAST(15.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (16, 1, 16, CAST(26.00 AS Numeric(18, 2)), CAST(16.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (17, 1, 1, CAST(44.00 AS Numeric(18, 2)), CAST(2.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (18, 1, 2, CAST(24.00 AS Numeric(18, 2)), CAST(4.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (19, 1, 3, CAST(30.00 AS Numeric(18, 2)), CAST(6.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (20, 1, 4, CAST(33.00 AS Numeric(18, 2)), CAST(8.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (21, 1, 5, CAST(33.00 AS Numeric(18, 2)), CAST(10.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (22, 1, 6, CAST(36.00 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (23, 1, 7, CAST(26.00 AS Numeric(18, 2)), CAST(14.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (24, 1, 8, CAST(33.00 AS Numeric(18, 2)), CAST(16.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (25, 1, 9, CAST(24.00 AS Numeric(18, 2)), CAST(18.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (26, 1, 10, CAST(30.00 AS Numeric(18, 2)), CAST(20.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (27, 1, 11, CAST(21.00 AS Numeric(18, 2)), CAST(22.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (28, 1, 12, CAST(28.00 AS Numeric(18, 2)), CAST(24.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (29, 1, 13, CAST(29.00 AS Numeric(18, 2)), CAST(26.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (30, 1, 14, CAST(40.00 AS Numeric(18, 2)), CAST(28.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (31, 1, 15, CAST(25.00 AS Numeric(18, 2)), CAST(30.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (32, 1, 16, CAST(26.00 AS Numeric(18, 2)), CAST(32.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (33, 1, 17, CAST(26.00 AS Numeric(18, 2)), CAST(34.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (34, 1, 18, CAST(27.00 AS Numeric(18, 2)), CAST(36.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (35, 1, 19, CAST(28.00 AS Numeric(18, 2)), CAST(38.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (36, 1, 20, CAST(23.00 AS Numeric(18, 2)), CAST(40.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (37, 1, 21, CAST(25.00 AS Numeric(18, 2)), CAST(42.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (38, 1, 22, CAST(32.00 AS Numeric(18, 2)), CAST(44.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (39, 1, 23, CAST(23.00 AS Numeric(18, 2)), CAST(46.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (40, 2, 1, CAST(44.00 AS Numeric(18, 2)), CAST(1.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (41, 2, 2, CAST(24.00 AS Numeric(18, 2)), CAST(3.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (42, 2, 3, CAST(30.00 AS Numeric(18, 2)), CAST(4.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (43, 2, 4, CAST(33.00 AS Numeric(18, 2)), CAST(6.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (44, 2, 5, CAST(33.00 AS Numeric(18, 2)), CAST(7.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (45, 2, 6, CAST(36.00 AS Numeric(18, 2)), CAST(9.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (46, 2, 7, CAST(26.00 AS Numeric(18, 2)), CAST(10.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (47, 2, 8, CAST(33.00 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (48, 2, 9, CAST(24.00 AS Numeric(18, 2)), CAST(13.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (49, 2, 10, CAST(30.00 AS Numeric(18, 2)), CAST(15.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (50, 2, 11, CAST(21.00 AS Numeric(18, 2)), CAST(16.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (51, 2, 12, CAST(28.00 AS Numeric(18, 2)), CAST(18.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (52, 2, 13, CAST(29.00 AS Numeric(18, 2)), CAST(19.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (53, 2, 14, CAST(40.00 AS Numeric(18, 2)), CAST(21.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (54, 2, 15, CAST(25.00 AS Numeric(18, 2)), CAST(22.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (55, 2, 16, CAST(26.00 AS Numeric(18, 2)), CAST(24.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (56, 2, 17, CAST(26.00 AS Numeric(18, 2)), CAST(25.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (57, 2, 18, CAST(27.00 AS Numeric(18, 2)), CAST(27.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (58, 2, 19, CAST(28.00 AS Numeric(18, 2)), CAST(28.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (59, 2, 20, CAST(23.00 AS Numeric(18, 2)), CAST(30.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (60, 2, 21, CAST(25.00 AS Numeric(18, 2)), CAST(31.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (61, 2, 22, CAST(32.00 AS Numeric(18, 2)), CAST(33.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (62, 2, 23, CAST(23.00 AS Numeric(18, 2)), CAST(34.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (63, 3, 1, CAST(44.00 AS Numeric(18, 2)), CAST(2.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (64, 3, 2, CAST(24.00 AS Numeric(18, 2)), CAST(5.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (65, 3, 3, CAST(30.00 AS Numeric(18, 2)), CAST(7.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (66, 3, 4, CAST(33.00 AS Numeric(18, 2)), CAST(10.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (67, 3, 5, CAST(33.00 AS Numeric(18, 2)), CAST(12.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (68, 3, 6, CAST(36.00 AS Numeric(18, 2)), CAST(15.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (69, 3, 7, CAST(26.00 AS Numeric(18, 2)), CAST(17.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (70, 3, 8, CAST(33.00 AS Numeric(18, 2)), CAST(20.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (71, 3, 9, CAST(24.00 AS Numeric(18, 2)), CAST(22.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (72, 3, 10, CAST(30.00 AS Numeric(18, 2)), CAST(25.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (73, 3, 11, CAST(21.00 AS Numeric(18, 2)), CAST(27.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (74, 3, 12, CAST(28.00 AS Numeric(18, 2)), CAST(30.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (75, 3, 13, CAST(29.00 AS Numeric(18, 2)), CAST(32.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (76, 3, 14, CAST(40.00 AS Numeric(18, 2)), CAST(35.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (77, 3, 15, CAST(25.00 AS Numeric(18, 2)), CAST(37.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (78, 3, 16, CAST(26.00 AS Numeric(18, 2)), CAST(40.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (79, 3, 17, CAST(26.00 AS Numeric(18, 2)), CAST(42.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (80, 3, 18, CAST(27.00 AS Numeric(18, 2)), CAST(45.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (81, 3, 19, CAST(28.00 AS Numeric(18, 2)), CAST(47.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (82, 3, 20, CAST(23.00 AS Numeric(18, 2)), CAST(50.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (83, 3, 21, CAST(25.00 AS Numeric(18, 2)), CAST(52.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (84, 3, 22, CAST(32.00 AS Numeric(18, 2)), CAST(55.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (85, 3, 23, CAST(23.00 AS Numeric(18, 2)), CAST(57.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (86, 3, 24, CAST(20.00 AS Numeric(18, 2)), CAST(60.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (87, 3, 25, CAST(21.00 AS Numeric(18, 2)), CAST(62.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (88, 3, 26, CAST(40.00 AS Numeric(18, 2)), CAST(65.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (89, 3, 27, CAST(34.00 AS Numeric(18, 2)), CAST(67.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (90, 3, 28, CAST(37.00 AS Numeric(18, 2)), CAST(70.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (91, 3, 29, CAST(33.00 AS Numeric(18, 2)), CAST(72.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (92, 3, 30, CAST(32.00 AS Numeric(18, 2)), CAST(75.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (93, 3, 31, CAST(38.00 AS Numeric(18, 2)), CAST(77.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (94, 3, 32, CAST(17.00 AS Numeric(18, 2)), CAST(80.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (95, 3, 33, CAST(18.00 AS Numeric(18, 2)), CAST(82.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (96, 3, 34, CAST(25.00 AS Numeric(18, 2)), CAST(85.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (97, 3, 35, CAST(19.00 AS Numeric(18, 2)), CAST(87.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (98, 3, 36, CAST(27.00 AS Numeric(18, 2)), CAST(90.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (99, 3, 37, CAST(24.00 AS Numeric(18, 2)), CAST(92.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (100, 3, 38, CAST(19.00 AS Numeric(18, 2)), CAST(95.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (101, 3, 39, CAST(21.00 AS Numeric(18, 2)), CAST(97.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (102, 3, 40, CAST(30.00 AS Numeric(18, 2)), CAST(100.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (103, 3, 43, CAST(30.00 AS Numeric(18, 2)), CAST(107.50 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (104, 3, 44, CAST(35.00 AS Numeric(18, 2)), CAST(110.00 AS Numeric(18, 2)))
GO
INSERT [dbo].[DetallesVentas] ([DetalleVentaId], [VentaId], [BombonId], [Precio], [Cantidad]) VALUES (105, 3, 45, CAST(28.00 AS Numeric(18, 2)), CAST(112.50 AS Numeric(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[DetallesVentas] OFF
GO
SET IDENTITY_INSERT [dbo].[ItemsCajas] ON 
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (1, 1, 6, 6)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (2, 1, 7, 6)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (3, 1, 8, 6)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (4, 1, 9, 6)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (5, 1, 10, 6)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (6, 1, 11, 6)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (7, 2, 2, 6)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (8, 2, 3, 6)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (9, 2, 5, 6)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (10, 2, 9, 6)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (11, 2, 10, 6)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (12, 2, 11, 6)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (13, 2, 12, 6)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (14, 2, 13, 6)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (15, 2, 14, 6)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (16, 2, 36, 6)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (17, 2, 37, 6)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (18, 2, 40, 6)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (19, 3, 15, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (20, 3, 16, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (21, 3, 17, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (22, 3, 18, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (23, 3, 19, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (24, 3, 20, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (25, 3, 21, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (26, 3, 22, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (27, 3, 23, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (28, 3, 24, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (29, 3, 25, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (30, 3, 26, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (31, 3, 27, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (32, 3, 28, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (33, 3, 29, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (34, 3, 30, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (35, 3, 31, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (36, 3, 32, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (37, 3, 33, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (38, 3, 34, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (39, 3, 35, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (40, 3, 36, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (41, 3, 37, 3)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (42, 4, 1, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (43, 4, 2, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (44, 4, 3, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (45, 4, 4, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (46, 4, 5, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (47, 4, 6, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (48, 4, 7, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (49, 4, 8, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (50, 4, 9, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (51, 4, 10, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (52, 4, 11, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (53, 4, 12, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (54, 4, 13, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (55, 4, 14, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (56, 4, 15, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (57, 4, 16, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (58, 4, 17, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (59, 4, 18, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (60, 4, 19, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (61, 4, 20, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (62, 4, 21, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (63, 4, 22, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (64, 4, 23, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (65, 4, 24, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (66, 4, 25, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (67, 4, 26, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (68, 4, 27, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (69, 4, 28, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (70, 4, 29, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (71, 4, 30, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (72, 4, 31, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (73, 4, 32, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (74, 4, 33, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (75, 4, 34, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (76, 4, 35, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (77, 4, 36, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (78, 4, 37, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (79, 4, 38, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (80, 4, 39, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (81, 4, 40, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (82, 4, 15, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (83, 4, 16, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (84, 4, 17, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (85, 4, 18, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (86, 4, 19, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (87, 4, 20, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (88, 4, 23, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (89, 4, 24, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (90, 4, 34, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (91, 4, 35, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (92, 4, 43, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (93, 4, 44, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (94, 4, 45, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (95, 5, 15, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (96, 5, 16, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (97, 5, 17, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (98, 5, 18, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (99, 5, 19, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (100, 5, 20, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (101, 5, 23, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (102, 5, 24, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (103, 5, 34, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (104, 5, 35, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (105, 5, 43, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (106, 5, 44, 2)
GO
INSERT [dbo].[ItemsCajas] ([ItemCajaId], [CajaId], [BombonId], [Cantidad]) VALUES (107, 5, 45, 2)
GO
SET IDENTITY_INSERT [dbo].[ItemsCajas] OFF
GO
SET IDENTITY_INSERT [dbo].[Localidades] ON 
GO
INSERT [dbo].[Localidades] ([LocalidadId], [ProvinciaId], [NombreLocalidad]) VALUES (18, 1, N'Azul')
GO
INSERT [dbo].[Localidades] ([LocalidadId], [ProvinciaId], [NombreLocalidad]) VALUES (5, 1, N'Cañuelas')
GO
INSERT [dbo].[Localidades] ([LocalidadId], [ProvinciaId], [NombreLocalidad]) VALUES (12, 1, N'General Las Heras')
GO
INSERT [dbo].[Localidades] ([LocalidadId], [ProvinciaId], [NombreLocalidad]) VALUES (16, 1, N'Lobería')
GO
INSERT [dbo].[Localidades] ([LocalidadId], [ProvinciaId], [NombreLocalidad]) VALUES (1, 1, N'Lobos')
GO
INSERT [dbo].[Localidades] ([LocalidadId], [ProvinciaId], [NombreLocalidad]) VALUES (24, 1, N'Monte')
GO
INSERT [dbo].[Localidades] ([LocalidadId], [ProvinciaId], [NombreLocalidad]) VALUES (26, 1, N'Olavarria')
GO
INSERT [dbo].[Localidades] ([LocalidadId], [ProvinciaId], [NombreLocalidad]) VALUES (2, 1, N'Roque Perez')
GO
INSERT [dbo].[Localidades] ([LocalidadId], [ProvinciaId], [NombreLocalidad]) VALUES (25, 1, N'Saladillo')
GO
INSERT [dbo].[Localidades] ([LocalidadId], [ProvinciaId], [NombreLocalidad]) VALUES (20, 2, N'Colon')
GO
INSERT [dbo].[Localidades] ([LocalidadId], [ProvinciaId], [NombreLocalidad]) VALUES (19, 2, N'Curuzu Cuatia')
GO
INSERT [dbo].[Localidades] ([LocalidadId], [ProvinciaId], [NombreLocalidad]) VALUES (3, 3, N'Cosquín')
GO
INSERT [dbo].[Localidades] ([LocalidadId], [ProvinciaId], [NombreLocalidad]) VALUES (9, 3, N'Rio Cuarto')
GO
INSERT [dbo].[Localidades] ([LocalidadId], [ProvinciaId], [NombreLocalidad]) VALUES (23, 3, N'Rio Primero')
GO
INSERT [dbo].[Localidades] ([LocalidadId], [ProvinciaId], [NombreLocalidad]) VALUES (4, 3, N'Río Tercero')
GO
INSERT [dbo].[Localidades] ([LocalidadId], [ProvinciaId], [NombreLocalidad]) VALUES (29, 3, N'Salsipuedes')
GO
INSERT [dbo].[Localidades] ([LocalidadId], [ProvinciaId], [NombreLocalidad]) VALUES (10, 6, N'Resistencia')
GO
INSERT [dbo].[Localidades] ([LocalidadId], [ProvinciaId], [NombreLocalidad]) VALUES (13, 13, N'Santa Rosa')
GO
INSERT [dbo].[Localidades] ([LocalidadId], [ProvinciaId], [NombreLocalidad]) VALUES (15, 31, N'Gualeguay')
GO
SET IDENTITY_INSERT [dbo].[Localidades] OFF
GO
SET IDENTITY_INSERT [dbo].[Provincias] ON 
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (1, N'Buenos Aires')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (4, N'Catamarca')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (6, N'Chaco')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (15, N'Chubut')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (3, N'Córdoba')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (2, N'Corrientes')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (31, N'Entre Rios')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (33, N'Formosa')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (57, N'Gfd')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (13, N'La Pampa')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (58, N'lo')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (25, N'Mendoza')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (30, N'Misiones')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (10, N'Neuquen')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (5, N'Rio Negro')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (14, N'Salta')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (38, N'San Luis')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (22, N'Santa Fe')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (39, N'Santiago del Estero')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (44, N'Tierra del Fuego')
GO
INSERT [dbo].[Provincias] ([ProvinciaId], [NombreProvincia]) VALUES (43, N'Tucumán')
GO
SET IDENTITY_INSERT [dbo].[Provincias] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoDeNuez] ON 
GO
INSERT [dbo].[TipoDeNuez] ([TipoDeNuezId], [NombreTipoDeNuez]) VALUES (1, N'Almendra')
GO
INSERT [dbo].[TipoDeNuez] ([TipoDeNuezId], [NombreTipoDeNuez]) VALUES (2, N'Anacardo')
GO
INSERT [dbo].[TipoDeNuez] ([TipoDeNuezId], [NombreTipoDeNuez]) VALUES (3, N'Avellana')
GO
INSERT [dbo].[TipoDeNuez] ([TipoDeNuezId], [NombreTipoDeNuez]) VALUES (4, N'Castaña del Brasil')
GO
INSERT [dbo].[TipoDeNuez] ([TipoDeNuezId], [NombreTipoDeNuez]) VALUES (16, N'dfdhgcg')
GO
INSERT [dbo].[TipoDeNuez] ([TipoDeNuezId], [NombreTipoDeNuez]) VALUES (18, N'kj')
GO
INSERT [dbo].[TipoDeNuez] ([TipoDeNuezId], [NombreTipoDeNuez]) VALUES (5, N'Macadamia')
GO
INSERT [dbo].[TipoDeNuez] ([TipoDeNuezId], [NombreTipoDeNuez]) VALUES (9, N'Maní')
GO
INSERT [dbo].[TipoDeNuez] ([TipoDeNuezId], [NombreTipoDeNuez]) VALUES (6, N'Ninguna')
GO
INSERT [dbo].[TipoDeNuez] ([TipoDeNuezId], [NombreTipoDeNuez]) VALUES (7, N'Nuez')
GO
INSERT [dbo].[TipoDeNuez] ([TipoDeNuezId], [NombreTipoDeNuez]) VALUES (8, N'Pistacho')
GO
SET IDENTITY_INSERT [dbo].[TipoDeNuez] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposDeChocolate] ON 
GO
INSERT [dbo].[TiposDeChocolate] ([TipoChocolateId], [NombreTipoChocolate]) VALUES (1, N'Agridulce')
GO
INSERT [dbo].[TiposDeChocolate] ([TipoChocolateId], [NombreTipoChocolate]) VALUES (2, N'Blanco')
GO
INSERT [dbo].[TiposDeChocolate] ([TipoChocolateId], [NombreTipoChocolate]) VALUES (10, N'fgfhj')
GO
INSERT [dbo].[TiposDeChocolate] ([TipoChocolateId], [NombreTipoChocolate]) VALUES (12, N'hj')
GO
INSERT [dbo].[TiposDeChocolate] ([TipoChocolateId], [NombreTipoChocolate]) VALUES (3, N'Leche')
GO
INSERT [dbo].[TiposDeChocolate] ([TipoChocolateId], [NombreTipoChocolate]) VALUES (4, N'Oscuro')
GO
INSERT [dbo].[TiposDeChocolate] ([TipoChocolateId], [NombreTipoChocolate]) VALUES (5, N'Puro')
GO
INSERT [dbo].[TiposDeChocolate] ([TipoChocolateId], [NombreTipoChocolate]) VALUES (6, N'SemiAmargo')
GO
SET IDENTITY_INSERT [dbo].[TiposDeChocolate] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposDeDocumentos] ON 
GO
INSERT [dbo].[TiposDeDocumentos] ([TipoDeDocumentoId], [Descripcion]) VALUES (1, N'DNI')
GO
INSERT [dbo].[TiposDeDocumentos] ([TipoDeDocumentoId], [Descripcion]) VALUES (2, N'LC')
GO
INSERT [dbo].[TiposDeDocumentos] ([TipoDeDocumentoId], [Descripcion]) VALUES (3, N'Pasaporte')
GO
SET IDENTITY_INSERT [dbo].[TiposDeDocumentos] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposDeRelleno] ON 
GO
INSERT [dbo].[TiposDeRelleno] ([TipoRellenoId], [NombreTipoRelleno]) VALUES (1, N'Amaretto')
GO
INSERT [dbo].[TiposDeRelleno] ([TipoRellenoId], [NombreTipoRelleno]) VALUES (14, N'Banana')
GO
INSERT [dbo].[TiposDeRelleno] ([TipoRellenoId], [NombreTipoRelleno]) VALUES (2, N'Baya')
GO
INSERT [dbo].[TiposDeRelleno] ([TipoRellenoId], [NombreTipoRelleno]) VALUES (3, N'Cereza entera')
GO
INSERT [dbo].[TiposDeRelleno] ([TipoRellenoId], [NombreTipoRelleno]) VALUES (18, N'cffhjgjk')
GO
INSERT [dbo].[TiposDeRelleno] ([TipoRellenoId], [NombreTipoRelleno]) VALUES (4, N'Coco')
GO
INSERT [dbo].[TiposDeRelleno] ([TipoRellenoId], [NombreTipoRelleno]) VALUES (5, N'Crema de cereza')
GO
INSERT [dbo].[TiposDeRelleno] ([TipoRellenoId], [NombreTipoRelleno]) VALUES (6, N'Crema de Moca')
GO
INSERT [dbo].[TiposDeRelleno] ([TipoRellenoId], [NombreTipoRelleno]) VALUES (7, N'Fresa')
GO
INSERT [dbo].[TiposDeRelleno] ([TipoRellenoId], [NombreTipoRelleno]) VALUES (15, N'Frutilla')
GO
INSERT [dbo].[TiposDeRelleno] ([TipoRellenoId], [NombreTipoRelleno]) VALUES (20, N'kj')
GO
INSERT [dbo].[TiposDeRelleno] ([TipoRellenoId], [NombreTipoRelleno]) VALUES (8, N'Mantequilla cacahuate')
GO
INSERT [dbo].[TiposDeRelleno] ([TipoRellenoId], [NombreTipoRelleno]) VALUES (9, N'Mazapán')
GO
INSERT [dbo].[TiposDeRelleno] ([TipoRellenoId], [NombreTipoRelleno]) VALUES (13, N'Menta')
GO
INSERT [dbo].[TiposDeRelleno] ([TipoRellenoId], [NombreTipoRelleno]) VALUES (10, N'Mermelada')
GO
INSERT [dbo].[TiposDeRelleno] ([TipoRellenoId], [NombreTipoRelleno]) VALUES (11, N'Mora')
GO
INSERT [dbo].[TiposDeRelleno] ([TipoRellenoId], [NombreTipoRelleno]) VALUES (12, N'Ninguno')
GO
SET IDENTITY_INSERT [dbo].[TiposDeRelleno] OFF
GO
SET IDENTITY_INSERT [dbo].[Ventas] ON 
GO
INSERT [dbo].[Ventas] ([VentaId], [ClienteId], [Fecha]) VALUES (1, 2, CAST(N'2021-04-06T22:48:03.610' AS DateTime))
GO
INSERT [dbo].[Ventas] ([VentaId], [ClienteId], [Fecha]) VALUES (2, 2, CAST(N'2021-04-20T22:48:05.640' AS DateTime))
GO
INSERT [dbo].[Ventas] ([VentaId], [ClienteId], [Fecha]) VALUES (3, 2, CAST(N'2021-04-26T22:48:07.520' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Ventas] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Cajas_NombreCaja]    Script Date: 29/04/2021 17:22:23 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Cajas_NombreCaja] ON [dbo].[Cajas]
(
	[NombreCaja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX__Localidades_ProvinciaId_Localidades]    Script Date: 29/04/2021 17:22:23 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX__Localidades_ProvinciaId_Localidades] ON [dbo].[Localidades]
(
	[ProvinciaId] ASC,
	[NombreLocalidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Provincias_NombreProvincia]    Script Date: 29/04/2021 17:22:23 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Provincias_NombreProvincia] ON [dbo].[Provincias]
(
	[NombreProvincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TiposDeNuez_NombreTipoDeNuez]    Script Date: 29/04/2021 17:22:23 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TiposDeNuez_NombreTipoDeNuez] ON [dbo].[TipoDeNuez]
(
	[NombreTipoDeNuez] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TiposDeChocolate_NombreTipoChocolate]    Script Date: 29/04/2021 17:22:23 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TiposDeChocolate_NombreTipoChocolate] ON [dbo].[TiposDeChocolate]
(
	[NombreTipoChocolate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TiposDeDocumentos_Descripcion]    Script Date: 29/04/2021 17:22:23 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TiposDeDocumentos_Descripcion] ON [dbo].[TiposDeDocumentos]
(
	[Descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_TiposDeRelleno_TipoRelleno]    Script Date: 29/04/2021 17:22:23 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TiposDeRelleno_TipoRelleno] ON [dbo].[TiposDeRelleno]
(
	[NombreTipoRelleno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetallesVentas] ADD  CONSTRAINT [DF_DetallesVentas_VentaId]  DEFAULT ((0)) FOR [VentaId]
GO
ALTER TABLE [dbo].[DetallesVentas] ADD  CONSTRAINT [DF_DetallesVentas_BombonId]  DEFAULT ((0)) FOR [BombonId]
GO
ALTER TABLE [dbo].[DetallesVentas] ADD  CONSTRAINT [DF_DetallesVentas_Precio]  DEFAULT ((0)) FOR [Precio]
GO
ALTER TABLE [dbo].[DetallesVentas] ADD  CONSTRAINT [DF_DetallesVentas_Cantidad]  DEFAULT ((0)) FOR [Cantidad]
GO
ALTER TABLE [dbo].[Ventas] ADD  CONSTRAINT [DF_Ventas_ClienteId]  DEFAULT ((0)) FOR [ClienteId]
GO
ALTER TABLE [dbo].[Ventas] ADD  CONSTRAINT [DF_Ventas_Fecha]  DEFAULT (getdate()) FOR [Fecha]
GO
ALTER TABLE [dbo].[Bombones]  WITH CHECK ADD  CONSTRAINT [FK_Bombones_TipoDeNuez] FOREIGN KEY([TipoDeNuezId])
REFERENCES [dbo].[TipoDeNuez] ([TipoDeNuezId])
GO
ALTER TABLE [dbo].[Bombones] CHECK CONSTRAINT [FK_Bombones_TipoDeNuez]
GO
ALTER TABLE [dbo].[Bombones]  WITH CHECK ADD  CONSTRAINT [FK_Bombones_TiposDeChocolate] FOREIGN KEY([TipoChocolateId])
REFERENCES [dbo].[TiposDeChocolate] ([TipoChocolateId])
GO
ALTER TABLE [dbo].[Bombones] CHECK CONSTRAINT [FK_Bombones_TiposDeChocolate]
GO
ALTER TABLE [dbo].[Bombones]  WITH CHECK ADD  CONSTRAINT [FK_Bombones_TiposDeRelleno] FOREIGN KEY([TipoRellenoId])
REFERENCES [dbo].[TiposDeRelleno] ([TipoRellenoId])
GO
ALTER TABLE [dbo].[Bombones] CHECK CONSTRAINT [FK_Bombones_TiposDeRelleno]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Localidades] FOREIGN KEY([LocalidadId])
REFERENCES [dbo].[Localidades] ([LocalidadId])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Localidades]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Provincias] FOREIGN KEY([ProvinciaId])
REFERENCES [dbo].[Provincias] ([ProvinciaId])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Provincias]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_TiposDeDocumentos] FOREIGN KEY([TipoDeDocumentoId])
REFERENCES [dbo].[TiposDeDocumentos] ([TipoDeDocumentoId])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_TiposDeDocumentos]
GO
ALTER TABLE [dbo].[ItemsCajas]  WITH CHECK ADD  CONSTRAINT [FK_ItemsCajas_Bombones] FOREIGN KEY([BombonId])
REFERENCES [dbo].[Bombones] ([BombonId])
GO
ALTER TABLE [dbo].[ItemsCajas] CHECK CONSTRAINT [FK_ItemsCajas_Bombones]
GO
ALTER TABLE [dbo].[ItemsCajas]  WITH CHECK ADD  CONSTRAINT [FK_ItemsCajas_Cajas] FOREIGN KEY([CajaId])
REFERENCES [dbo].[Cajas] ([CajaId])
GO
ALTER TABLE [dbo].[ItemsCajas] CHECK CONSTRAINT [FK_ItemsCajas_Cajas]
GO
ALTER TABLE [dbo].[Localidades]  WITH CHECK ADD  CONSTRAINT [FK_Localidades_Provincias] FOREIGN KEY([ProvinciaId])
REFERENCES [dbo].[Provincias] ([ProvinciaId])
GO
ALTER TABLE [dbo].[Localidades] CHECK CONSTRAINT [FK_Localidades_Provincias]
GO
USE [master]
GO
ALTER DATABASE [BombonesSqlFlamini] SET  READ_WRITE 
GO
