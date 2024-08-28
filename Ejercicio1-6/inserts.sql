USE EJ_1_6_PROGII
GO

INSERT INTO tipos_cuentas (tipo_cuenta) VALUES ('Caja Ahorro')
INSERT INTO tipos_cuentas (tipo_cuenta) VALUES ('Cuenta Corriente')
INSERT INTO tipos_cuentas (tipo_cuenta) VALUES ('Caja Ahorro Dolares')


INSERT INTO clientes (nombre,apellido,dni) values ('JOEL','ACTIS','1102SJ')
INSERT INTO clientes (nombre,apellido,dni) values ('JO','PERALTA','222SSA')
INSERT INTO clientes (nombre,apellido,dni) values ('VALEN','SIAGA','54425J')

INSERT INTO cuentas(cbu,saldo,ultimo_mov,tipo_cuenta,cliente) values ('L1224124124',3000.23,GETDATE(),1,1)
INSERT INTO cuentas(cbu,saldo,ultimo_mov,tipo_cuenta,cliente) values ('A122412473737saf124',23300.23,GETDATE(),2,3)
INSERT INTO cuentas(cbu,saldo,ultimo_mov,tipo_cuenta,cliente) values ('K4737848469u9',153000.23,GETDATE(),1,3)