CREATE DATABASE EJ_1_5_PROGII
GO
USE EJ_1_5_PROGII
GO

CREATE TABLE Formas_Pagos(
id_forma_pago INT IDENTITY(1,1),
nombre VARCHAR(50)
CONSTRAINT pk_Formas_Pagos PRIMARY KEY (id_forma_pago)
)

CREATE TABLE Articulos(
id_articulo INT IDENTITY(1,1),
nombre VARCHAR(50),
precioUnitario DECIMAL(10,2)
CONSTRAINT pk_Articulos PRIMARY KEY (id_articulo)
)


CREATE TABLE Facturas(
nro_factura INT IDENTITY (1,1) NOT NULL,
fecha DATE,
formaPago INT,
cliente VARCHAR(50)
CONSTRAINT pk_Facturas PRIMARY KEY (nro_factura),
CONSTRAINT fk_Facturas_Formas_Pagos FOREIGN KEY (formaPago)
        REFERENCES Formas_Pagos(id_forma_pago)
)

CREATE TABLE detalleFacturas(
id_detalle INT IDENTITY(1,1),
nro_factura  INT NOT NULL,
id_articulo INT not null,
cantidad INT NOT NULL
CONSTRAINT pk_detalleFacturas PRIMARY KEY (id_detalle),
CONSTRAINT fk_detalleFacturas_facturas FOREIGN KEY (nro_factura)
        REFERENCES Facturas (nro_factura),
CONSTRAINT fk_detalleFacturas_Articulos FOREIGN KEY (id_articulo)
        REFERENCES Articulos (id_articulo)
)


INSERT INTO Articulos (nombre,precioUnitario) VALUES ('Yerba',2500)
INSERT INTO Formas_Pagos (nombre) VALUES ('Efectivo')
INSERT INTO Formas_Pagos (nombre) VALUES ('Tarjeta Debito')
INSERT INTO Formas_Pagos (nombre) VALUES ('Tarjeta Credito')

INSERT INTO Facturas (fecha,formaPago,cliente)VALUES (GETDATE(),1,'Jeremias Lucco')

INSERT INTO detalleFacturas (nro_factura,id_articulo,cantidad)VALUES (1,1,3)




CREATE PROCEDURE SP_GETALL_FACTURAS
AS
BEGIN
    SELECT nro_factura,fecha, FP.id_forma_pago, FP.nombre, cliente
	FROM Facturas F
    JOIN Formas_Pagos FP ON F.formaPago = FP.id_forma_pago
END