USE [master]
GO
/****** Object:  Database [Inventarios]    Script Date: 16/04/2025 07:47:51 p. m. ******/
CREATE DATABASE [Inventarios]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Inventarios', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSSIRWEB\MSSQL\DATA\Inventarios.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Inventarios_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSSIRWEB\MSSQL\DATA\Inventarios_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Inventarios] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Inventarios].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Inventarios] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Inventarios] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Inventarios] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Inventarios] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Inventarios] SET ARITHABORT OFF 
GO
ALTER DATABASE [Inventarios] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Inventarios] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Inventarios] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Inventarios] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Inventarios] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Inventarios] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Inventarios] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Inventarios] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Inventarios] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Inventarios] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Inventarios] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Inventarios] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Inventarios] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Inventarios] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Inventarios] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Inventarios] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Inventarios] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Inventarios] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Inventarios] SET  MULTI_USER 
GO
ALTER DATABASE [Inventarios] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Inventarios] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Inventarios] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Inventarios] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Inventarios] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Inventarios] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Inventarios] SET QUERY_STORE = ON
GO
ALTER DATABASE [Inventarios] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Inventarios]
GO
/****** Object:  Table [dbo].[Historial]    Script Date: 16/04/2025 07:47:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Historial](
	[idHistorial] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](100) NOT NULL,
	[tipoMovimiento] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[fechaMovimiento] [datetime] NOT NULL,
 CONSTRAINT [PK_Historial] PRIMARY KEY CLUSTERED 
(
	[idHistorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 16/04/2025 07:47:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[cantidadExistencia] [int] NOT NULL,
	[estatus] [int] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 16/04/2025 07:47:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[estatus] [int] NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 16/04/2025 07:47:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[correo] [varchar](50) NULL,
	[contraseña] [varchar](25) NULL,
	[idRol] [int] NULL,
	[estatus] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Historial]  WITH CHECK ADD  CONSTRAINT [FK_Historial_Productos] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Productos] ([idProducto])
GO
ALTER TABLE [dbo].[Historial] CHECK CONSTRAINT [FK_Historial_Productos]
GO
ALTER TABLE [dbo].[Historial]  WITH CHECK ADD  CONSTRAINT [FK_Historial_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Historial] CHECK CONSTRAINT [FK_Historial_Usuarios]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([idRol])
REFERENCES [dbo].[Roles] ([idRol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
/****** Object:  StoredProcedure [dbo].[sP_Inventario_AumentarProductos_Act]    Script Date: 16/04/2025 07:47:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sP_Inventario_AumentarProductos_Act]
	
	@idProducto int
	, @Existencias int

AS
BEGIN
	
	UPDATE Productos
		SET cantidadExistencia = @Existencias
	WHERE 
		idProducto = @idProducto

	SELECT 1 AS Resultado
END
GO
/****** Object:  StoredProcedure [dbo].[sP_Inventario_EstatusProductos_Act]    Script Date: 16/04/2025 07:47:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sP_Inventario_EstatusProductos_Act]
	
	@idProducto int
	, @estatus int

AS
BEGIN
	
	UPDATE Productos
		SET estatus = @estatus
	WHERE 
		idProducto = @idProducto

	SELECT 1 AS Resultado
END
GO
/****** Object:  StoredProcedure [dbo].[sP_Inventario_Historial_Ins]    Script Date: 16/04/2025 07:47:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sP_Inventario_Historial_Ins]
	
	@descripcion varchar(100)
	, @tipoMovimiento int
	, @idUsuario int
	, @idProducto int
	, @fechaMovimiento datetime

AS
BEGIN
	
	INSERT INTO Historial
		(
			descripcion
			, tipoMovimiento
			, idUsuario
			, idProducto
			, fechaMovimiento
		)
     VALUES
        (
			@descripcion
			, @tipoMovimiento
			, @idUsuario
			, @idProducto
			, @fechaMovimiento
		)
	
	SELECT @@IDENTITY AS Resultado
END
GO
/****** Object:  StoredProcedure [dbo].[sP_Inventario_Historial_Obt]    Script Date: 16/04/2025 07:47:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sP_Inventario_Historial_Obt]

	@tipoMovimiento int

AS
BEGIN
	
	IF @tipoMovimiento = 0
	BEGIN
		SELECT 
			hst.idHistorial
		    , hst.descripcion
		    , hst.tipoMovimiento
		    , hst.idUsuario
			, usu.nombre AS nombreUSuario
		    , hst.idProducto
			, pdt.nombre AS nombreProducto
		    , hst.fechaMovimiento
		FROM 
			Historial hst

			INNER JOIN Usuarios usu
				ON usu.idUsuario = hst.idUsuario

			INNER JOIN Productos pdt
				ON pdt.idProducto = hst.idProducto
	END
	ELSE IF @tipoMovimiento = 1
	BEGIN
		SELECT 
			hst.idHistorial
		    , hst.descripcion
		    , hst.tipoMovimiento
		    , hst.idUsuario
			, usu.nombre AS nombreUSuario
		    , hst.idProducto
			, pdt.nombre AS nombreProducto
		    , hst.fechaMovimiento
		FROM 
			Historial hst

			INNER JOIN Usuarios usu
				ON usu.idUsuario = hst.idUsuario

			INNER JOIN Productos pdt
				ON pdt.idProducto = hst.idProducto
		WHERE
			tipoMovimiento = 1
	END
	ELSE IF @tipoMovimiento = 2
	BEGIN
		SELECT 
			hst.idHistorial
		    , hst.descripcion
		    , hst.tipoMovimiento
		    , hst.idUsuario
			, usu.nombre AS nombreUSuario
		    , hst.idProducto
			, pdt.nombre AS nombreProducto
		    , hst.fechaMovimiento
		FROM 
			Historial hst

			INNER JOIN Usuarios usu
				ON usu.idUsuario = hst.idUsuario

			INNER JOIN Productos pdt
				ON pdt.idProducto = hst.idProducto
		WHERE
			tipoMovimiento = 2
	END

END
GO
/****** Object:  StoredProcedure [dbo].[sP_Inventario_Productos_Ins]    Script Date: 16/04/2025 07:47:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sP_Inventario_Productos_Ins]
	
	@nombre varchar(100)

AS
BEGIN
	
	INSERT INTO Productos
		(
			nombre
			, cantidadExistencia
			, estatus
		)
     VALUES
		(
			@nombre
			, 0
			, 1
		)

	SELECT @@IDENTITY AS Resultado
END
GO
/****** Object:  StoredProcedure [dbo].[sP_Inventario_Productos_Obt]    Script Date: 16/04/2025 07:47:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sP_Inventario_Productos_Obt]


AS
BEGIN
	
	SELECT 
		idProducto
		, nombre
		, cantidadExistencia
		, estatus
	FROM 
		Productos
END
GO
/****** Object:  StoredProcedure [dbo].[sP_Inventario_ProductosActivos_Obt]    Script Date: 16/04/2025 07:47:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sP_Inventario_ProductosActivos_Obt]


AS
BEGIN
	
	SELECT 
		idProducto
		, nombre
		, cantidadExistencia
	FROM 
		Productos
	WHERE
		estatus = 1
END
GO
/****** Object:  StoredProcedure [dbo].[sP_Inventario_RestarProductos_Act]    Script Date: 16/04/2025 07:47:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sP_Inventario_RestarProductos_Act]
	
	@idProducto int
	, @cantidadRestada int

AS
BEGIN
	
	DECLARE @cantidadActualizada int

	SET @cantidadActualizada = (SELECT cantidadExistencia - @cantidadRestada AS Resultado FROM Productos WHERE idProducto = @idProducto) 
	
	UPDATE Productos
		SET cantidadExistencia = @cantidadActualizada
	WHERE 
		idProducto = @idProducto

	SELECT 1 AS Resultado
END
GO
/****** Object:  StoredProcedure [dbo].[sP_Inventario_ValidarUsuarios_Obt]    Script Date: 16/04/2025 07:47:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sP_Inventario_ValidarUsuarios_Obt]

	@correoUsuario varchar(50)
	, @contraseñaUsuario varchar(25)

AS
BEGIN
	
	SELECT
		idUsuario
		, nombre
		, idRol
	FROM 
		Usuarios
	WHERE
		correo = @correoUsuario
		AND contraseña = @contraseñaUsuario
		AND estatus = 1
END
GO
USE [master]
GO
ALTER DATABASE [Inventarios] SET  READ_WRITE 
GO
