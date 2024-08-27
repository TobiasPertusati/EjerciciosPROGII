CREATE DATABASE Almacen
GO

USE [Almacen]

GO

/** Object:  Table [dbo].[T_productos]    Script Date: 23/08/2024 19:56:56 **/

SET ANSI_NULLS ON

GO

SET QUOTED_IDENTIFIER ON

GO

CREATE TABLE [dbo].[T_productos](

	[codigo] [int] IDENTITY(1,1) NOT NULL,

	[n_producto] [varchar](50) NOT NULL,

	[precio] [float] NOT NULL,

	[stock] [int] NOT NULL,

	[esta_activo] [bit] NOT NULL

) ON [PRIMARY]

GO

CREATE PROCEDURE SP_LISTAR_PRODUCTOS
AS
BEGIN
	SELECT * FROM T_productos
END


EXEC SP_LISTAR_PRODUCTOS

CREATE PROCEDURE SP_GUARDAR_PRODUCTO
(
@codigo int,
@nombre varchar(50),
@precio float,
@stock int
)
AS
BEGIN
	if @codigo = 0
		BEGIN
			insert into T_productos (n_producto,precio,stock,esta_activo)
			values (@nombre,@precio,@stock,1)
		END
	ELSE
		BEGIN
		UPDATE T_productos set n_producto = @nombre, precio = @precio, stock = @stock
		END
END