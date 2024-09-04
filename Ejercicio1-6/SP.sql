USE EJ_1_6_PROGII
GO

--SP CUENTAS
CREATE PROCEDURE SP_GETALL_CUENTAS
AS
BEGIN
SELECT
c.id_cuenta,
c.cbu,
c.saldo,
c.ultimo_mov,
c.cliente,
c.tipo_cuenta
FROM cuentas C
JOIN clientes Cl on C.cliente = cl.id_cliente
JOIN tipos_cuentas tp on tp.id_tipo_cuenta = c.tipo_cuenta
END

CREATE PROCEDURE SP_GET_CUENTA
(
	@id_cuenta int
)
AS
BEGIN
SELECT
c.id_cuenta,
c.cbu,
c.saldo,
c.ultimo_mov,
c.cliente,
c.tipo_cuenta
FROM cuentas C
JOIN clientes Cl on C.cliente = cl.id_cliente
JOIN tipos_cuentas tp on tp.id_tipo_cuenta = c.tipo_cuenta
WHERE id_cuenta = @id_cuenta
END

CREATE PROCEDURE SP_UPSERT_CUENTA
(
@id_cuenta int,
@cbu varchar(50),
@saldo decimal(18,2),
@ultimo_mov datetime,
@cliente int,
@tipo_cuenta int
)
as
begin
	if @id_cuenta != 0
		begin
			update cuentas set cbu = @cbu, saldo = @saldo, ultimo_mov = @ultimo_mov, cliente = @cliente, tipo_cuenta = @tipo_cuenta
			where id_cuenta = @id_cuenta
		end
	else
		begin
			insert into cuentas (cbu,saldo,ultimo_mov,cliente,tipo_cuenta) values (@cbu,@saldo,@ultimo_mov,@cliente,@tipo_cuenta)
		end
end

CREATE PROCEDURE SP_DELETE_CUENTA
(
	@id_cuenta int
)
as
begin
	delete from cuentas where id_cuenta = @id_cuenta
end

-- SP CLIENTES
CREATE PROCEDURE SP_GETALL_CLIENTES
AS
BEGIN
	SELECT 
	c.id_cliente,
	c.nombre,
	c.apellido,
	c.dni
	FROM clientes C
END

CREATE PROCEDURE SP_CREAR_CLIENTES
(
@NOMBRE VARCHAR(50),
@APELLIDO VARCHAR(50),
@DNI VARCHAR(50),
@ID INT OUTPUT
)
AS
BEGIN
	INSERT INTO CLIENTES(nombre,apellido,dni) values (@NOMBRE,@APELLIDO,@DNI)
	SET @ID = SCOPE_IDENTITY()
END

CREATE PROCEDURE SP_MODIFICAR_CLIENTES
(
@ID INT,
@NOMBRE VARCHAR(50),
@APELLIDO VARCHAR(50),
@DNI VARCHAR(50)
)
AS
BEGIN
UPDATE clientes SET nombre = @NOMBRE, apellido = @APELLIDO, dni = @DNI
WHERE id_cliente = @ID
END
	
CREATE PROCEDURE SP_GET_CLIENTES
(@id_cliente int)
AS
BEGIN
	SELECT 
	c.id_cliente,
	c.nombre,
	c.apellido,
	c.dni
	FROM clientes C
	WHERE id_cliente = @id_cliente
END

-- SP TIPO_CUENTA

CREATE PROCEDURE SP_GETALL_TIPOS_CUENTAS
as
begin
	select 
	tc.id_tipo_cuenta,
	tc.tipo_cuenta
	from tipos_cuentas tc
end

CREATE PROCEDURE SP_GET_TIPO_CUENTA
(
@id_tipo_cuenta int
)
as
begin
	select 
	tc.id_tipo_cuenta,
	tc.tipo_cuenta
	from tipos_cuentas tc
	where tc.id_tipo_cuenta = @id_tipo_cuenta
end