create database db_almacen
go

USE [db_almacen]
GO
/****** Object:  Table [dbo].[T_Detalles_Presupuesto]    Script Date: 30-08-2024 15:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Detalles_Presupuesto](
	[id_detalle] [int] NOT NULL,
	[id_presupuesto] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [float] NOT NULL,
 CONSTRAINT [PK_Detalles_Presupuesto] PRIMARY KEY CLUSTERED 
(
	[id_detalle] ASC,
	[id_presupuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Presupuestos]    Script Date: 30-08-2024 15:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Presupuestos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cliente] [varchar](50) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[vigencia] [int] NOT NULL,
 CONSTRAINT [PK_T_Presupuestos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Productos]    Script Date: 30-08-2024 15:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Productos](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[n_producto] [varchar](50) NOT NULL,
	[stock] [int] NOT NULL,
	[esta_activo] [bit] NOT NULL,
 CONSTRAINT [PK_T_Productos] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[T_Presupuestos] ADD  CONSTRAINT [DF_T_Presupuestos_vigencia]  DEFAULT ((2)) FOR [vigencia]
GO
ALTER TABLE [dbo].[T_Detalles_Presupuesto]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_Presupuesto_T_Presupuestos] FOREIGN KEY([id_presupuesto])
REFERENCES [dbo].[T_Presupuestos] ([id])
GO
ALTER TABLE [dbo].[T_Detalles_Presupuesto] CHECK CONSTRAINT [FK_Detalles_Presupuesto_T_Presupuestos]
GO
ALTER TABLE [dbo].[T_Detalles_Presupuesto]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_Presupuesto_T_Productos] FOREIGN KEY([id_producto])
REFERENCES [dbo].[T_Productos] ([codigo])
GO
ALTER TABLE [dbo].[T_Detalles_Presupuesto] CHECK CONSTRAINT [FK_Detalles_Presupuesto_T_Productos]
GO
/****** Object:  StoredProcedure [dbo].[SP_GUARDAR_PRODUCTO]    Script Date: 30-08-2024 15:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GUARDAR_PRODUCTO]
@codigo int ,
@nombre varchar(20),
@stock int
AS
BEGIN 
	IF @codigo = 0
		BEGIN
			insert into T_Productos (n_producto, stock, esta_activo) 
			values (@nombre,@stock, 1)	
		END
	ELSE
		BEGIN
			update T_Productos 
			set n_producto= @nombre, stock= @stock 
			where codigo=@codigo
		END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_PRODUCTO_POR_CODIGO]    Script Date: 30-08-2024 15:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_RECUPERAR_PRODUCTO_POR_CODIGO]
	@codigo int
AS
BEGIN
	SELECT * FROM T_Productos WHERE codigo = @codigo;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_RECUPERAR_PRODUCTOS]    Script Date: 30-08-2024 15:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_RECUPERAR_PRODUCTOS] 
AS
BEGIN
	SELECT * FROM T_Productos
END
GO
/****** Object:  StoredProcedure [dbo].[SP_REGISTRAR_BAJA_PRODUCTO]    Script Date: 30-08-2024 15:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_REGISTRAR_BAJA_PRODUCTO] 
	@codigo int 

AS
BEGIN
	UPDATE T_Productos SET esta_activo = 0 WHERE codigo = @codigo;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_DETALLE]    Script Date: 30-08-2024 15:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_DETALLE] 
	@presupuesto int,
	@id_detalle int,
	@producto int,
	@cantidad int,
	@precio float

AS
BEGIN
	INSERT INTO T_Detalles_Presupuesto(id_detalle, id_presupuesto, id_producto, cantidad, precio) VALUES (@id_detalle, @presupuesto, @producto, @cantidad, @precio);
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_MAESTRO]    Script Date: 30-08-2024 15:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_INSERTAR_MAESTRO] 
	@cliente varchar(50),
	@vigencia int,
	@id int output
AS
BEGIN
	INSERT INTO T_Presupuestos(cliente, fecha, vigencia) VALUES (@cliente, GETDATE(), @vigencia);
	SET @id = SCOPE_IDENTITY();
END
GO