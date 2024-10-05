
create DATABASE DB_ENVIOS
GO
USE [db_envios]
GO
/****** Object:  Table [dbo].[T_Empresas]    Script Date: 04-10-2024 13:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Empresas](
	[id] [int] NOT NULL,
	[razonSocial] [varchar](50) NOT NULL,
	[rubro] [varchar](50) NOT NULL,
	[fecha_baja] [datetime] NOT NULL,
	[cod_postal] [int] NOT NULL,
 CONSTRAINT [PK_T_Empresas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Envio]    Script Date: 04-10-2024 13:28:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Envio](
	[codigo] [int] IDENTITY(1,1) NOT NULL,
	[fecha_envio] [date] NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[estado] [varchar](50) NOT NULL,
	[dni_cliente] [varchar](50) NOT NULL,
	[id_empresa] [int] NOT NULL,
 CONSTRAINT [PK_Envios] PRIMARY KEY CLUSTERED 
(
	[codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[T_Envio]  WITH CHECK ADD  CONSTRAINT [FK_T_Envio_T_Empresas] FOREIGN KEY([id_empresa])
REFERENCES [dbo].[T_Empresas] ([id])
GO
ALTER TABLE [dbo].[T_Envio] CHECK CONSTRAINT [FK_T_Envio_T_Empresas]
GO
--/****** Object:  StoredProcedure [dbo].[SP_CONSULTAR_ENVIOS]    Script Date: 04-10-2024 13:28:52 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE PROCEDURE [dbo].[SP_CONSULTAR_ENVIOS] 
--	@dni_cliente int,
--	@fecha_desde datetime,
--	@fecha_hasta datetime
--AS
--BEGIN
--	SELECT t.* 
--	FROM T_Envio t
--	WHERE ((@dni_cliente = '') OR (t.dni_cliente = @dni_cliente))
--	 AND((@fecha_desde is null and @fecha_hasta is null) OR (fecha_envio between @fecha_desde and @fecha_hasta));
--END
--GO
--/****** Object:  StoredProcedure [dbo].[SP_REGISTRAR_CANCELACION_ENVIO]    Script Date: 04-10-2024 13:28:52 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE PROCEDURE [dbo].[SP_REGISTRAR_CANCELACION_ENVIO] 
--	@codigo int
--AS
--BEGIN
--	UPDATE T_Envio SET estado = 'Cancelado'
--	WHERE estado not in ('Entregado')
--	AND codigo = @codigo
	
--END
--GO
--/****** Object:  StoredProcedure [dbo].[SP_REGISTRAR_ENVIO]    Script Date: 04-10-2024 13:28:52 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--CREATE PROCEDURE [dbo].[SP_REGISTRAR_ENVIO] 
--	@fecha_envio date,
--	@direccion varchar(50),
--	@dni_cliente varchar(50)
--AS
--BEGIN
--	INSERT INTO T_Envio VALUES(@fecha_envio, @direccion, 'Para enviar', @dni_cliente)
--END
--GO

insert into T_Empresas (id,fecha_baja,cod_postal,razonSocial,rubro) values (1,'2003-01-02',800,'riot','esports')
insert into T_Envio (direccion,dni_cliente,estado,id_empresa,fecha_envio) values ('alberdi 49',3332,'entregado',1,'2024-04-01')