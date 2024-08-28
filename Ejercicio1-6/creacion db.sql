USE master
GO
CREATE DATABASE EJ_1_6_PROGII
GO
USE EJ_1_6_PROGII
GO

CREATE TABLE clientes(
	id_cliente int identity(1,1),
	nombre varchar(50),
	apellido varchar(50),
	dni varchar(8),
	constraint pk_clientes primary key (id_cliente)
)
CREATE TABLE tipos_cuentas(
id_tipo_cuenta int identity(1,1),
tipo_cuenta varchar(50),
constraint pk_tipos_cuentas primary key (id_tipo_cuenta)

)

CREATE TABLE cuentas(
id_cuenta int identity(1,1),
cbu varchar(50),
saldo decimal(18,2),
ultimo_mov datetime,
tipo_cuenta int,
cliente int
constraint pk_cuentas primary key (id_cuenta),
constraint fk_cuentas_tipos_cuentas foreign key (tipo_cuenta)
	references tipos_cuentas (id_tipo_cuenta),
constraint fk_cuentas_clientes foreign key (cliente)
	references clientes (id_cliente)
)