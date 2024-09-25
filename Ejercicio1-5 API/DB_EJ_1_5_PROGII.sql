USE MASTER
GO
CREATE DATABASE EJ_1_5_PROGII
GO
USE EJ_1_5_PROGII
GO

CREATE TABLE formas_pagos(
id_forma_pago INT IDENTITY(1,1),
nombre VARCHAR(50)
CONSTRAINT pk_formas_pagos PRIMARY KEY (id_forma_pago)
)

CREATE TABLE articulos(
id_articulo INT IDENTITY(1,1),
nombre VARCHAR(50),
precioUnitario DECIMAL(10,2)
CONSTRAINT pk_articulos PRIMARY KEY (id_articulo)
)


CREATE TABLE facturas(
nro_factura INT IDENTITY (1,1),
fecha DATE,
formaPago INT,
cliente VARCHAR(50)
CONSTRAINT pk_facturas PRIMARY KEY (nro_factura),
CONSTRAINT fk_facturas_formas_pagos FOREIGN KEY (formaPago)
        REFERENCES Formas_Pagos(id_forma_pago)
)

CREATE TABLE detalles_facturas(
id_detalle INT,
nro_factura  INT NOT NULL,
id_articulo INT not null,
cantidad INT NOT NULL
CONSTRAINT fk_detalleFacturas_facturas FOREIGN KEY (nro_factura)
        REFERENCES Facturas (nro_factura),
CONSTRAINT fk_detalleFacturas_Articulos FOREIGN KEY (id_articulo)
        REFERENCES Articulos (id_articulo),
 CONSTRAINT [PK_detalles_facturas] PRIMARY KEY CLUSTERED 
(
	[id_detalle] ASC,
	[nro_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


INSERT INTO articulos (nombre,precioUnitario) VALUES ('Yerba',2500)
INSERT INTO articulos (nombre,precioUnitario) VALUES ('Dulce de Leche',1800)
INSERT INTO articulos (nombre,precioUnitario) VALUES ('Azúcar',800)
INSERT INTO articulos (nombre,precioUnitario) VALUES ('Manteca',1200)


INSERT INTO formas_pagos (nombre) VALUES ('Efectivo')
INSERT INTO formas_pagos (nombre) VALUES ('Tarjeta Debito')
INSERT INTO formas_pagos (nombre) VALUES ('Tarjeta Credito')

--FC1
INSERT INTO facturas (fecha,formaPago,cliente)VALUES (GETDATE(),1,'Valentino Longo')

INSERT INTO detalles_facturas (id_detalle,nro_factura,id_articulo,cantidad)VALUES (1,1,1,3)
INSERT INTO detalles_facturas (id_detalle,nro_factura,id_articulo,cantidad)VALUES (2,1,2,1)

--FC2 
INSERT INTO facturas (fecha,formaPago,cliente)VALUES (GETDATE(),3,'Juan Perez')
INSERT INTO detalles_facturas (id_detalle,nro_factura,id_articulo,cantidad)VALUES (1,2,3,1)
INSERT INTO detalles_facturas (id_detalle,nro_factura,id_articulo,cantidad)VALUES (2,2,1,1)


-- STORE PROCEDURES -- 

CREATE PROCEDURE SP_GETALL_FACTURAS
AS
BEGIN
    SELECT nro_factura,fecha, FP.id_forma_pago, FP.nombre, cliente
	FROM Facturas F
    JOIN Formas_Pagos FP ON F.formaPago = FP.id_forma_pago
END

CREATE PROCEDURE SP_GET_FACTURA
(
@NRO_FACTURA INT
)
AS
BEGIN
	SELECT nro_factura,fecha, FP.id_forma_pago, FP.nombre, cliente
	FROM Facturas F
    JOIN Formas_Pagos FP ON F.formaPago = FP.id_forma_pago
	WHERE F.nro_factura = @NRO_FACTURA
END

CREATE PROCEDURE SP_NUEVA_FACTURA
(
@FORMA_PAGO INT,
@FECHA DATETIME,
@CLIENTE VARCHAR(50),
@NRO_FACTURA INT OUTPUT
)
AS
BEGIN
	INSERT INTO facturas (formaPago,fecha,cliente) VALUES (@FORMA_PAGO,@FECHA,@CLIENTE)
	SET @NRO_FACTURA = SCOPE_IDENTITY()
END


CREATE PROCEDURE SP_FACTURA_MODIFICADA
(
@NRO_FACTURA INT,
@FORMA_PAGO INT,
@CLIENTE VARCHAR(50),
@FECHA DATETIME
)
AS
BEGIN
	SET IDENTITY_INSERT [facturas] ON;
	INSERT INTO facturas (nro_factura,formaPago,fecha,cliente) VALUES (@NRO_FACTURA,@FORMA_PAGO,@FECHA,@CLIENTE)
	SET IDENTITY_INSERT [facturas] OFF;
END

CREATE PROCEDURE SP_ELIMINAR_FACTURA
(
@NRO_FACTURA INT
)
AS
BEGIN
	DELETE FROM facturas WHERE nro_factura = @NRO_FACTURA
END


CREATE PROCEDURE SP_GET_DETALLES_FACTURA
(
@NRO_FACTURA INT
)
AS
BEGIN
	SELECT
	A.id_articulo,
	A.nombre,
	A.precioUnitario,
	DF.cantidad
	FROM detalles_facturas DF
	JOIN articulos A on A.id_articulo = df.id_articulo
	WHERE DF.nro_factura = @NRO_FACTURA
END


CREATE PROCEDURE SP_NUEVO_DETALLE
(
	@ID_DETALLE INT,
	@ID_ARTICULO INT,
	@CANTIDAD INT,
	@FACTURA INT
)
AS
BEGIN
	INSERT INTO detalles_facturas (id_detalle,id_articulo,cantidad,nro_factura) VALUES (@ID_DETALLE,@ID_ARTICULO,@CANTIDAD,@FACTURA)
END

CREATE PROCEDURE SP_MODIFCAR_DETALLE
(
	@ID_DETALLE INT,
	@ID_ARTICULO INT,
	@CANTIDAD INT
)
AS
BEGIN
	UPDATE detalles_facturas  SET id_articulo = @ID_ARTICULO , cantidad = @CANTIDAD
	WHERE id_detalle = @ID_DETALLE
END

CREATE PROCEDURE SP_ELIMINAR_DETALLE
(
	@ID_DETALLE INT
)
AS
BEGIN
	DELETE FROM detalles_facturas
	WHERE id_detalle = @ID_DETALLE
END

CREATE PROCEDURE SP_ELIMINAR_DETALLES_FACTURA
(
	@NRO_FACTURA INT
)
AS
BEGIN
	DELETE FROM detalles_facturas
	WHERE nro_factura = @NRO_FACTURA
END

CREATE PROCEDURE SP_UPSERT_ARTICULO
(
@ID_ARTICULO INT,
@NOMBRE VARCHAR(50),
@PRECIO_UNITARIO DECIMAL(18,2)
)
AS
BEGIN
	IF @ID_ARTICULO != 0
		BEGIN
			UPDATE articulos SET nombre = @NOMBRE , precioUnitario = @PRECIO_UNITARIO
			WHERE id_articulo = @ID_ARTICULO
		END
	ELSE
		BEGIN
			INSERT INTO articulos (nombre,precioUnitario) VALUES (@NOMBRE,@PRECIO_UNITARIO)
		END
END


CREATE PROCEDURE SP_ELIMINAR_ARTICULO
(
@ID_ARTICULO INT
)
AS
BEGIN
	DELETE FROM articulos WHERE id_articulo = @ID_ARTICULO
END


CREATE PROCEDURE SP_GETALL_ARTICULOS
AS
BEGIN
	SELECT
	A.id_articulo,
	A.nombre,
	A.precioUnitario
	FROM articulos A
END

CREATE PROCEDURE SP_GET_ARTICULO
(
@ID_ARTICULO INT
)
AS
BEGIN
	SELECT
	A.id_articulo,
	A.nombre,
	A.precioUnitario
	FROM articulos A
	WHERE id_articulo = @ID_ARTICULO
END



CREATE PROCEDURE SP_GET_FACTURAS_FILTRO
(
@FECHA_INICIO DATE = null,
@FECHA_FIN DATE = null,
@ID_FP INT
)
AS
		-- SOLO FP
	IF @ID_FP != 0 AND @FECHA_FIN IS NULL AND @FECHA_FIN IS NULL
		BEGIN
			SELECT nro_factura,fecha, FP.id_forma_pago, FP.nombre, cliente
			FROM Facturas F
			JOIN Formas_Pagos FP ON F.formaPago = FP.id_forma_pago
			WHERE f.formaPago = @ID_FP
		END
		-- SOLO FECHAS
	ELSE IF @ID_FP = 0 AND @FECHA_FIN IS NOT NULL AND @FECHA_FIN IS NOT NULL
		BEGIN
			SELECT nro_factura,fecha, FP.id_forma_pago, FP.nombre, cliente
			FROM Facturas F
			JOIN Formas_Pagos FP ON F.formaPago = FP.id_forma_pago
			WHERE fecha BETWEEN @FECHA_INICIO AND @FECHA_FIN
		END
	ELSE
		-- AMBOS
		BEGIN
			SELECT nro_factura,fecha, FP.id_forma_pago, FP.nombre, cliente
			FROM Facturas F
			JOIN Formas_Pagos FP ON F.formaPago = FP.id_forma_pago
			WHERE fecha BETWEEN @FECHA_INICIO AND @FECHA_FIN
			AND f.formaPago = @ID_FP
		END

