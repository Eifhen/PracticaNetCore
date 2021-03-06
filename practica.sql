USE [master]
GO
/****** Object:  Database [PracticaMigracion]    Script Date: 1/3/2022 7:46:52 p. m. ******/
CREATE DATABASE [PracticaMigracion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PracticaMigracion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PracticaMigracion.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PracticaMigracion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PracticaMigracion_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PracticaMigracion] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PracticaMigracion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PracticaMigracion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PracticaMigracion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PracticaMigracion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PracticaMigracion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PracticaMigracion] SET ARITHABORT OFF 
GO
ALTER DATABASE [PracticaMigracion] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PracticaMigracion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PracticaMigracion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PracticaMigracion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PracticaMigracion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PracticaMigracion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PracticaMigracion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PracticaMigracion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PracticaMigracion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PracticaMigracion] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PracticaMigracion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PracticaMigracion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PracticaMigracion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PracticaMigracion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PracticaMigracion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PracticaMigracion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PracticaMigracion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PracticaMigracion] SET RECOVERY FULL 
GO
ALTER DATABASE [PracticaMigracion] SET  MULTI_USER 
GO
ALTER DATABASE [PracticaMigracion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PracticaMigracion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PracticaMigracion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PracticaMigracion] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PracticaMigracion] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PracticaMigracion', N'ON'
GO
ALTER DATABASE [PracticaMigracion] SET QUERY_STORE = OFF
GO
USE [PracticaMigracion]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/3/2022 7:46:53 p. m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipos]    Script Date: 1/3/2022 7:46:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Pais] [nvarchar](max) NULL,
	[Estado] [bit] NOT NULL,
	[FechaDeCreacion] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Equipos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jugadores]    Script Date: 1/3/2022 7:46:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugadores](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Apellido] [nvarchar](max) NOT NULL,
	[FechaNacimiento] [datetime2](7) NOT NULL,
	[Pasaporte] [nvarchar](max) NOT NULL,
	[Direccion] [nvarchar](max) NOT NULL,
	[Sexo] [bit] NOT NULL,
	[Id_EquipoId] [int] NULL,
	[id_EstadoID] [int] NULL,
 CONSTRAINT [PK_Jugadores] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TablaDeEstado]    Script Date: 1/3/2022 7:46:53 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TablaDeEstado](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NombreEstado] [nvarchar](max) NOT NULL,
	[FechaDeCreacion] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TablaDeEstado] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220301105839_firstMigration', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220301111647_cambio', N'5.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220301112243_correccion_estado_jugador', N'5.0.14')
GO
SET IDENTITY_INSERT [dbo].[Equipos] ON 

INSERT [dbo].[Equipos] ([Id], [Nombre], [Pais], [Estado], [FechaDeCreacion]) VALUES (2, N'Equipo Arias', N'DOM', 1, CAST(N'2022-03-02T09:09:00.0000000' AS DateTime2))
INSERT [dbo].[Equipos] ([Id], [Nombre], [Pais], [Estado], [FechaDeCreacion]) VALUES (3, N'Equipo Gabriel', N'DOM', 1, CAST(N'2022-03-01T09:09:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Equipos] OFF
GO
SET IDENTITY_INSERT [dbo].[Jugadores] ON 

INSERT [dbo].[Jugadores] ([Id], [Nombre], [Apellido], [FechaNacimiento], [Pasaporte], [Direccion], [Sexo], [Id_EquipoId], [id_EstadoID]) VALUES (5, N'Rosanny', N'Arias', CAST(N'2022-03-01T09:30:00.0000000' AS DateTime2), N'654231', N'calle 6', 0, 2, 5)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Apellido], [FechaNacimiento], [Pasaporte], [Direccion], [Sexo], [Id_EquipoId], [id_EstadoID]) VALUES (6, N'Gabriel', N'Jiménez', CAST(N'2022-03-01T18:56:00.0000000' AS DateTime2), N'654231', N'calle 5', 1, 2, 5)
INSERT [dbo].[Jugadores] ([Id], [Nombre], [Apellido], [FechaNacimiento], [Pasaporte], [Direccion], [Sexo], [Id_EquipoId], [id_EstadoID]) VALUES (7, N'Osiris', N'Arias', CAST(N'2022-03-01T18:56:00.0000000' AS DateTime2), N'654231', N'calle 5', 1, 3, 5)
SET IDENTITY_INSERT [dbo].[Jugadores] OFF
GO
SET IDENTITY_INSERT [dbo].[TablaDeEstado] ON 

INSERT [dbo].[TablaDeEstado] ([ID], [NombreEstado], [FechaDeCreacion]) VALUES (1, N'Agente Libre', CAST(N'2022-03-01T09:26:53.2255995' AS DateTime2))
INSERT [dbo].[TablaDeEstado] ([ID], [NombreEstado], [FechaDeCreacion]) VALUES (5, N'Activo', CAST(N'2022-03-01T15:25:22.5816010' AS DateTime2))
INSERT [dbo].[TablaDeEstado] ([ID], [NombreEstado], [FechaDeCreacion]) VALUES (6, N'Cancelado', CAST(N'2022-03-01T15:26:18.4538381' AS DateTime2))
INSERT [dbo].[TablaDeEstado] ([ID], [NombreEstado], [FechaDeCreacion]) VALUES (7, N'No definido', CAST(N'2022-03-01T15:29:27.9870211' AS DateTime2))
SET IDENTITY_INSERT [dbo].[TablaDeEstado] OFF
GO
/****** Object:  Index [IX_Jugadores_Id_EquipoId]    Script Date: 1/3/2022 7:46:53 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Jugadores_Id_EquipoId] ON [dbo].[Jugadores]
(
	[Id_EquipoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Jugadores_id_EstadoID]    Script Date: 1/3/2022 7:46:53 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Jugadores_id_EstadoID] ON [dbo].[Jugadores]
(
	[id_EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Equipos] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [FechaDeCreacion]
GO
ALTER TABLE [dbo].[Jugadores]  WITH CHECK ADD  CONSTRAINT [FK_Jugadores_Equipos_Id_EquipoId] FOREIGN KEY([Id_EquipoId])
REFERENCES [dbo].[Equipos] ([Id])
GO
ALTER TABLE [dbo].[Jugadores] CHECK CONSTRAINT [FK_Jugadores_Equipos_Id_EquipoId]
GO
ALTER TABLE [dbo].[Jugadores]  WITH CHECK ADD  CONSTRAINT [FK_Jugadores_TablaDeEstado_id_EstadoID] FOREIGN KEY([id_EstadoID])
REFERENCES [dbo].[TablaDeEstado] ([ID])
GO
ALTER TABLE [dbo].[Jugadores] CHECK CONSTRAINT [FK_Jugadores_TablaDeEstado_id_EstadoID]
GO
USE [master]
GO
ALTER DATABASE [PracticaMigracion] SET  READ_WRITE 
GO
