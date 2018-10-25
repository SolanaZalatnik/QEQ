USE [QEQB03]
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarUsuario]    Script Date: 10/10/2018 10:39:46 ******/
DROP PROCEDURE [dbo].[sp_ModificarUsuario]
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarPregunta]    Script Date: 10/10/2018 10:39:46 ******/
DROP PROCEDURE [dbo].[sp_ModificarPregunta]
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarPersonaje]    Script Date: 10/10/2018 10:39:46 ******/
DROP PROCEDURE [dbo].[sp_ModificarPersonaje]
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarCategoria]    Script Date: 10/10/2018 10:39:46 ******/
DROP PROCEDURE [dbo].[sp_ModificarCategoria]
GO
/****** Object:  StoredProcedure [dbo].[sp_Login]    Script Date: 10/10/2018 10:39:46 ******/
DROP PROCEDURE [dbo].[sp_Login]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarUsuario]    Script Date: 10/10/2018 10:39:46 ******/
DROP PROCEDURE [dbo].[sp_InsertarUsuario]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarPregunta]    Script Date: 10/10/2018 10:39:46 ******/
DROP PROCEDURE [dbo].[sp_InsertarPregunta]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarPersonaje]    Script Date: 10/10/2018 10:39:46 ******/
DROP PROCEDURE [dbo].[sp_InsertarPersonaje]
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarCategoria]    Script Date: 10/10/2018 10:39:46 ******/
DROP PROCEDURE [dbo].[sp_InsertarCategoria]
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarPregunta]    Script Date: 10/10/2018 10:39:46 ******/
DROP PROCEDURE [dbo].[sp_EliminarPregunta]
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarPersonaje]    Script Date: 10/10/2018 10:39:46 ******/
DROP PROCEDURE [dbo].[sp_EliminarPersonaje]
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarCategoria]    Script Date: 10/10/2018 10:39:46 ******/
DROP PROCEDURE [dbo].[sp_EliminarCategoria]
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarUsuario]    Script Date: 10/10/2018 10:39:46 ******/
DROP PROCEDURE [dbo].[sp_BuscarUsuario]
GO
ALTER TABLE [dbo].[PreguntasPorPersonaje] DROP CONSTRAINT [FK_PreguntasPorPersonaje_Preguntas]
GO
ALTER TABLE [dbo].[PreguntasPorPersonaje] DROP CONSTRAINT [FK_PreguntasPorPersonaje_Personajes]
GO
ALTER TABLE [dbo].[PreguntasPorPartida] DROP CONSTRAINT [FK_PreguntasPorPartida_Usuarios]
GO
ALTER TABLE [dbo].[PreguntasPorPartida] DROP CONSTRAINT [FK_PreguntasPorPartida_Preguntas]
GO
ALTER TABLE [dbo].[PreguntasPorPartida] DROP CONSTRAINT [FK_PreguntasPorPartida_Partida]
GO
ALTER TABLE [dbo].[Personajes] DROP CONSTRAINT [FK_Personajes_Categorias]
GO
ALTER TABLE [dbo].[Partida] DROP CONSTRAINT [FK_Partida_Usuarios1]
GO
ALTER TABLE [dbo].[Partida] DROP CONSTRAINT [FK_Partida_Usuarios]
GO
ALTER TABLE [dbo].[DetallesPartidaPorJugador] DROP CONSTRAINT [FK_DetallesPartidaPorJugador_Usuarios]
GO
ALTER TABLE [dbo].[DetallesPartidaPorJugador] DROP CONSTRAINT [FK_DetallesPartidaPorJugador_Partida]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 10/10/2018 10:39:46 ******/
DROP TABLE [dbo].[Usuarios]
GO
/****** Object:  Table [dbo].[PreguntasPorPersonaje]    Script Date: 10/10/2018 10:39:46 ******/
DROP TABLE [dbo].[PreguntasPorPersonaje]
GO
/****** Object:  Table [dbo].[PreguntasPorPartida]    Script Date: 10/10/2018 10:39:46 ******/
DROP TABLE [dbo].[PreguntasPorPartida]
GO
/****** Object:  Table [dbo].[Preguntas]    Script Date: 10/10/2018 10:39:46 ******/
DROP TABLE [dbo].[Preguntas]
GO
/****** Object:  Table [dbo].[Personajes]    Script Date: 10/10/2018 10:39:46 ******/
DROP TABLE [dbo].[Personajes]
GO
/****** Object:  Table [dbo].[Partida]    Script Date: 10/10/2018 10:39:46 ******/
DROP TABLE [dbo].[Partida]
GO
/****** Object:  Table [dbo].[DetallesPartidaPorJugador]    Script Date: 10/10/2018 10:39:46 ******/
DROP TABLE [dbo].[DetallesPartidaPorJugador]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 10/10/2018 10:39:46 ******/
DROP TABLE [dbo].[Categorias]
GO
USE [master]
GO
/****** Object:  Database [QEQB03]    Script Date: 10/10/2018 10:39:46 ******/
DROP DATABASE [QEQB03]
GO
/****** Object:  Database [QEQB03]    Script Date: 10/10/2018 10:39:46 ******/
CREATE DATABASE [QEQB03]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QEQB03', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QEQB03.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QEQB03_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QEQB03_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QEQB03] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QEQB03].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QEQB03] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QEQB03] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QEQB03] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QEQB03] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QEQB03] SET ARITHABORT OFF 
GO
ALTER DATABASE [QEQB03] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QEQB03] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QEQB03] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QEQB03] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QEQB03] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QEQB03] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QEQB03] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QEQB03] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QEQB03] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QEQB03] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QEQB03] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QEQB03] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QEQB03] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QEQB03] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QEQB03] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QEQB03] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QEQB03] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QEQB03] SET RECOVERY FULL 
GO
ALTER DATABASE [QEQB03] SET  MULTI_USER 
GO
ALTER DATABASE [QEQB03] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QEQB03] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QEQB03] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QEQB03] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QEQB03] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QEQB03', N'ON'
GO
ALTER DATABASE [QEQB03] SET QUERY_STORE = OFF
GO
USE [QEQB03]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [QEQB03]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[IDCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Categorías] PRIMARY KEY CLUSTERED 
(
	[IDCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesPartidaPorJugador]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesPartidaPorJugador](
	[IDDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IDUsuario] [int] NOT NULL,
	[IDPartida] [int] NOT NULL,
	[CantPreguntas] [int] NOT NULL,
	[CantArriesgados] [int] NOT NULL,
	[Puntaje] [int] NOT NULL,
 CONSTRAINT [PK_DetallesPartidaPorJugador] PRIMARY KEY CLUSTERED 
(
	[IDDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partida]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partida](
	[IDPartida] [int] IDENTITY(1,1) NOT NULL,
	[IDJugador1] [int] NOT NULL,
	[IDJugador2] [int] NULL,
 CONSTRAINT [PK_Partida] PRIMARY KEY CLUSTERED 
(
	[IDPartida] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personajes]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personajes](
	[IDPersonaje] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Imagen] [varchar](max) NOT NULL,
	[IDCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Personajes] PRIMARY KEY CLUSTERED 
(
	[IDPersonaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Preguntas]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preguntas](
	[IDPregunta] [int] IDENTITY(1,1) NOT NULL,
	[Pregunta] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Preguntas] PRIMARY KEY CLUSTERED 
(
	[IDPregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntasPorPartida]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntasPorPartida](
	[IDPregunta] [int] NOT NULL,
	[IDPartida] [int] NOT NULL,
	[IDUsuario] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PreguntasPorPersonaje]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreguntasPorPersonaje](
	[IDPregunta] [int] NOT NULL,
	[IDPersonaje] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IDUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombUsuario] [varchar](max) NOT NULL,
	[Nombre] [varchar](max) NOT NULL,
	[Apellido] [varchar](max) NOT NULL,
	[Contraseña] [varchar](max) NOT NULL,
	[Administrador] [bit] NOT NULL,
	[Puntaje] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IDUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetallesPartidaPorJugador]  WITH CHECK ADD  CONSTRAINT [FK_DetallesPartidaPorJugador_Partida] FOREIGN KEY([IDPartida])
REFERENCES [dbo].[Partida] ([IDPartida])
GO
ALTER TABLE [dbo].[DetallesPartidaPorJugador] CHECK CONSTRAINT [FK_DetallesPartidaPorJugador_Partida]
GO
ALTER TABLE [dbo].[DetallesPartidaPorJugador]  WITH CHECK ADD  CONSTRAINT [FK_DetallesPartidaPorJugador_Usuarios] FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuarios] ([IDUsuario])
GO
ALTER TABLE [dbo].[DetallesPartidaPorJugador] CHECK CONSTRAINT [FK_DetallesPartidaPorJugador_Usuarios]
GO
ALTER TABLE [dbo].[Partida]  WITH CHECK ADD  CONSTRAINT [FK_Partida_Usuarios] FOREIGN KEY([IDJugador1])
REFERENCES [dbo].[Usuarios] ([IDUsuario])
GO
ALTER TABLE [dbo].[Partida] CHECK CONSTRAINT [FK_Partida_Usuarios]
GO
ALTER TABLE [dbo].[Partida]  WITH CHECK ADD  CONSTRAINT [FK_Partida_Usuarios1] FOREIGN KEY([IDJugador2])
REFERENCES [dbo].[Usuarios] ([IDUsuario])
GO
ALTER TABLE [dbo].[Partida] CHECK CONSTRAINT [FK_Partida_Usuarios1]
GO
ALTER TABLE [dbo].[Personajes]  WITH CHECK ADD  CONSTRAINT [FK_Personajes_Categorias] FOREIGN KEY([IDCategoria])
REFERENCES [dbo].[Categorias] ([IDCategoria])
GO
ALTER TABLE [dbo].[Personajes] CHECK CONSTRAINT [FK_Personajes_Categorias]
GO
ALTER TABLE [dbo].[PreguntasPorPartida]  WITH CHECK ADD  CONSTRAINT [FK_PreguntasPorPartida_Partida] FOREIGN KEY([IDPartida])
REFERENCES [dbo].[Partida] ([IDPartida])
GO
ALTER TABLE [dbo].[PreguntasPorPartida] CHECK CONSTRAINT [FK_PreguntasPorPartida_Partida]
GO
ALTER TABLE [dbo].[PreguntasPorPartida]  WITH CHECK ADD  CONSTRAINT [FK_PreguntasPorPartida_Preguntas] FOREIGN KEY([IDPregunta])
REFERENCES [dbo].[Preguntas] ([IDPregunta])
GO
ALTER TABLE [dbo].[PreguntasPorPartida] CHECK CONSTRAINT [FK_PreguntasPorPartida_Preguntas]
GO
ALTER TABLE [dbo].[PreguntasPorPartida]  WITH CHECK ADD  CONSTRAINT [FK_PreguntasPorPartida_Usuarios] FOREIGN KEY([IDUsuario])
REFERENCES [dbo].[Usuarios] ([IDUsuario])
GO
ALTER TABLE [dbo].[PreguntasPorPartida] CHECK CONSTRAINT [FK_PreguntasPorPartida_Usuarios]
GO
ALTER TABLE [dbo].[PreguntasPorPersonaje]  WITH CHECK ADD  CONSTRAINT [FK_PreguntasPorPersonaje_Personajes] FOREIGN KEY([IDPersonaje])
REFERENCES [dbo].[Personajes] ([IDPersonaje])
GO
ALTER TABLE [dbo].[PreguntasPorPersonaje] CHECK CONSTRAINT [FK_PreguntasPorPersonaje_Personajes]
GO
ALTER TABLE [dbo].[PreguntasPorPersonaje]  WITH CHECK ADD  CONSTRAINT [FK_PreguntasPorPersonaje_Preguntas] FOREIGN KEY([IDPregunta])
REFERENCES [dbo].[Preguntas] ([IDPregunta])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PreguntasPorPersonaje] CHECK CONSTRAINT [FK_PreguntasPorPersonaje_Preguntas]
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarUsuario]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_BuscarUsuario]
@pUsuario varchar(MAX)
as
select NombUsuario from Usuarios
where @pUsuario = NombUsuario
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarCategoria]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_EliminarCategoria]
@pID int 
as
delete from Categorias
where IDCategoria = @pID
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarPersonaje]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_EliminarPersonaje]
@pID int
as

delete from Personajes where IDPersonaje = @pID
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarPregunta]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_EliminarPregunta]
@pID int 
as
delete from Preguntas
where IDPregunta = @pID
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarCategoria]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_InsertarCategoria]
@pCategoria varchar(MAX) 
as
insert into Categorias
(Categoria)
values(@pCategoria)
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarPersonaje]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_InsertarPersonaje]
@pNombre varchar(MAX),
@pImagen varchar(Max),
@pIDCategoria int
as

insert into Personajes (Nombre, Imagen, IDCategoria)
values (@pNombre, @pImagen, @pIDCategoria)
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarPregunta]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_InsertarPregunta]
@pPregunta varchar(MAX) 
as
insert into Preguntas
(Pregunta)
values(@pPregunta)
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarUsuario]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_InsertarUsuario]
@pNombUsuario varchar(MAX),
@pNombre varchar(MAX),
@pApellido varchar(MAX),
@pContraseña varchar(MAX),
@pAdministrador bit
as
insert into Usuarios
(NombUsuario , Nombre, Apellido, Contraseña, Administrador, Puntaje)
values(@pNombUsuario, @PNombre, @pApellido, HashBytes('SHA1','@PContraseña'), @pAdministrador, null)
GO
/****** Object:  StoredProcedure [dbo].[sp_Login]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Login]
@pNombre varchar(MAX),
@pContraseña varchar(MAX)
as
select * from Usuarios
where @pNombre = Usuarios.NombUsuario and  HashBytes('SHA1',@pContraseña) = Contraseña
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarCategoria]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ModificarCategoria]
@pCategoria varchar(MAX) 
as
update Categorias set
Categoria = @pCategoria
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarPersonaje]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ModificarPersonaje]
@pNombre varchar(MAX),
@pImagen varchar(Max),
@pIDCategoria int
as

update Personajes set Nombre = @pNombre , Imagen = @pImagen , IDCategoria = @pIDCategoria
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarPregunta]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ModificarPregunta]
@pPregunta varchar(MAX) 
as
update Preguntas set
Pregunta = @pPregunta
GO
/****** Object:  StoredProcedure [dbo].[sp_ModificarUsuario]    Script Date: 10/10/2018 10:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_ModificarUsuario]
@pNombUsuario varchar(MAX),
@pNombre varchar(MAX),
@pApellido varchar(MAX),
@pContraseña varchar(MAX),
@pAdministrar varchar(MAX),
@pPuntaje int
as
update Usuarios set NombUsuario = @pNombUsuario, Nombre = @pNombre, Apellido = @pApellido, Contraseña = HashBytes('SHA1',@pContraseña), Administrador = @pAdministrar, Puntaje = @pPuntaje
GO
USE [master]
GO
ALTER DATABASE [QEQB03] SET  READ_WRITE 
GO
