CREATE DATABASE produccion
GO

USE [produccion]
GO
/****** Object:  Table [dbo].[Componentes]    Script Date: 13-09-2024 13:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Componentes](
	[codigo] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalles_orden]    Script Date: 13-09-2024 13:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalles_orden](
	[id] [int] NOT NULL,
	[nro_orden] [int] NOT NULL,
	[componente] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Detalles_orden] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[nro_orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ordenes_produccion]    Script Date: 13-09-2024 13:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ordenes_produccion](
	[nro_orden] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NOT NULL,
	[modelo] [varchar](50) NOT NULL,
	[estado] [varchar](50) NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Ordenes_produccion] PRIMARY KEY CLUSTERED 
(
	[nro_orden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Componentes] ([codigo], [nombre]) VALUES (1, N'Componente A')
INSERT [dbo].[Componentes] ([codigo], [nombre]) VALUES (2, N'Componente B')
INSERT [dbo].[Componentes] ([codigo], [nombre]) VALUES (3, N'Componente C')
GO
INSERT [dbo].[Detalles_orden] ([id], [nro_orden], [componente], [cantidad]) VALUES (1, 1, 0, 10)
GO
SET IDENTITY_INSERT [dbo].[Ordenes_produccion] ON 

INSERT [dbo].[Ordenes_produccion] ([nro_orden], [fecha], [modelo], [estado], [cantidad]) VALUES (1, CAST(N'2024-09-13' AS Date), N'modelo test', N'Cancelada', 150)
SET IDENTITY_INSERT [dbo].[Ordenes_produccion] OFF
GO
/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_COMPONENTES]    Script Date: 13-09-2024 13:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CONSULTAR_COMPONENTES]
AS
BEGIN
	
	SELECT * from Componentes order by 2;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLE]    Script Date: 13-09-2024 13:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_DETALLE] 
	@nro_orden int,
	@id int, 
	@componente int, 
	@cantidad int
AS
BEGIN
	INSERT INTO Detalles_orden(nro_orden,id, componente, cantidad)
    VALUES (@nro_orden, @id, @componente, @cantidad);
  
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_MAESTRO]    Script Date: 13-09-2024 13:03:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_MAESTRO] 
	@fecha date, 
	@modelo varchar(50),
	@estado varchar(50),	
	@cantidad int,
	@nro_orden int OUTPUT
AS
BEGIN
	INSERT INTO Ordenes_produccion(fecha, modelo, cantidad, estado)
    VALUES (@fecha, @modelo, @cantidad, 'Creada');
    SET @nro_orden = SCOPE_IDENTITY();
END
GO