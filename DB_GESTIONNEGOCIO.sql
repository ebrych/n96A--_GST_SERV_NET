USE [DB_GESTIONNEGOCIO]
GO
/****** Object:  Table [dbo].[TB_ALMACENES]    Script Date: 23/08/2018 01:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ALMACENES](
	[idAlmacen] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](80) NOT NULL,
	[direccion] [varchar](100) NOT NULL,
	[telefono] [varchar](15) NULL,
	[fechaRegistro] [date] NOT NULL,
	[estado] [tinyint] NOT NULL,
	[fechaModificacion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[idAlmacen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_CLIENTES]    Script Date: 23/08/2018 01:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_CLIENTES](
	[idCliente] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](80) NOT NULL,
	[PrimerApellido] [varchar](80) NULL,
	[SegundoApellido] [varchar](80) NULL,
	[idTipoDocumento] [int] NOT NULL,
	[numeroDocumento] [varchar](15) NOT NULL,
	[telefono] [varchar](15) NULL,
	[direccion] [varchar](100) NOT NULL,
	[celular] [varchar](15) NULL,
	[mail] [varchar](80) NULL,
	[idTipoCliente] [int] NOT NULL,
	[fechaRegisto] [date] NOT NULL,
	[estado] [tinyint] NOT NULL,
	[fechaModificacion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_COMPRAS]    Script Date: 23/08/2018 01:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_COMPRAS](
	[idCompra] [bigint] IDENTITY(1,1) NOT NULL,
	[idProveedor] [bigint] NOT NULL,
	[fecha] [date] NOT NULL,
	[usuarioCrea] [int] NOT NULL,
	[idEstadoCompra] [int] NOT NULL,
	[montoTotal] [decimal](15, 2) NOT NULL,
	[descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_COMPROBANTES]    Script Date: 23/08/2018 01:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_COMPROBANTES](
	[idComprobante] [bigint] IDENTITY(1,1) NOT NULL,
	[serie] [varchar](10) NULL,
	[numeroComprobante] [varchar](50) NULL,
	[idNegocio] [bigint] NOT NULL,
	[idCliente] [bigint] NOT NULL,
	[idTipoComprobante] [int] NOT NULL,
	[fechaImpresion] [date] NULL,
	[fechaPago] [date] NULL,
	[descripcion] [varchar](100) NULL,
	[idEstadoComprobante] [int] NOT NULL,
	[subTotal] [decimal](15, 2) NOT NULL,
	[igv] [decimal](15, 2) NOT NULL,
	[total] [decimal](15, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_CONCEPTOS]    Script Date: 23/08/2018 01:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_CONCEPTOS](
	[idConcepto] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[estado] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idConcepto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_CONFIGURACION_GENERAL]    Script Date: 23/08/2018 01:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_CONFIGURACION_GENERAL](
	[idConfig] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[nombreNegocio] [varchar](50) NOT NULL,
	[color] [varchar](12) NOT NULL,
	[colorTexto] [varchar](12) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_DETALLE_COMPRAS]    Script Date: 23/08/2018 01:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_DETALLE_COMPRAS](
	[idCompraDetalle] [bigint] IDENTITY(1,1) NOT NULL,
	[idCompra] [bigint] NOT NULL,
	[idMaterial] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precioTotal] [decimal](15, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCompraDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_DETALLE_COMPROBANTE]    Script Date: 23/08/2018 01:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_DETALLE_COMPROBANTE](
	[idDetalleComprobante] [bigint] IDENTITY(1,1) NOT NULL,
	[idComprobante] [bigint] NOT NULL,
	[idConcepto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[monto] [decimal](15, 2) NOT NULL,
	[fechaRegistro] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[idDetalleComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_DETALLE_NOTA]    Script Date: 23/08/2018 01:34:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_DETALLE_NOTA](
	[idDetalleNota] [bigint] IDENTITY(1,1) NOT NULL,
	[idNota] [bigint] NOT NULL,
	[idMaterial] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[fechaRegistro] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[idDetalleNota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_DETALLE_ORDEN_PEDIDO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_DETALLE_ORDEN_PEDIDO](
	[idDetalleOrdenPedido] [bigint] IDENTITY(1,1) NOT NULL,
	[idOrdenPedido] [bigint] NOT NULL,
	[idMaterial] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[fechaRegistro] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[idDetalleOrdenPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_ERROR_LOG]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ERROR_LOG](
	[error] [text] NOT NULL,
	[proceso] [varchar](100) NOT NULL,
	[fecha] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_ESTADO_COMPRA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ESTADO_COMPRA](
	[idEstadoCompra] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idEstadoCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_ESTADO_COMPROBANTE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ESTADO_COMPROBANTE](
	[idEstadoComprobante] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idEstadoComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_ESTADO_NEGOCIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ESTADO_NEGOCIO](
	[idEstadoNegocio] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idEstadoNegocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_ESTADO_NOTA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ESTADO_NOTA](
	[idEstadoNota] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idEstadoNota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_kARDEX]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_kARDEX](
	[idMaterial] [int] NOT NULL,
	[fechaModificacion] [date] NOT NULL,
	[totalCompras] [int] NOT NULL,
	[totalPedidos] [int] NOT NULL,
	[total] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_MATERIAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_MATERIAL](
	[idMaterial] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](80) NOT NULL,
	[idTipoMaterial] [int] NOT NULL,
	[unidad] [varchar](15) NOT NULL,
	[fechaRegistro] [date] NOT NULL,
	[estado] [tinyint] NOT NULL,
	[fechaModificacion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[idMaterial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_MODULO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_MODULO](
	[idModulo] [int] IDENTITY(1,1) NOT NULL,
	[controlador] [varchar](80) NOT NULL,
	[titulo] [varchar](80) NOT NULL,
	[descripcion] [varchar](80) NOT NULL,
	[ruta] [varchar](100) NOT NULL,
	[icono] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_MODULO_ROL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_MODULO_ROL](
	[idRol] [int] NOT NULL,
	[idModulo] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_NEGOCIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_NEGOCIO](
	[idNegocio] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](80) NOT NULL,
	[idResponsable] [int] NOT NULL,
	[descripcion] [varchar](80) NULL,
	[idTipoNegocio] [int] NOT NULL,
	[fechaInicio] [date] NOT NULL,
	[fechaFin] [date] NOT NULL,
	[fechaRegistro] [date] NOT NULL,
	[idEstado] [int] NULL,
	[fechaModificacion] [date] NULL,
	[idCliente] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idNegocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_NOTAS]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_NOTAS](
	[idNota] [bigint] IDENTITY(1,1) NOT NULL,
	[idAlmacen] [int] NOT NULL,
	[descripcion] [varchar](100) NULL,
	[solicita] [int] NOT NULL,
	[responde] [int] NULL,
	[fechaSolicitud] [date] NOT NULL,
	[fechaRespuesta] [date] NULL,
	[idTipoNota] [int] NOT NULL,
	[idEstado] [int] NOT NULL,
	[idReferencia] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[idNota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_ORDEN_PEDIDO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ORDEN_PEDIDO](
	[idOrdenPedido] [bigint] IDENTITY(1,1) NOT NULL,
	[idNegocio] [int] NOT NULL,
	[idSolicita] [int] NOT NULL,
	[idResponde] [int] NULL,
	[total] [decimal](15, 2) NOT NULL,
	[idEstadoOrdenPedido] [int] NOT NULL,
	[fechaRegistro] [date] NOT NULL,
	[fechaCambioEstado] [date] NULL,
	[detalleRespuesta] [varchar](100) NULL,
	[descripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[idOrdenPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_ORDEN_PEDIDO_ESTADO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ORDEN_PEDIDO_ESTADO](
	[idEstadoOrdenPedido] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idEstadoOrdenPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_PERSONAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_PERSONAL](
	[idPersonal] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](80) NOT NULL,
	[primerApellido] [varchar](80) NOT NULL,
	[segundoApellido] [varchar](80) NULL,
	[idTipoDocumento] [int] NOT NULL,
	[numeroDocumento] [varchar](15) NOT NULL,
	[telefono] [varchar](15) NULL,
	[direccion] [varchar](100) NOT NULL,
	[mail] [varchar](80) NULL,
	[idTipoPersonal] [int] NOT NULL,
	[fechaRegistro] [date] NOT NULL,
	[fechaHabilitacion] [date] NULL,
	[fechaInhabilitacion] [date] NULL,
	[estado] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idPersonal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_PERSONAL_NEGOCIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_PERSONAL_NEGOCIO](
	[idPersonal] [int] NOT NULL,
	[idNegocio] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_PROVEEDOR]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_PROVEEDOR](
	[idProveedor] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](80) NOT NULL,
	[primerApellido] [varchar](50) NULL,
	[segundoApellido] [varchar](50) NULL,
	[idTipoDocumento] [int] NOT NULL,
	[numeroDocumento] [varchar](15) NOT NULL,
	[telefono] [varchar](15) NULL,
	[celular] [varchar](15) NULL,
	[direccion] [varchar](100) NOT NULL,
	[mail] [varchar](80) NULL,
	[fechaRegistro] [date] NOT NULL,
	[estado] [tinyint] NOT NULL,
	[fechaModificacion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[idProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_ROLES]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_ROLES](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_TIPO_CLIENTE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TIPO_CLIENTE](
	[idTipoCliente] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_TIPO_COMPROBANTE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TIPO_COMPROBANTE](
	[idTipoComprobante] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoComprobante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_TIPO_DOCUMNETO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TIPO_DOCUMNETO](
	[idTipoDocumento] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoDocumento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_TIPO_MATERIAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TIPO_MATERIAL](
	[idTipoMaterial] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[estado] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoMaterial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_TIPO_NEGOCIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TIPO_NEGOCIO](
	[idTipoNegocio] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[estado] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoNegocio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_TIPO_NOTAS]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TIPO_NOTAS](
	[idTipoNota] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoNota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_TIPO_PERSONAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TIPO_PERSONAL](
	[idTipoPersonal] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[estado] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTipoPersonal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_USUARIOS]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_USUARIOS](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [varchar](100) NOT NULL,
	[mail] [varchar](80) NOT NULL,
	[idRol] [int] NOT NULL,
	[fechaRegistro] [date] NOT NULL,
	[estado] [tinyint] NOT NULL,
	[token] [varchar](80) NOT NULL,
	[fechaActualizacion] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TB_ALMACENES] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[TB_CLIENTES] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[TB_CONCEPTOS] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[TB_kARDEX] ADD  DEFAULT ((0)) FOR [totalCompras]
GO
ALTER TABLE [dbo].[TB_kARDEX] ADD  DEFAULT ((0)) FOR [totalPedidos]
GO
ALTER TABLE [dbo].[TB_kARDEX] ADD  DEFAULT ((0)) FOR [total]
GO
ALTER TABLE [dbo].[TB_MATERIAL] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[TB_PERSONAL] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[TB_PROVEEDOR] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[TB_TIPO_MATERIAL] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[TB_TIPO_NEGOCIO] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[TB_TIPO_PERSONAL] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[TB_USUARIOS] ADD  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[TB_CLIENTES]  WITH CHECK ADD FOREIGN KEY([idTipoDocumento])
REFERENCES [dbo].[TB_TIPO_DOCUMNETO] ([idTipoDocumento])
GO
ALTER TABLE [dbo].[TB_CLIENTES]  WITH CHECK ADD FOREIGN KEY([idTipoCliente])
REFERENCES [dbo].[TB_TIPO_CLIENTE] ([idTipoCliente])
GO
ALTER TABLE [dbo].[TB_COMPRAS]  WITH CHECK ADD FOREIGN KEY([idEstadoCompra])
REFERENCES [dbo].[TB_ESTADO_COMPRA] ([idEstadoCompra])
GO
ALTER TABLE [dbo].[TB_COMPRAS]  WITH CHECK ADD FOREIGN KEY([idProveedor])
REFERENCES [dbo].[TB_PROVEEDOR] ([idProveedor])
GO
ALTER TABLE [dbo].[TB_COMPRAS]  WITH CHECK ADD FOREIGN KEY([usuarioCrea])
REFERENCES [dbo].[TB_USUARIOS] ([idUsuario])
GO
ALTER TABLE [dbo].[TB_COMPROBANTES]  WITH CHECK ADD FOREIGN KEY([idCliente])
REFERENCES [dbo].[TB_CLIENTES] ([idCliente])
GO
ALTER TABLE [dbo].[TB_COMPROBANTES]  WITH CHECK ADD FOREIGN KEY([idEstadoComprobante])
REFERENCES [dbo].[TB_ESTADO_COMPROBANTE] ([idEstadoComprobante])
GO
ALTER TABLE [dbo].[TB_COMPROBANTES]  WITH CHECK ADD FOREIGN KEY([idNegocio])
REFERENCES [dbo].[TB_NEGOCIO] ([idNegocio])
GO
ALTER TABLE [dbo].[TB_COMPROBANTES]  WITH CHECK ADD FOREIGN KEY([idTipoComprobante])
REFERENCES [dbo].[TB_TIPO_COMPROBANTE] ([idTipoComprobante])
GO
ALTER TABLE [dbo].[TB_DETALLE_COMPRAS]  WITH CHECK ADD FOREIGN KEY([idCompra])
REFERENCES [dbo].[TB_COMPRAS] ([idCompra])
GO
ALTER TABLE [dbo].[TB_DETALLE_COMPRAS]  WITH CHECK ADD FOREIGN KEY([idMaterial])
REFERENCES [dbo].[TB_MATERIAL] ([idMaterial])
GO
ALTER TABLE [dbo].[TB_DETALLE_COMPROBANTE]  WITH CHECK ADD FOREIGN KEY([idComprobante])
REFERENCES [dbo].[TB_COMPROBANTES] ([idComprobante])
GO
ALTER TABLE [dbo].[TB_DETALLE_COMPROBANTE]  WITH CHECK ADD FOREIGN KEY([idConcepto])
REFERENCES [dbo].[TB_CONCEPTOS] ([idConcepto])
GO
ALTER TABLE [dbo].[TB_DETALLE_NOTA]  WITH CHECK ADD FOREIGN KEY([idNota])
REFERENCES [dbo].[TB_NOTAS] ([idNota])
GO
ALTER TABLE [dbo].[TB_DETALLE_ORDEN_PEDIDO]  WITH CHECK ADD FOREIGN KEY([idMaterial])
REFERENCES [dbo].[TB_MATERIAL] ([idMaterial])
GO
ALTER TABLE [dbo].[TB_DETALLE_ORDEN_PEDIDO]  WITH CHECK ADD FOREIGN KEY([idOrdenPedido])
REFERENCES [dbo].[TB_ORDEN_PEDIDO] ([idOrdenPedido])
GO
ALTER TABLE [dbo].[TB_kARDEX]  WITH CHECK ADD FOREIGN KEY([idMaterial])
REFERENCES [dbo].[TB_MATERIAL] ([idMaterial])
GO
ALTER TABLE [dbo].[TB_MATERIAL]  WITH CHECK ADD FOREIGN KEY([idTipoMaterial])
REFERENCES [dbo].[TB_TIPO_MATERIAL] ([idTipoMaterial])
GO
ALTER TABLE [dbo].[TB_MODULO_ROL]  WITH CHECK ADD FOREIGN KEY([idModulo])
REFERENCES [dbo].[TB_MODULO] ([idModulo])
GO
ALTER TABLE [dbo].[TB_MODULO_ROL]  WITH CHECK ADD FOREIGN KEY([idRol])
REFERENCES [dbo].[TB_ROLES] ([idRol])
GO
ALTER TABLE [dbo].[TB_NEGOCIO]  WITH CHECK ADD FOREIGN KEY([idCliente])
REFERENCES [dbo].[TB_CLIENTES] ([idCliente])
GO
ALTER TABLE [dbo].[TB_NEGOCIO]  WITH CHECK ADD FOREIGN KEY([idEstado])
REFERENCES [dbo].[TB_ESTADO_NEGOCIO] ([idEstadoNegocio])
GO
ALTER TABLE [dbo].[TB_NEGOCIO]  WITH CHECK ADD FOREIGN KEY([idResponsable])
REFERENCES [dbo].[TB_PERSONAL] ([idPersonal])
GO
ALTER TABLE [dbo].[TB_NEGOCIO]  WITH CHECK ADD FOREIGN KEY([idTipoNegocio])
REFERENCES [dbo].[TB_TIPO_NEGOCIO] ([idTipoNegocio])
GO
ALTER TABLE [dbo].[TB_NOTAS]  WITH CHECK ADD FOREIGN KEY([idAlmacen])
REFERENCES [dbo].[TB_ALMACENES] ([idAlmacen])
GO
ALTER TABLE [dbo].[TB_NOTAS]  WITH CHECK ADD FOREIGN KEY([idEstado])
REFERENCES [dbo].[TB_ESTADO_NOTA] ([idEstadoNota])
GO
ALTER TABLE [dbo].[TB_NOTAS]  WITH CHECK ADD FOREIGN KEY([idTipoNota])
REFERENCES [dbo].[TB_TIPO_NOTAS] ([idTipoNota])
GO
ALTER TABLE [dbo].[TB_NOTAS]  WITH CHECK ADD FOREIGN KEY([solicita])
REFERENCES [dbo].[TB_USUARIOS] ([idUsuario])
GO
ALTER TABLE [dbo].[TB_ORDEN_PEDIDO]  WITH CHECK ADD FOREIGN KEY([idEstadoOrdenPedido])
REFERENCES [dbo].[TB_ORDEN_PEDIDO_ESTADO] ([idEstadoOrdenPedido])
GO
ALTER TABLE [dbo].[TB_ORDEN_PEDIDO]  WITH CHECK ADD FOREIGN KEY([idSolicita])
REFERENCES [dbo].[TB_USUARIOS] ([idUsuario])
GO
ALTER TABLE [dbo].[TB_PERSONAL]  WITH CHECK ADD FOREIGN KEY([idTipoDocumento])
REFERENCES [dbo].[TB_TIPO_DOCUMNETO] ([idTipoDocumento])
GO
ALTER TABLE [dbo].[TB_PERSONAL]  WITH CHECK ADD FOREIGN KEY([idTipoPersonal])
REFERENCES [dbo].[TB_TIPO_PERSONAL] ([idTipoPersonal])
GO
ALTER TABLE [dbo].[TB_PERSONAL_NEGOCIO]  WITH CHECK ADD FOREIGN KEY([idNegocio])
REFERENCES [dbo].[TB_NEGOCIO] ([idNegocio])
GO
ALTER TABLE [dbo].[TB_PERSONAL_NEGOCIO]  WITH CHECK ADD FOREIGN KEY([idPersonal])
REFERENCES [dbo].[TB_PERSONAL] ([idPersonal])
GO
ALTER TABLE [dbo].[TB_PROVEEDOR]  WITH CHECK ADD FOREIGN KEY([idTipoDocumento])
REFERENCES [dbo].[TB_TIPO_DOCUMNETO] ([idTipoDocumento])
GO
ALTER TABLE [dbo].[TB_USUARIOS]  WITH CHECK ADD FOREIGN KEY([idUsuario])
REFERENCES [dbo].[TB_ROLES] ([idRol])
GO
/****** Object:  StoredProcedure [dbo].[PS_LISTAR_PERSONAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--=============================================================================================

create procedure [dbo].[PS_LISTAR_PERSONAL]
as
select prs.idPersonal,prs.nombres,prs.primerApellido,prs.segundoApellido,
tpoDoc.descripcion as 'tipoDocumento',prs.numeroDocumento,prs.telefono,prs.direccion,
prs.mail,prs.fechaRegistro,tpo.descripcion as 'Tipo',prs.idTipoPersonal,
case
	when prs.estado=0 then 'Inactivo'
	when prs.estado=1 then 'Activo'
end as 'estado'  

from TB_PERSONAL prs
inner join TB_TIPO_PERSONAL tpo on prs.idTipoPersonal=tpo.idTipoPersonal
inner join TB_TIPO_DOCUMNETO tpoDoc on tpoDoc.idTipoDocumento=prs.idTipoDocumento
order by prs.idPersonal DESC 
GO
/****** Object:  StoredProcedure [dbo].[PS_LISTAR_TIPO_PERSONAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[PS_LISTAR_TIPO_PERSONAL]
as
select idTipoPersonal,descripcion from TB_TIPO_PERSONAL where estado=1
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZA_COMPRA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_ACTUALIZA_COMPRA]
(
@idCompra bigint,
@idProveedor bigint,
@idUsuario int,
@descripcion varchar(50)
)
as
declare
@estadoAct int
--estado actual
select @estadoAct=idEstadoCompra from TB_COMPRAS
if @estadoAct=1
begin
	update TB_COMPRAS set idProveedor=@idProveedor,usuarioCrea=@idUsuario,descripcion=@descripcion
	where idCompra=@idCompra
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZA_COMPROBANTE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================
create procedure [dbo].[SP_ACTUALIZA_COMPROBANTE]
(
@idComprobante bigint,
@serie varchar(10),
@numero varchar(50),
@idNegocio bigint,
@idCliente bigint,
@idTipo int,
@fechaImpresion date,
@fechaPago date,
@descripcion varchar(100),
@idEstado int
)
as
declare 
@estadoAct int
--estado acutual
select @estadoAct=idEstadoComprobante from TB_COMPROBANTES where idComprobante=@idComprobante
if @estadoAct = 1
begin
	update TB_COMPROBANTES set serie=@serie,numeroComprobante=@numero,idNegocio=@idNegocio,idCliente=@idCliente,
	idTipoComprobante=@idTipo,fechaImpresion=@fechaImpresion,fechaPago=@fechaPago,descripcion=@descripcion,
	idEstadoComprobante=@idEstado
	where idComprobante=@idComprobante
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZA_CONCEPTO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_ACTUALIZA_CONCEPTO]
(
@idConcepto int,
@descripcion varchar(50),
@estado tinyint
)
as
update TB_CONCEPTOS set descripcion=@descripcion,estado=@estado where idConcepto=@idConcepto
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZA_DATO_NEGOCIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================
create procedure [dbo].[SP_ACTUALIZA_DATO_NEGOCIO] 
(
@idNegocio bigint,
@nom varchar(80),
@idResponsable int,
@descripcion varchar(80),
@tipo int,
@fechaInicio datetime,
@fechaFin datetime,
@idCliente int,
@idEstado int
)
as
declare
@estadoAct int
select @estadoAct=idEstado from TB_NEGOCIO where idNegocio=@idNegocio 
if @estadoAct=1 or @estadoAct=2 or @estadoAct=3 or @estadoAct=4
	update TB_NEGOCIO set nombre=@nom,idResponsable=@idResponsable,descripcion=@descripcion,idTipoNegocio=@tipo,
	fechaInicio=@fechaInicio,fechaFin=@fechaFin,idCliente=@idCliente,idEstado=@idEstado,fechaModificacion=SYSDATETIME()
	WHERE idNegocio=@idNegocio
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZA_DATO_ORDEN_PEDIDO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================
create procedure [dbo].[SP_ACTUALIZA_DATO_ORDEN_PEDIDO]
(
@idOrdenPedido bigint,
@idNegocio bigint,
@idUsuario int,
@descripcion varchar(100)
)
as
declare
@estadoAct int
select @estadoAct=idEstado from TB_NEGOCIO where idNegocio=@idNegocio
if @estadoAct=2 or @estadoAct=3
update TB_ORDEN_PEDIDO set idNegocio=@idNegocio,idSolicita=@idUsuario,descripcion=@descripcion
where idOrdenPedido=@idOrdenPedido
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZA_PROVEEDOR]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================
create procedure [dbo].[SP_ACTUALIZA_PROVEEDOR] 
(
@idProveedor bigint,
@Nombres varchar(80),
@PrimerApellido varchar(50),
@SegundoApellido varchar(50),
@idTipoDocumento int,
@numeroDocumento varchar(15),
@Telefono varchar(15),
@Celular varchar(15),
@Direccion varchar(100),
@Mail varchar(80),
@estado tinyint
)
as
update  TB_PROVEEDOR set 
nombre = @Nombres,
primerApellido = @PrimerApellido,
segundoApellido= @SegundoApellido,
idTipoDocumento = @idTipoDocumento, 
numeroDocumento=@numeroDocumento,
telefono = @Telefono,
celular = @Celular,
direccion = @Direccion,
mail = @Mail, 
estado=@estado,
fechaModificacion=SYSDATETIME()
where idProveedor = @idProveedor
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZA_ROLE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_ACTUALIZA_ROLE]
(
@idRole int,
@descripcion varchar(150)
)
as
update TB_ROLES set descripcion=@descripcion where idRol=@idRole
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZA_TIPO_MATERIAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_ACTUALIZA_TIPO_MATERIAL]
(
@idTipoMaterial int,
@descripcion varchar(50),
@estado tinyint
)
as
update TB_TIPO_MATERIAL set descripcion=@descripcion,estado=@estado where idTipoMaterial=@idTipoMaterial
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZA_TIPO_NEGOCIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_ACTUALIZA_TIPO_NEGOCIO]
(
@idTipoNegocio int,
@descripcion varchar(50),
@estado tinyint
)
as
update TB_TIPO_NEGOCIO set descripcion=@descripcion,estado=@estado where idTipoNegocio=@idTipoNegocio
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZA_TIPO_PERSONAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================

create procedure [dbo].[SP_ACTUALIZA_TIPO_PERSONAL]
(
@idTipoPersonal int,
@descripcion varchar(50),
@estado tinyint
)
as
update TB_TIPO_PERSONAL set descripcion=@descripcion,estado=@estado where idTipoPersonal=@idTipoPersonal
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZA_USUARIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_ACTUALIZA_USUARIO]
(
@idUsuario int,
@nombres varchar(80),
@mail varchar(100),
@idRol bigint,
@estado tinyint
)
as
begin
update TB_USUARIOS set nombres=@nombres,mail=@mail,idRol=@idRol,estado=@estado,fechaActualizacion=SYSDATETIME() 
where idUsuario=@idUsuario
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_ALMACEN]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
CREATE PROCEDURE [dbo].[SP_ACTUALIZAR_ALMACEN] 
(
  @idAlmacen int,
  @Nombre varchar(80),
  @Direccion varchar(150),
  @Telefono varchar(15),
  @estado tinyint
)
AS
update  TB_ALMACENES set nombre = @Nombre, direccion = @Direccion, telefono = @Telefono,fechaModificacion=SYSDATETIME(),
estado=@estado
where idAlmacen = @idAlmacen
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_CLIENTE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_ACTUALIZAR_CLIENTE] 
(
@idCliente bigint,
@nom varchar(80),
@priAp varchar(80),
@segAp varchar(80),
@tpodoc int,
@nrodoc varchar(15),
@telef varchar(15),
@direccion varchar(100),
@celular varchar(15),
@mail varchar(80),
@tipo int,
@estado tinyint
)
as
update TB_CLIENTES set 
Nombres=@nom,PrimerApellido=@priAp,SegundoApellido=@segAp,idTipoDocumento=@tpodoc,
numeroDocumento=@nrodoc,telefono=@telef,direccion=@direccion,celular=@celular,mail=@mail,idTipoCliente=@tipo,
estado=@estado,fechaModificacion=SYSDATETIME()
where idCliente=@idCliente
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_MATERIAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_ACTUALIZAR_MATERIAL] 
(
@idMaterial bigint,
@descripcion varchar(80),
@tipo int,
@unidad varchar(15),
@estado tinyint
)
as
update TB_MATERIAL set descripcion=@descripcion,idTipoMaterial=@tipo,unidad=@unidad,estado=@estado,fechaModificacion=SYSDATETIME()
WHERE idMaterial=@idMaterial
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_NOTA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--=============================================================================================
create procedure [dbo].[SP_ACTUALIZAR_NOTA] 
(
@idNota bigint,
@idAlmacen int,
@descripcion varchar(100),
@idUserSol int,
@idTipoNota int,
@idReferencia int
)
as
declare
@estadoAct int
select @estadoAct=idEstado from TB_NOTAS where idNota=@idNota
if @estadoAct=1 
	update TB_NOTAS set
	idAlmacen=@idAlmacen,descripcion=@descripcion,solicita=@idUserSol,idTipoNota=@idTipoNota,idReferencia=@idReferencia
	where idNota=@idNota
GO
/****** Object:  StoredProcedure [dbo].[SP_ACTUALIZAR_PERSONAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_ACTUALIZAR_PERSONAL]
(
@idPersonal int,
@nom varchar(80),
@priAp varchar(80),
@segAp varchar(80),
@tipoDoc int,
@doc varchar(15),
@telef varchar(15),
@direccion varchar(100),
@mail varchar(80),
@tipo int,
@estado tinyint
)
as
update TB_PERSONAL 
set nombres=@nom,primerApellido=@priAp,segundoApellido=@segAp,idTipoDocumento=@tipoDoc,numeroDocumento=@doc,
telefono=@telef,direccion=@direccion,mail=@mail,idTipoPersonal=@tipo,estado=@estado
WHERE idPersonal=@idPersonal
GO
/****** Object:  StoredProcedure [dbo].[SP_AGEGAR_COMPROBANTE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_AGEGAR_COMPROBANTE]
(
@serie varchar(10),
@numero varchar(50),
@idNegocio bigint,
@idCliente bigint,
@idTipo int,
@fechaImpresion date,
@fechaPago date,
@descripcion varchar(100),
@idEstado int
)
as
declare
@estadoAct int
select @estadoAct=idEstado from TB_NEGOCIO where idNegocio=@idNegocio
if @estadoAct=3 or @estadoAct=4
insert into TB_COMPROBANTES (serie,numeroComprobante,idNegocio,idCliente,idTipoComprobante,fechaImpresion,fechaPago,
descripcion,idEstadoComprobante,subTotal,igv,total) values 
(@serie,@numero,@idNegocio,@idCliente,@idTipo,@fechaImpresion,@fechaPago,@descripcion,@idEstado,0,0,0)
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGA_DETALLE_COMPRA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_AGREGA_DETALLE_COMPRA]
(
@idCompra bigint,
@idMaterial int,
@cantidad int,
@precio decimal(15,2)
)
as
declare
@totalCompra decimal(15,2),
@totalNuevo decimal(15,2),
@totalMatPedido int,
@totalMatCompra int,
@totalMat int,
@resultadoMat int = 0,
@estadoAct int,
@existeMat int =0
--estado actual
select @estadoAct=idEstadoCompra from TB_COMPRAS where idCompra=@idCompra
if @estadoAct=1
begin
	select @totalMat=total,@totalMatPedido=totalPedidos,@totalMatCompra=totalCompras from TB_kARDEX where idMaterial=@idMaterial
	--calculo
	set @resultadoMat=(@totalMat-@totalMatPedido)+@totalMatCompra
	if @resultadoMat <= 0
	begin
		--valor total compra
		select @totalCompra=montoTotal from TB_COMPRAS where idCompra=@idCompra
		--calcular
		set @totalNuevo=@totalCompra+@precio
		--existe mate
		select @existeMat=count(*) from TB_DETALLE_COMPRAS where idCompra=@idCompra and idMaterial=@idMaterial
		if @existeMat = 0
		begin
			--inserta al detalle
			insert into TB_DETALLE_COMPRAS (idCompra,idMaterial,cantidad,precioTotal) values 
			(@idCompra,@idMaterial,@cantidad,@precio)
			--actualiza
			update TB_COMPRAS set montoTotal=@totalNuevo where idCompra=@idCompra
		end
		--si ya existe no hace nada
	end
end
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGA_DETALLE_ORDEN_PEDIDO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================
create procedure [dbo].[SP_AGREGA_DETALLE_ORDEN_PEDIDO]
(
@idOrdenPedido bigint,
@idMaterial int,
@cantidad int
)
as
declare
@idNegocio bigint,
@estadoAct int,
@estadoActOrdn int,
@existeMat int,
@totalMat int 
--valida estado
select * from  TB_ORDEN_PEDIDO
select @idNegocio=idNegocio,@estadoActOrdn=idEstadoOrdenPedido from TB_ORDEN_PEDIDO where idOrdenPedido=@idOrdenPedido
select @estadoAct=idEstado from TB_NEGOCIO where idNegocio=@idNegocio
if @estadoActOrdn=1 or @estadoActOrdn=2
begin
	if @estadoAct=2 or @estadoAct=3
	begin
		--exite
		select @existeMat=count(*) from TB_DETALLE_ORDEN_PEDIDO where idOrdenPedido=@idOrdenPedido and idMaterial=@idMaterial
		if @existeMat > 0
		begin
			--cantidad
			select @totalMat=cantidad from TB_DETALLE_ORDEN_PEDIDO where idOrdenPedido=@idOrdenPedido and idMaterial=@idMaterial
			--calcula
			set @totalMat=@totalMat+@cantidad;
			--update
			update TB_DETALLE_ORDEN_PEDIDO set cantidad=@totalMat,fechaRegistro=SYSDATETIME() 
			where idOrdenPedido=@idOrdenPedido and idMaterial=@idMaterial
		
		end
		else
		begin
			--insert
			insert into TB_DETALLE_ORDEN_PEDIDO (idOrdenPedido,idMaterial,cantidad,fechaRegistro) 
			values (@idOrdenPedido,@idMaterial,@cantidad,SYSDATETIME())
		end
	end
end	
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGA_ORDEN_PEDIDO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================

create procedure [dbo].[SP_AGREGA_ORDEN_PEDIDO]
(
@idNegocio int,
@idUsuario int,
@descripcion varchar(100)
)
as
declare
@estadoAct int
select @estadoAct=idEstado from TB_NEGOCIO where idNegocio=@idNegocio
if @estadoAct=2 or @estadoAct=3
insert into TB_ORDEN_PEDIDO (idNegocio,idSolicita,total,idEstadoOrdenPedido,fechaRegistro,descripcion)
values (@idNegocio,@idUsuario,0,1,SYSDATETIME(),@descripcion)
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGA_PERSONAL_NEGOCIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_AGREGA_PERSONAL_NEGOCIO] 
(
@idPersonal int,
@idNegocio bigint
)
as
declare
@estadoAct int,
@existePers int
select @estadoAct=idEstado from TB_NEGOCIO where idNegocio=@idNegocio
--validacion estado negocio
if @estadoAct=2 or @estadoAct=3
	--existe trabajador
	select @existePers=count(*) from TB_PERSONAL_NEGOCIO where idNegocio=@idNegocio and idPersonal=@idPersonal
	if @existePers = 0
	begin
		insert into TB_PERSONAL_NEGOCIO(idPersonal,idNegocio) values (@idPersonal,@idNegocio)
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGA_TIPO_NEGOCIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_AGREGA_TIPO_NEGOCIO]
(
@descripcion varchar(50),
@estado tinyint
)
as
insert into TB_TIPO_NEGOCIO (descripcion,estado) values (@descripcion,@estado)
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_COMPRA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_AGREGAR_COMPRA]
(
@idProveedor bigint,
@idUsuario int,
@descripcion varchar(50)
)
as
insert into TB_COMPRAS (idProveedor,fecha,usuarioCrea,idEstadoCompra,montoTotal,descripcion) values
(@idProveedor,SYSDATETIME(),@idUsuario,1,0,@descripcion)
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_CONCEPTO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_AGREGAR_CONCEPTO]
(
@descripcion varchar(50),
@estado tinyint
)
as
insert into TB_CONCEPTOS (descripcion,estado) values (@descripcion,@estado)
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_DETALLE_COMPROBANTE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_AGREGAR_DETALLE_COMPROBANTE]
(
@idComprobante bigint,
@idConcepto int,
@cantidad int,
@monto decimal(15,2)
)
as
declare 
@igv decimal(5,2),
@totalIgv decimal(15,2),
@subTotal decimal(15,2),
@total decimal (15,2),
@subtotalRegistrado decimal(15,2),
@igvRegistrado decimal(15,2),
@totalRegistrado decimal(15,2),
@finalSubtotal decimal(15,2),
@finalIgv decimal(15,2),
@finalTotal decimal(15,2),
@estadoAct int
set @igv=0.18
select @estadoAct=idEstadoComprobante from TB_COMPROBANTES where idComprobante=@idComprobante
if @estadoAct=1
begin
	--insertaDetalle
	insert into TB_DETALLE_COMPROBANTE (idComprobante,idConcepto,cantidad,monto,fechaRegistro) values
	(@idComprobante,@idConcepto,@cantidad,@monto,SYSDATETIME())

	--obtenInfo
	select @subtotalRegistrado=subTotal,@igvRegistrado=igv,@totalRegistrado=total from TB_COMPROBANTES where idComprobante=@idComprobante
	--calcula
	set @totalIgv=@monto * @igv
	set @total=@monto + @totalIgv
	--suma al registrado
	set @finalSubtotal=@subtotalRegistrado+@monto
	set @finalIgv=@igvRegistrado+@totalIgv
	set @finalTotal=@totalRegistrado+@total
	--actualizamos
	update TB_COMPROBANTES set subTotal=@finalSubtotal,igv=@finalIgv,total=@finalTotal where idComprobante=@idComprobante 
end
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_DETALLE_NOTA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_AGREGAR_DETALLE_NOTA] 
(
@idNota bigint,
@idMaterial int,
@cantidad int
)
as
declare
@estadoAct int,
@existeItem int=0,
@total int=0
select @estadoAct=idEstado from TB_NOTAS where idNota=@idNota
if @estadoAct=1
begin
	--existe item
	select @existeItem=count(*) from TB_DETALLE_NOTA where idNota=@idNota and idMaterial=@idMaterial
	if @existeItem=0
	begin
		--inserta
		insert into TB_DETALLE_NOTA(idNota,idMaterial,cantidad,fechaRegistro) values (@idNota,@idMaterial,@cantidad,SYSDATETIME())
	end
	else
	begin
		--update
		select @total=cantidad from TB_DETALLE_NOTA where idNota=@idNota and idMaterial=@idMaterial
		set @total=@total+@cantidad
		update TB_DETALLE_NOTA set cantidad=@total where idNota=@idNota and idMaterial=@idMaterial
	end
	
end
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_MODULO_ROLE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_AGREGAR_MODULO_ROLE]
(
@idModulo int,
@idRole int
)
as
insert into TB_MODULO_ROL (idRol,idModulo) values (@idRole,@idModulo)
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_NEGOCIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================
create procedure [dbo].[SP_AGREGAR_NEGOCIO] 
(
@nom varchar(80),
@idResponsable int,
@descripcion varchar(80),
@idtipo int,
@fechaInicio datetime,
@fechaFin datetime,
@idCliente int
)
as
insert into TB_NEGOCIO (nombre,idResponsable,descripcion,idTipoNegocio,fechaInicio,fechaFin,fechaRegistro,idEstado,idCliente)
values (@nom,@idResponsable,@descripcion,@idtipo,@fechaInicio,@fechaFin,SYSDATETIME(),1,@idCliente)
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_NOTA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_AGREGAR_NOTA]
(
@idTipoNota int,
@idAlmacen int,
@descripcion varchar(150),
@idUserSol int,
@numRef int
)
as
declare
@estadoNegocio int

if @idTipoNota=2
begin
	--negocio
	select @estadoNegocio=idEstado from TB_NEGOCIO where idNegocio=@numRef
	--validacion estado negocio
	if @estadoNegocio=2 or @estadoNegocio=3
	insert into TB_NOTAS 
	(idTipoNota,idAlmacen,descripcion,solicita,fechaSolicitud,idReferencia,idEstado)
	values 
	(@idTipoNota,@idAlmacen,@descripcion,@idUserSol,SYSDATETIME(),@numRef,1)
end
else
begin
	insert into TB_NOTAS 
	(idTipoNota,idAlmacen,descripcion,solicita,fechaSolicitud,idReferencia,idEstado)
	values 
	(@idTipoNota,@idAlmacen,@descripcion,@idUserSol,SYSDATETIME(),@numRef,1) 
end

GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_PROVEEDORES]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================

create procedure [dbo].[SP_AGREGAR_PROVEEDORES] 
(
@Nombres varchar(80),
@PrimerApellido varchar(50),
@SegundoApellido varchar(50),
@idTipoDocumento int,
@numeroDocumento varchar(15),
@Telefono varchar(15),
@Celular varchar(15),
@Direccion varchar(100),
@Mail varchar(80),
@estado tinyint
)
as
insert into TB_PROVEEDOR([nombre],[primerApellido],[segundoApellido],[idTipoDocumento],[numeroDocumento],[Telefono],[Celular],[Direccion],[Mail],[FechaRegistro],[Estado]) 
values (@Nombres,@PrimerApellido,@SegundoApellido,@idTipoDocumento,@numeroDocumento,@Telefono,@Celular,@Direccion,  @Mail,SYSDATETIME(),@estado)
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_ROLE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_AGREGAR_ROLE]
(
@descripcion varchar(150)
)
as
insert into TB_ROLES (Descripcion) values (@descripcion)
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_ROLES]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================
create procedure [dbo].[SP_AGREGAR_ROLES]
(
@descripcion varchar(150)
)
as
insert into TB_ROLES (descripcion) values (@descripcion)
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_TIPO_MATERIAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_AGREGAR_TIPO_MATERIAL]
(
@descripcion varchar(50),
@estado tinyint
)
as
insert into TB_TIPO_MATERIAL(descripcion,estado)values (@descripcion,@estado)
GO
/****** Object:  StoredProcedure [dbo].[SP_AGREGAR_TIPO_PERSONAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_AGREGAR_TIPO_PERSONAL]
(
@descripcion varchar(50),
@estado tinyint
)
as
insert into TB_TIPO_PERSONAL (descripcion,estado) values (@descripcion,@estado)
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCA_CLIENTE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================

create procedure [dbo].[SP_BUSCA_CLIENTE] 
(
@idCliente bigint
)
as
select cl.idCliente,cl.Nombres,cl.PrimerApellido,cl.SegundoApellido,
doc.idTipoDocumento as 'idTipoDocumento',
cl.numeroDocumento,cl.telefono,cl.direccion,cl.celular,cl.mail,
cl.idTipoCliente as 'tipo',CONVERT(VARCHAR,cl.fechaRegisto,121),
case
	when fechaModificacion is null then 'Sin Cambios'
	when fechaModificacion is not null then CONVERT(VARCHAR,fechaModificacion,121)
end as 'fecha modificacion',
cl.estado
from TB_CLIENTES cl
inner join TB_TIPO_DOCUMNETO doc on cl.idTipoDocumento=doc.idTipoDocumento
inner join TB_TIPO_CLIENTE tpo on cl.idTipoCliente = tpo.idTipoCliente
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCA_COMPRA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================
create procedure [dbo].[SP_BUSCA_COMPRA]
(
@idCompra bigint
)
as
select cmp.idCompra,cmp.idProveedor as 'proveedorId',prv.nombre as 'proveedorNombre',prv.primerApellido as 'proveedorPrimAp',
prv.segundoApellido as 'proveedorSegAp',CONVERT(varchar,cmp.fecha,121) as 'fecha',
cmp.usuarioCrea as 'idUsuario',us.nombres as 'usuario',cmp.montoTotal, cmp.idEstadoCompra as 'estadoId',est.descripcion as 'estadpDesc',
cmp.descripcion 
from TB_COMPRAS cmp
inner join TB_PROVEEDOR prv on prv.idProveedor=cmp.idProveedor
inner join TB_ESTADO_COMPRA est on est.idEstadoCompra=cmp.idEstadoCompra
inner join TB_USUARIOS us on cmp.usuarioCrea=us.idUsuario
where cmp.idCompra=@idCompra
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCA_COMPROBANTE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_BUSCA_COMPROBANTE]
(
@idComprobante bigint
)
as
select 
cmp.idComprobante,cmp.serie,cmp.numeroComprobante,cmp.idNegocio as 'idNegocio',ng.nombre as 'negocio',
cmp.idCliente as 'idCliente',cl.Nombres as 'clienteNombre', cl.PrimerApellido as 'clientePrimerAp', 
cl.SegundoApellido as 'clienteSegundoAp',cmp.idTipoComprobante as 'idTipo',tpo.descripcion as 'tipoComprobante',
CONVERT(varchar,cmp.fechaImpresion,121),
case
	when cmp.fechaPago is null then ''
	when cmp.fechaPago is not null then CONVERT(varchar,cmp.fechaPago,121) 
end
, 
cmp.descripcion,cmp.idEstadoComprobante as 'isEstado',est.descripcion as 'èstado',
cmp.subTotal,cmp.igv,cmp.total
from TB_COMPROBANTES cmp
inner join TB_NEGOCIO ng on cmp.idNegocio=ng.idNegocio
inner join TB_CLIENTES cl on cmp.idCliente=cl.idCliente
inner join TB_TIPO_COMPROBANTE tpo on cmp.idTipoComprobante= tpo.idTipoComprobante
inner join TB_ESTADO_COMPROBANTE est on cmp.idEstadoComprobante=est.idEstadoComprobante
where cmp.idComprobante=@idComprobante
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCA_MATERIAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_BUSCA_MATERIAL] 
(
@idMaterial bigint
)
as
select mt.idMaterial,mt.descripcion,mt.idTipoMaterial,mt.unidad,CONVERT(VARCHAR,mt.fechaRegistro,121) as 'fechaRegistro',
case
	when mt.fechaModificacion is null then 'Sin Cambios'
	when mt.fechaModificacion is not null then CONVERT(VARCHAR,mt.fechaModificacion,121)
end as 'fecha modificacion',
mt.estado
from TB_MATERIAL mt 
where mt.idMaterial=@idMaterial 
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCA_MODULOS]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_BUSCA_MODULOS]
(
@token varchar(50)
)
as
declare
@role int
--buscar rol usuario
select top 1 @role=us.idRol from TB_USUARIOS us WHERE us.token=@token

--imprime roles
select DISTINCT md.Titulo,md.controlador,md.Icono
from TB_MODULO_ROL mdRl 
inner join TB_MODULO md on md.idModulo=mdRl.idModulo
where mdRl.idRol=@role
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCA_NEGOCIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_BUSCA_NEGOCIO] 
(
@idNegocio bigint
)
as
select ng.idNegocio,ng.nombre, ng.idResponsable as 'idPersonal' ,prs.nombres as 'nomPersonal', 
prs.primerApellido as 'primerApPersonal',prs.segundoApellido as 'segundoApPersonal', 
ng.descripcion,ng.idTipoNegocio as 'idTipoNegocio',tpo.descripcion as 'tipoNEgocio',
CONVERT(varchar,ng.fechaInicio,121) as 'fechaInicio',
CONVERT(varchar,ng.fechaFin,121) as 'fechaFin',CONVERT(varchar,ng.fechaRegistro,121) as 'fechaRegistro',
ng.idEstado as 'idEstado',est.descripcion as 'estado',
case
	when ng.fechaModificacion is null then 'Sin Respuesta'
	when ng.fechaModificacion is not null then CONVERT(varchar,ng.fechaModificacion,121) 
end as 'fechaModificacion',
ng.idCliente as 'idCliente',
cl.Nombres as 'nombreCliente',cl.PrimerApellido as 'primerApCliente',cl.SegundoApellido as 'segundoApCliente'
from TB_NEGOCIO ng
inner join TB_PERSONAL prs on ng.idResponsable=prs.idPersonal
inner join TB_TIPO_NEGOCIO tpo on ng.idTipoNegocio=tpo.idTipoNegocio
inner join TB_ESTADO_NEGOCIO est on ng.idEstado=est.idEstadoNegocio
inner join TB_CLIENTES cl on ng.idCliente=cl.idCliente
where  ng.idNegocio=@idNegocio
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCA_ORDEN_PEDIDO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================

create procedure [dbo].[SP_BUSCA_ORDEN_PEDIDO]
(
@idOrdenPedido bigint
)
as
create table #TblFinal
(
idOrdenPedido bigint,
idNegocio bigint,
negocio varchar(80),
solicita varchar(80),
responde varchar(80),
total decimal(15,2),
idEstado int,
estado varchar(50),
fechaRegistro varchar(15),
fechaCambioEstado varchar(15),
detalle varchar(100),
descripcion varchar(100)
)
--nulos
insert into #TblFinal
select odPd.idOrdenPedido,odPd.idNegocio,ng.nombre,usSol.nombres,'Ninguno',odPd.total,odPd.idEstadoOrdenPedido,sto.descripcion,
CONVERT(varchar,odPd.fechaRegistro,121),'Sin respuesta','Sin respuesta',odPd.descripcion
from TB_ORDEN_PEDIDO odPd 
inner join TB_NEGOCIO ng on ng.idNegocio=odPD.idNegocio
inner join TB_USUARIOS usSol on odPd.idSolicita=usSol.idUsuario
inner join TB_ORDEN_PEDIDO_ESTADO sto on odPd.idEstadoOrdenPedido=sto.idEstadoOrdenPedido
where idResponde is null and idOrdenPedido=@idOrdenPedido
--no nulos
insert into #TblFinal
select odPd.idOrdenPedido,odPd.idNegocio,ng.nombre,usSol.nombres,usRes.nombres,odPd.total,odPd.idEstadoOrdenPedido,sto.descripcion,
CONVERT(varchar,odPd.fechaRegistro,121),CONVERT(varchar,odPd.fechaCambioEstado,121),
case
	when odPd.detalleRespuesta is null then 'Sin detalles'
	when odPd.detalleRespuesta is not null then odPd.detalleRespuesta
end
,
odPd.descripcion
from TB_ORDEN_PEDIDO odPd 
inner join TB_NEGOCIO ng on ng.idNegocio=odPD.idNegocio
inner join TB_USUARIOS usSol on odPd.idSolicita=usSol.idUsuario
inner join TB_USUARIOS usRes on odPd.idResponde=usRes.idUsuario
inner join TB_ORDEN_PEDIDO_ESTADO sto on odPd.idEstadoOrdenPedido=sto.idEstadoOrdenPedido
where idResponde is not null and idOrdenPedido=@idOrdenPedido
select * from #TblFinal
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCA_PERSONAL_NEGOCIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_BUSCA_PERSONAL_NEGOCIO] 
(
@idNegocio bigint
)
as
select prs.idPersonal,prs.nombres,prs.primerApellido,prs.segundoApellido, tpo.descripcion as 'Tipo'
from TB_PERSONAL_NEGOCIO ngPrs
inner join TB_PERSONAL prs on ngPrs.idPersonal=prs.idPersonal
inner join TB_TIPO_PERSONAL tpo on prs.idTipoPersonal = tpo.idTipoPersonal
where ngPrs.idNegocio=@idNegocio
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCA_TIPO_NEGOCIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_BUSCA_TIPO_NEGOCIO]
(
@idTipoNEgocio int
)
as
select idTipoNegocio,descripcion,estado,
case
	when estado=1 then 'Activo'
	when estado=0 then 'Inactivo'
end 
from TB_TIPO_NEGOCIO where idTipoNegocio=@idTipoNEgocio
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCA_TIPO_NOTA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_BUSCA_TIPO_NOTA]
(
@idNota bigint
)
as
select idTipoNota from TB_NOTAS where idNota=@idNota
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_ALMACEN]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_BUSCAR_ALMACEN] 
(
@idAlmacen int
)
as
select idAlmacen, Nombre, Direccion, Telefono, CONVERT(VARCHAR,fechaRegistro,121),
case
	when fechaModificacion is null then 'Sin Cambios'
	when fechaModificacion is not null then CONVERT(VARCHAR,fechaModificacion,121)
end as 'fecha modificacion'
,estado
from TB_ALMACENES
WHERE idAlmacen=@idAlmacen
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_CONCEPTO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_BUSCAR_CONCEPTO]
(
@idConcepto int
)
as
select idConcepto,descripcion,estado,
case
	when estado=1 then 'Activo'
	when estado=0 then 'Inactivo'
end 
from TB_CONCEPTOS where idConcepto=@idConcepto
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_NOTA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================

create procedure [dbo].[SP_BUSCAR_NOTA]
(
@idNota bigint
) 
as
CREATE TABLE #TblFinal 
(  
    idNota bigint,
	idalmacen int, --nuevo
	almacen varchar(80),
	descripcion varchar(100),
	userSolicita varchar(100),
	userResponde varchar(100),
	fechaSol varchar(20),
	fechaRes varchar(20),
	idReferencia bigint,
	idTipo int, --nuevo
	tipo varchar(50),
	idEstado int,
	estado varchar(50)
);
--nulos
insert into #TblFinal
select nts.idNota,nts.idAlmacen as 'idAlmacen',alm.nombre as 'nombreAlmacen',nts.descripcion,usr.nombres as 'solicita',
'Ninguno' as 'responde',CONVERT(varchar,nts.fechaSolicitud,121) as 'fechaSol',
'Ninguno' as 'fechaRespuesta',nts.idReferencia,nts.idTipoNota,tpo.descripcion as 'tipo',
nts.idEstado as 'idEstado',est.descripcion as 'estado' 
from TB_NOTAS nts
inner join TB_ALMACENES alm on nts.idAlmacen=alm.idAlmacen
inner join TB_USUARIOS usr on usr.idUsuario=nts.solicita
inner join TB_TIPO_NOTAS tpo on nts.idTipoNota=tpo.idTipoNota
inner join TB_ESTADO_NOTA est on nts.idEstado=est.idEstadoNota 
where responde is null and nts.idNota=@idNota
--no nulos
insert into #TblFinal
select nts.idNota,nts.idAlmacen as 'idAlmacen',alm.nombre as 'nombreAlmacen',nts.descripcion,usr.nombres as 'solicita',
usrRes.nombres as 'responde',CONVERT(varchar,nts.fechaSolicitud,121) as 'fechaSol',
CONVERT(varchar,nts.fechaRespuesta,121) as 'fechaRespuesta',nts.idReferencia,nts.idTipoNota,tpo.descripcion as 'tipo',
nts.idEstado as 'idEstado',est.descripcion as 'estado' 
from TB_NOTAS nts
inner join TB_ALMACENES alm on nts.idAlmacen=alm.idAlmacen
inner join TB_USUARIOS usr on usr.idUsuario=nts.solicita
inner join TB_USUARIOS usrRes on usrRes.idUsuario=nts.responde
inner join TB_TIPO_NOTAS tpo on nts.idTipoNota=tpo.idTipoNota
inner join TB_ESTADO_NOTA est on nts.idEstado=est.idEstadoNota 
where responde is not null and nts.idNota=@idNota
select * from #TblFinal
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_PERSONAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================

create procedure [dbo].[SP_BUSCAR_PERSONAL]
(
@idPersonal int
)
as
select prs.idPersonal,prs.nombres,prs.primerApellido,
prs.segundoApellido,prs.numeroDocumento,prs.telefono,
prs.direccion,prs.mail,prs.idTipoPersonal,prs.estado,prs.idTipoDocumento
from TB_PERSONAL prs
where prs.idPersonal=@idPersonal
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_PROVEEDOR]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_BUSCAR_PROVEEDOR] 
(
@idProveedor bigint
)
as
select prv.idProveedor,prv.nombre,prv.primerApellido,prv.segundoApellido,prv.idTipoDocumento,
prv.numeroDocumento,prv.telefono,
prv.celular,prv.direccion,prv.mail,CONVERT(varchar,prv.fechaRegistro) as 'fechaRegistro',
case
	when prv.fechaModificacion is null then 'Sin Cambios'
	when prv.fechaModificacion is not null then CONVERT(VARCHAR,prv.fechaModificacion,121)
end as 'fecha modificacion' 
,
prv.estado
from TB_PROVEEDOR prv 
where idProveedor=@idProveedor
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_ROLE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_BUSCAR_ROLE]
(
@idRole int
)
as
select * from TB_ROLES where idRol=@idRole
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_TIPO_MATERIAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_BUSCAR_TIPO_MATERIAL]
(
@idTipoMaterial int
)
as
select idTipoMaterial,descripcion,estado, 
case
	when estado=1 then 'Activo'
	when estado=0 then 'Inactivo'
end
from TB_TIPO_MATERIAL where idTipoMaterial=@idTipoMaterial
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_TIPO_PERSONAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_BUSCAR_TIPO_PERSONAL]
(
@idTipoPersonal int
)
as
select idTipoPersonal,descripcion,estado,
case
	when estado=1 then 'Activo'
	when estado=0 then 'Inactivo'
end 
from TB_TIPO_PERSONAL where idTipoPersonal=@idTipoPersonal
GO
/****** Object:  StoredProcedure [dbo].[SP_BUSCAR_USUARIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_BUSCAR_USUARIO]
(
@idUsuario bigint
)
as
select us.idUsuario,us.Nombres,rl.Descripcion,us.Token,us.Mail,us.idRol,us.estado 
from TB_USUARIOS us inner join TB_ROLES rl on us.idRol=rl.idRol
where us.idUsuario=@idUsuario
GO
/****** Object:  StoredProcedure [dbo].[SP_CONFIGURACION]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================




create procedure [dbo].[SP_CONFIGURACION]
as
select nombre,nombreNegocio,color,colorTexto from TB_CONFIGURACION_GENERAL
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINA_DETALLE_COMPRA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================
create procedure [dbo].[SP_ELIMINA_DETALLE_COMPRA]
(
@idDetalleCompra bigint
)
as
declare
@idCompra bigint,
@precioCompra decimal(15,2),
@totalCompra decimal(15,2),
@totalNuevo decimal(15,2),
@estadoAct int
--estado actual
select @idCompra=idCompra from TB_DETALLE_COMPRAS where idCompraDetalle=@idDetalleCompra
select @estadoAct=idEstadoCompra from TB_COMPRAS where idCompra=@idCompra
if @estadoAct=1
begin
	select @totalCompra=montoTotal from TB_COMPRAS where idCompra=@idCompra
	select @precioCompra=precioTotal from TB_DETALLE_COMPRAS WHERE idCompraDetalle=@idDetalleCompra
	--calcular
	set @totalNuevo=@totalCompra-@precioCompra
	--actualiza
	delete from TB_DETALLE_COMPRAS where idCompraDetalle=@idDetalleCompra
	update TB_COMPRAS set montoTotal=@totalNuevo where idCompra=@idCompra
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINA_DETALLE_COMPROBANTE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================
create procedure [dbo].[SP_ELIMINA_DETALLE_COMPROBANTE]
(
@idDetalleComprobante bigint
)
as
declare
@idComprobante bigint,
@subTotal decimal(15,2),
@subtotalRegistrado decimal(15,2),
@finalSubtotal decimal(15,2),
@finalIgv decimal(15,2),
@finalTotal decimal(15,2),
@estadoAct int
select @estadoAct=idEstadoComprobante from TB_COMPROBANTES where idComprobante=@idComprobante
if @estadoAct=1
begin
	--obtener info
	select @subTotal=monto,@idComprobante=idComprobante from  TB_DETALLE_COMPROBANTE where idDetalleComprobante=@idDetalleComprobante
	select @subtotalRegistrado=subTotal from TB_COMPROBANTES where idComprobante=@idComprobante
	--calcula
	set @finalSubtotal=@subtotalRegistrado-@subTotal
	set @finalIgv=@finalSubtotal*0.18
	set @finalTotal=@finalSubtotal+@finalIgv
	--actualizamos
	update TB_COMPROBANTES set subTotal=@finalSubtotal,igv=@finalIgv,total=@finalTotal where idComprobante=@idComprobante
	--elimina
	delete from TB_DETALLE_COMPROBANTE where idDetalleComprobante=@idDetalleComprobante
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINA_DETALLE_NOTA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_ELIMINA_DETALLE_NOTA] 
(
@idDetalleNota bigint
)
as
declare
@estadoAct int,
@idNota bigint
select @idNota=idNota from TB_DETALLE_NOTA where idDetalleNota=@idDetalleNota
select @estadoAct=idEstado from TB_NOTAS
if @estadoAct=1
delete from TB_DETALLE_NOTA where idDetalleNota=@idDetalleNota
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINA_DETALLE_ORDEN_PEDIDO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_ELIMINA_DETALLE_ORDEN_PEDIDO]
(
@idDetalleOrdenPedido bigint
)
as
declare
@idNegocio bigint,
@idOrdenPedido bigint,
@estadoAct int
select @idOrdenPedido=idOrdenPedido from TB_DETALLE_ORDEN_PEDIDO WHERE idDetalleOrdenPedido=@idDetalleOrdenPedido
select @idNegocio=idNegocio from TB_ORDEN_PEDIDO where idOrdenPedido=@idOrdenPedido
select @estadoAct=idEstado from TB_NEGOCIO where idNegocio=@idNegocio
if @estadoAct=2 or @estadoAct=3
delete from TB_DETALLE_ORDEN_PEDIDO WHERE idDetalleOrdenPedido=@idDetalleOrdenPedido
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINA_MODULO_ROLE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_ELIMINA_MODULO_ROLE]
(
@idModulo int,
@idRole int
)
as
delete from TB_MODULO_ROL where idModulo=@idModulo and idRol=@idRole
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINA_PERSONAL_NEGOCIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--=============================================================================================
create procedure [dbo].[SP_ELIMINA_PERSONAL_NEGOCIO] 
(
@idPersonal int,
@idNegocio bigint
)
as
declare
@estadoAct int
select @estadoAct=idEstado from TB_NEGOCIO where idNegocio=@idNegocio
if @estadoAct=2 or @estadoAct=3
delete from TB_PERSONAL_NEGOCIO where idPersonal=@idPersonal and idNegocio=@idNegocio
GO
/****** Object:  StoredProcedure [dbo].[SP_ELIMINA_ROLE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_ELIMINA_ROLE]
(
@idRole int
)
as
--delete moduloRole
delete from  TB_MODULO_ROL where idRol=@idRole 
--delete role
delete from TB_ROLES where idRol=@idRole
GO
/****** Object:  StoredProcedure [dbo].[SP_INSERTAR_ALMACEN]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
CREATE PROCEDURE [dbo].[SP_INSERTAR_ALMACEN] 
(
  @Nombre varchar(80),
  @Direccion varchar(100),
  @Telefono varchar(15),
  @estado tinyint
)
AS
insert into TB_ALMACENES([nombre], [direccion], [telefono],[fechaRegistro],[estado]) values (@Nombre,@Direccion,@Telefono,SYSDATETIME(),@estado)
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_COMPRAS_SELECT]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTA_COMPRAS_SELECT]
as
select idCompra,descripcion from TB_COMPRAS  where idEstadoCompra=2
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_DETALLE_COMPROBANTE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_LISTA_DETALLE_COMPROBANTE]
(
@idComprobante bigint
)
as
select dtll.idDetalleComprobante,cpt.descripcion as 'concepto',dtll.cantidad,dtll.monto,
convert(varchar,dtll.fechaRegistro,121)
from TB_DETALLE_COMPROBANTE dtll
inner join TB_CONCEPTOS cpt on dtll.idConcepto=cpt.idConcepto
where idComprobante= @idComprobante
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_DETALLE_ORDEN_PEDIDO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================
create procedure [dbo].[SP_LISTA_DETALLE_ORDEN_PEDIDO]
(
@idOrdenPedido bigint
)
as
select dtll.idDetalleOrdenPedido,mt.descripcion,dtll.cantidad from TB_DETALLE_ORDEN_PEDIDO dtll
inner join TB_MATERIAL mt on dtll.idMaterial=mt.idMaterial 
where dtll.idOrdenPedido= @idOrdenPedido
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_ESTADO_COMPROBANTE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTA_ESTADO_COMPROBANTE]
as
select idEstadoComprobante,descripcion from TB_ESTADO_COMPROBANTE
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_ESTADO_NOTA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTA_ESTADO_NOTA]
as
select idEstadoNota,descripcion from TB_ESTADO_NOTA
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_ESTADO_ORDEN_PEDIDO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================
create procedure [dbo].[SP_LISTA_ESTADO_ORDEN_PEDIDO]
as
select idEstadoOrdenPedido,descripcion from TB_ORDEN_PEDIDO_ESTADO
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_MATERIAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTA_MATERIAL] 
as
select mt.idMaterial,mt.descripcion,tpo.descripcion as 'tipo',mt.unidad,
CONVERT(VARCHAR,mt.fechaRegistro,121) as 'fechaRegistro',
case
	when mt.fechaModificacion is null then 'Sin Cambios'
	when mt.fechaModificacion is not null then CONVERT(VARCHAR,mt.fechaModificacion,121)
end as 'fecha modificacion',
case
	when mt.estado=0 then 'Inactivo'
	when mt.estado=1 then 'Activo'
end as 'estado'  
from TB_MATERIAL mt 
inner join TB_TIPO_MATERIAL tpo on mt.idTipoMaterial=tpo.idTipoMaterial
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_NEGOCIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTA_NEGOCIO] 
as
select ng.idNegocio,ng.nombre, prs.nombres as 'nomPersonal', prs.primerApellido as 'primerApPersonal',
prs.segundoApellido as 'segundoApPersonal', ng.descripcion,tpo.descripcion as 'tipoNEgocio',
CONVERT(varchar,ng.fechaInicio,121) as 'fechaInicio',
CONVERT(varchar,ng.fechaFin,121) as 'fechaFin',CONVERT(varchar,ng.fechaRegistro,121) as 'fechaRegistro',
est.descripcion as 'estado',
case
	when ng.fechaModificacion is null then 'Sin Respuesta'
	when ng.fechaModificacion is not null then CONVERT(varchar,ng.fechaModificacion,121) 
end as 'fechaModificacion',
cl.Nombres as 'nombreCliente',cl.PrimerApellido as 'primerApCliente',cl.SegundoApellido as 'segundoApCliente'
from TB_NEGOCIO ng
inner join TB_PERSONAL prs on ng.idResponsable=prs.idPersonal
inner join TB_TIPO_NEGOCIO tpo on ng.idTipoNegocio=tpo.idTipoNegocio
inner join TB_ESTADO_NEGOCIO est on ng.idEstado=est.idEstadoNegocio
inner join TB_CLIENTES cl on ng.idCliente=cl.idCliente
order by ng.idNegocio DESC 
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_NEGOCIOS_SELECT]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTA_NEGOCIOS_SELECT]
as
select idNegocio,nombre from TB_NEGOCIO where idEstado=2 or idEstado=3
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_NOTAS_SALIDAS_SELECT]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTA_NOTAS_SALIDAS_SELECT]
as
select idNota,descripcion from TB_NOTAS where idEstado=3 and idTipoNota=2
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_ORDEN_PEDIDO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================
create procedure [dbo].[SP_LISTA_ORDEN_PEDIDO]
as
create table #TblFinal
(
idOrdenPedido bigint,
negocio varchar(80),
solicita varchar(80),
responde varchar(80),
total decimal(15,2),
estado varchar(50),
fechaRegistro varchar(15),
fechaCambioEstado varchar(15),
detalle varchar(100),
descripcion varchar(100)
)
--nulos
insert into #TblFinal
select odPd.idOrdenPedido,ng.nombre,usSol.nombres,'Ninguno',odPd.total,sto.descripcion,
CONVERT(varchar,odPd.fechaRegistro,121),'Sin respuesta','Sin respuesta',odPd.descripcion
from TB_ORDEN_PEDIDO odPd 
inner join TB_NEGOCIO ng on ng.idNegocio=odPD.idNegocio
inner join TB_USUARIOS usSol on odPd.idSolicita=usSol.idUsuario
inner join TB_ORDEN_PEDIDO_ESTADO sto on odPd.idEstadoOrdenPedido=sto.idEstadoOrdenPedido
where idResponde is null
--no nulos
insert into #TblFinal
select odPd.idOrdenPedido,ng.nombre,usSol.nombres,usRes.nombres,odPd.total,sto.descripcion,
CONVERT(varchar,odPd.fechaRegistro,121),CONVERT(varchar,odPd.fechaCambioEstado,121),
case
	when odPd.detalleRespuesta is null then 'Sin detalles'
	when odPd.detalleRespuesta is not null then odPd.detalleRespuesta
end,
odPd.descripcion
from TB_ORDEN_PEDIDO odPd 
inner join TB_NEGOCIO ng on ng.idNegocio=odPD.idNegocio
inner join TB_USUARIOS usSol on odPd.idSolicita=usSol.idUsuario
inner join TB_USUARIOS usRes on odPd.idResponde=usRes.idUsuario
inner join TB_ORDEN_PEDIDO_ESTADO sto on odPd.idEstadoOrdenPedido=sto.idEstadoOrdenPedido
where idResponde is not null
select * from #TblFinal order by idOrdenPedido desc
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_ROLES]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTA_ROLES]
as
select idRol,descripcion from TB_ROLES
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_TIPO_COMPROBANTE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--=============================================================================================
create procedure [dbo].[SP_LISTA_TIPO_COMPROBANTE]
as
select idTipoComprobante,descripcion from TB_TIPO_COMPROBANTE
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_TIPO_DOCUMENTO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--============================================================================================= X_x

create procedure [dbo].[SP_LISTA_TIPO_DOCUMENTO] 
as
select idTipoDocumento,descripcion from TB_TIPO_DOCUMNETO
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_TIPO_MATERIAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTA_TIPO_MATERIAL] 
as
select idTipoMaterial,descripcion from TB_TIPO_MATERIAL where estado=1
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_TIPO_MATERIAL_TOTAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTA_TIPO_MATERIAL_TOTAL]
as
select idTipoMaterial,descripcion,estado, 
case
	when estado=1 then 'Activo'
	when estado=0 then 'Inactivo'
end
from TB_TIPO_MATERIAL
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_TIPO_NEGOCIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--============================================================================================= 
create procedure [dbo].[SP_LISTA_TIPO_NEGOCIO] 
as
select idTipoNegocio,descripcion from TB_TIPO_NEGOCIO where estado=1
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_TIPO_NEGOCIO_TOTAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTA_TIPO_NEGOCIO_TOTAL]
as
select idTipoNegocio,descripcion,estado,
case
	when estado=1 then 'Activo'
	when estado=0 then 'Inactivo'
end 
from TB_TIPO_NEGOCIO
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTA_TOTAL_CONCEPTOS]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTA_TOTAL_CONCEPTOS]
as
select idConcepto,descripcion,estado,
case
	when estado=1 then 'Activo'
	when estado=0 then 'Inactivo'
end 
from TB_CONCEPTOS
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_ALMACEN]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--=============================================================================================
create procedure [dbo].[SP_LISTAR_ALMACEN] 
as 
select idAlmacen, Nombre, Direccion, Telefono, CONVERT(VARCHAR,fechaRegistro,121),
case
	when fechaModificacion is null then 'Sin Cambios'
	when fechaModificacion is not null then CONVERT(VARCHAR,fechaModificacion,121)
end as 'fecha modificacion',
case
	when estado=0 then 'Inactivo'
	when estado=1 then 'Activo'
end as 'estado' 
from TB_ALMACENES
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_CLIENTE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================

create procedure [dbo].[SP_LISTAR_CLIENTE] 
as
select cl.idCliente,cl.Nombres,cl.PrimerApellido,cl.SegundoApellido,doc.descripcion as 'Documento',cl.numeroDocumento,
cl.telefono,cl.direccion,cl.celular,cl.mail,tpo.descripcion as 'tipo',
CONVERT(VARCHAR,cl.fechaRegisto,121),
case
	when fechaModificacion is null then 'Sin Cambios'
	when fechaModificacion is not null then CONVERT(VARCHAR,fechaModificacion,121)
end as 'fecha modificacion',
case
	when cl.estado=0 then 'Inactivo'
	when cl.estado=1 then 'Activo'
end as 'estado' 
from TB_CLIENTES cl
inner join TB_TIPO_DOCUMNETO doc on cl.idTipoDocumento=doc.idTipoDocumento
inner join TB_TIPO_CLIENTE tpo on cl.idTipoCliente = tpo.idTipoCliente
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_COMPRAS]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTAR_COMPRAS]
as
select cmp.idCompra,prv.nombre as 'proveedorNombre',prv.primerApellido as 'proveedorPrimAp',
prv.segundoApellido as 'proveedorSegAp',CONVERT(varchar,cmp.fecha,121) as 'fecha',
us.nombres as 'usuario',cmp.montoTotal,est.descripcion as 'estado',cmp.descripcion
from TB_COMPRAS cmp
inner join TB_PROVEEDOR prv on prv.idProveedor=cmp.idProveedor
inner join TB_ESTADO_COMPRA est on est.idEstadoCompra=cmp.idEstadoCompra
inner join TB_USUARIOS us on cmp.usuarioCrea=us.idUsuario
order by idCompra desc
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_COMPROBANTE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTAR_COMPROBANTE]
as
select 
cmp.idComprobante,cmp.serie,cmp.numeroComprobante,ng.nombre as 'negocio',cl.Nombres as 'clienteNombre', 
cl.PrimerApellido as 'clientePrimerAp', cl.SegundoApellido as 'clienteSegundoAp',tpo.descripcion as 'tipoComprobante',
CONVERT(varchar,cmp.fechaImpresion,121) as 'fechaImpresion',
case
	when cmp.fechaPago is null then 'Sin fecha de pago'
	when cmp.fechaPago is not null then CONVERT(varchar,cmp.fechaPago,121)
end as 'fechaPago'
,
cmp.descripcion,est.descripcion as 'èstado',cmp.subTotal,cmp.igv,cmp.total
from TB_COMPROBANTES cmp
inner join TB_NEGOCIO ng on cmp.idNegocio=ng.idNegocio
inner join TB_CLIENTES cl on cmp.idCliente=cl.idCliente
inner join TB_TIPO_COMPROBANTE tpo on cmp.idTipoComprobante= tpo.idTipoComprobante
inner join TB_ESTADO_COMPROBANTE est on cmp.idEstadoComprobante=est.idEstadoComprobante
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_CONCEPTOS]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTAR_CONCEPTOS]
as
select idConcepto,descripcion from TB_CONCEPTOS where estado=1
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_DETALLE_COMPRA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTAR_DETALLE_COMPRA]
(
@idCompra bigint
)
as
select dtll.idCompraDetalle,mt.descripcion as 'material',dtll.cantidad,dtll.precioTotal 
from TB_DETALLE_COMPRAS dtll
inner join TB_MATERIAL mt on mt.idMaterial=dtll.idMaterial
where dtll.idCompra=@idCompra
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_DETALLE_NOTA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTAR_DETALLE_NOTA] 
(
@idNota bigint
)
as
select dtll.idDetalleNota,dtll.idNota,dtll.idMaterial as 'idMaterial',
mt.Descripcion as 'Material',dtll.Cantidad,CONVERT(varchar,dtll.fechaRegistro,121) as 'fechaRegistro'
from TB_DETALLE_NOTA dtll
inner join TB_MATERIAL mt on mt.idMaterial = dtll.idMaterial
where dtll.idNota=@idNota
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_ESTADO_COMPRA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTAR_ESTADO_COMPRA]
as
select idEstadoCompra,descripcion from TB_ESTADO_COMPRA
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_ESTADO_NEGOCIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================

create procedure [dbo].[SP_LISTAR_ESTADO_NEGOCIO]
as
select idEstadoNegocio,descripcion from TB_ESTADO_NEGOCIO
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_KARDEX]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure  [dbo].[SP_LISTAR_KARDEX]
as
select mt.descripcion,CONVERT(varchar,kr.fechaModificacion,121),kr.totalPedidos,kr.totalCompras,kr.total from TB_kARDEX kr
inner join TB_MATERIAL mt on mt.idMaterial=kr.idMaterial
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_MODULOS]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTAR_MODULOS]
as
select idModulo,Controlador,Titulo,Descripcion from TB_MODULO
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_MODULOS_ROLE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTAR_MODULOS_ROLE]
(
@idRole int
)
as
select mdrl.idModulo,md.Controlador,md.titulo,md.Descripcion
from TB_MODULO_ROL mdrl
inner join TB_MODULO md on mdrl.idModulo=md.idModulo
where idRol=@idRole
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_NOTA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTAR_NOTA] 
as
CREATE TABLE #TblFinal 
(  
    idNota bigint,
	almacen varchar(80),
	descripcion varchar(100),
	userSolicita varchar(100),
	userResponde varchar(100),
	fechaSol varchar(20),
	fechaRes varchar(20),
	idReferencia bigint,
	tipo varchar(50),
	estado varchar(50)
);
--nulos
insert into #TblFinal
select nts.idNota,alm.nombre,nts.descripcion,usr.nombres,'Ninguno',CONVERT(varchar,nts.fechaSolicitud,121),
'Ninguno',nts.idReferencia,tpo.descripcion,est.descripcion 
from TB_NOTAS nts
inner join TB_ALMACENES alm on nts.idAlmacen=alm.idAlmacen
inner join TB_USUARIOS usr on usr.idUsuario=nts.solicita
inner join TB_TIPO_NOTAS tpo on nts.idTipoNota=tpo.idTipoNota
inner join TB_ESTADO_NOTA est on nts.idEstado=est.idEstadoNota 
where responde is null
--no nulos
insert into #TblFinal
select nts.idNota,alm.nombre,nts.descripcion,usr.nombres,usrRes.nombres,CONVERT(varchar,nts.fechaSolicitud,121),
CONVERT(varchar,nts.fechaRespuesta,121),nts.idReferencia,tpo.descripcion,est.descripcion 
from TB_NOTAS nts
inner join TB_ALMACENES alm on nts.idAlmacen=alm.idAlmacen
inner join TB_USUARIOS usr on usr.idUsuario=nts.solicita
inner join TB_USUARIOS usrRes on usrRes.idUsuario=nts.responde
inner join TB_TIPO_NOTAS tpo on nts.idTipoNota=tpo.idTipoNota
inner join TB_ESTADO_NOTA est on nts.idEstado=est.idEstadoNota 
where responde is not null
select * from #TblFinal
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_NOTA_SALIDA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================

create procedure [dbo].[SP_LISTAR_NOTA_SALIDA] 
as
select nts.idNota,nts.descripcion,usSol.nombres,al.nombre from TB_NOTAS nts
inner join TB_USUARIOS usSol on nts.solicita=usSol.idUsuario
inner join TB_ALMACENES al on al.idAlmacen=nts.idAlmacen where nts.idTipoNota=2
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_PROVEEDORES]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTAR_PROVEEDORES] 
as
select prv.idProveedor,prv.nombre,prv.primerApellido,prv.segundoApellido,tpoDoc.descripcion,prv.numeroDocumento,prv.telefono,prv.celular,
prv.direccion,prv.mail,CONVERT(varchar,prv.fechaRegistro,121),
case
	when prv.fechaModificacion is null then 'Sin Cambios'
	when prv.fechaModificacion is not null then CONVERT(VARCHAR,prv.fechaModificacion,121)
end as 'fecha modificacion',
case
	when estado=0 then 'Inactivo'
	when estado=1 then 'Activo'
end as 'estado' 
 from TB_PROVEEDOR prv
 inner join TB_TIPO_DOCUMNETO tpoDoc on tpoDoc.idTipoDocumento=prv.idTipoDocumento
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_TIPO_CLIENTE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================

create procedure [dbo].[SP_LISTAR_TIPO_CLIENTE] 
as
select idTipoCliente,descripcion from TB_TIPO_CLIENTE 
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_TIPO_NOTA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTAR_TIPO_NOTA] 
as
select idTipoNota,descripcion from TB_TIPO_NOTAS
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_TIPO_PERSONAL_TOTAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTAR_TIPO_PERSONAL_TOTAL]
as
select idTipoPersonal,descripcion,estado,
case
	when estado=1 then 'Activo'
	when estado=0 then 'Inactivo'
end 
from TB_TIPO_PERSONAL
GO
/****** Object:  StoredProcedure [dbo].[SP_LISTAR_USUARIOS]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_LISTAR_USUARIOS]
as
select 
us.idUsuario,
us.Nombres,
us.Mail,
rl.Descripcion as 'role',
us.idRol as 'idRole',
us.Token,
case
	when us.estado=0 then 'Inactivo'
	when us.estado=1 then 'Activo'
end as 'estado' 
from TB_USUARIOS us
inner join TB_ROLES rl on rl.idRol=us.idRol   
GO
/****** Object:  StoredProcedure [dbo].[SP_REGISTRA_CLIENTE]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=============================================================================================

create procedure [dbo].[SP_REGISTRA_CLIENTE] 
(
@nom varchar(80),
@priAp varchar(80),
@segAp varchar(80),
@tpodoc int,
@nrodoc varchar(15),
@telef varchar(15),
@direccion varchar(100),
@celular varchar(15),
@mail varchar(80),
@tipo int,
@estado tinyint
)
as
insert into TB_CLIENTES(Nombres,PrimerApellido,SegundoApellido,idTipoDocumento,numeroDocumento,telefono,direccion,celular,mail,idTipoCliente,fechaRegisto,estado)
values (@nom,@priAp,@segAp,@tpodoc,@nrodoc,@telef,@direccion,@celular,@mail,@tipo,SYSDATETIME(),@estado)
GO
/****** Object:  StoredProcedure [dbo].[SP_REGISTRA_ERROR]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_REGISTRA_ERROR]
(
@error text,
@ruta varchar(100)
)
as
insert into TB_ERROR_LOG(error,proceso,fecha) values (@error,@ruta,SYSDATETIME())
GO
/****** Object:  StoredProcedure [dbo].[SP_REGISTRA_USUARIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_REGISTRA_USUARIO]
(
@nombre varchar(100),
@mail varchar(80),
@token varchar(80)
)
as
insert into TB_USUARIOS(nombres,mail,idRol,token,estado) VALUES (@nombre,@mail,1,@token,1)
GO
/****** Object:  StoredProcedure [dbo].[SP_REGISTRAR_MATERIAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_REGISTRAR_MATERIAL] 
(
@descripcion varchar(80),
@tipo int,
@unidad varchar(15),
@estado tinyint
)
as
declare
@idMaterial int
insert into TB_MATERIAL(descripcion,idTipoMaterial,estado,unidad,fechaRegistro) VALUES
(@descripcion,@tipo,@estado,@unidad,SYSDATETIME())

select @idMaterial=idMaterial from TB_MATERIAL where descripcion=@descripcion and idTipoMaterial=@tipo
insert into TB_KARDEX (idMaterial,fechaModificacion) values (@idMaterial,SYSDATETIME())
GO
/****** Object:  StoredProcedure [dbo].[SP_REGISTRAR_PERSONAL]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================

create procedure [dbo].[SP_REGISTRAR_PERSONAL]
(
@nom varchar(80),
@priAp varchar(80),
@segAp varchar(80),
@tipoDoc int,
@doc varchar(15),
@telef varchar(15),
@direccion varchar(100),
@mail varchar(80),
@tipo int,
@estado tinyint
)
as
insert into TB_PERSONAL 
(nombres,primerApellido,segundoApellido,idTipoDocumento,numeroDocumento,telefono,
direccion,mail,fechaRegistro,idTipoPersonal,estado) VALUES
(@nom,@priAp,@segAp,@tipoDoc,@doc,@telef,@direccion,@mail,SYSDATETIME(),@tipo,1)
GO
/****** Object:  StoredProcedure [dbo].[SP_RESPONDE_COMPRA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
--exec SP_RESPONDE_COMPRA 1,2
create procedure [dbo].[SP_RESPONDE_COMPRA]
(
@idCompra bigint,
@idEstado int
)
as
declare 
@cicloTotal int=0,
@totalMaterial int=0,
@i int =1,
@encuentraMaterial int,
@idMaterialCiclo int,
@totalMatKardex int,
@estadoActual int
--validacion estado
select @estadoActual=idEstadoCompra from TB_COMPRAS
if @estadoActual=1 
begin
	if @idEstado=2
	begin
		--calculo update
		--actualiza kardex totalCompras++
		create table #items (
		idt int identity(1,1),
		idMaterial int,
		cantidad int
		)
		insert into #items (idMaterial,cantidad)
		select idMaterial,cantidad from TB_DETALLE_COMPRAS where idCompra=@idCompra;
		--totalCiclo
		select @cicloTotal=count(*) from #items
		print('total ciclo'+convert(varchar,@cicloTotal,121))
		--inicia ciclo
		while @i <= @cicloTotal
		begin
			--datos
			select @idMaterialCiclo=idMaterial,@totalMaterial=cantidad from #items where idt=@i
			print('material:'+convert(varchar,@idMaterialCiclo,121))
			--busca material en kardex
			select @encuentraMaterial=count(*) from TB_kARDEX where idMaterial=@idMaterialCiclo
			print('se encuentra en kardex:'+convert(varchar,@encuentraMaterial,121))
			if @encuentraMaterial > 0
			begin
				--update kardex
				 print('update')
				 select @totalMatKardex=totalCompras from TB_kARDEX where idMaterial=@idMaterialCiclo
				 set @totalMaterial=@totalMaterial+@totalMatKardex;
				 print('totalMaterial:'+convert(varchar,@totalMaterial,121))
				 update TB_kARDEX set totalCompras=@totalMaterial, fechaModificacion=SYSDATETIME() where idMaterial=@idMaterialCiclo
			end
			else
			begin
				--insert kardex
				print('insert')
				insert into TB_kARDEX (idMaterial,fechaModificacion,totalCompras) values
				(@idMaterialCiclo,SYSDATETIME(),@totalMaterial)
			end
			--incrementa ciclo
			print('cliclo:'+convert(varchar,@i,121))
			set @i=@i+1
		end
		drop table #items
		update TB_COMPRAS set idEstadoCompra=@idEstado where idCompra=@idCompra
	end
	else if @idEstado=3
	begin
		--update
		update TB_COMPRAS set idEstadoCompra=@idEstado where idCompra=@idCompra
	end
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RESPONDE_NOTA]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_RESPONDE_NOTA]
(
@idNota bigint,
@idEstado int,
@idUser int
)
as
--variables
declare
@estadoAct int,
@tipo int,
@totalItem int,
@count int = 1,
@material int,
@cantidad int,
@exist int,
@totalMataerial int,
@result int,
@trans int = 1,
@compras int,
@pedidos int
--valida estado
select @estadoAct=idEstado from TB_NOTAS where idNota=@idNota
if @estadoAct=1 or @estadoAct=2
begin
	--tablaDetalle (materiales)
	create table #items 
	(
	idt INT IDENTITY(1, 1),
	idMat int,
	cant int
	)
	--cargaDetalle
	insert into #items (idMat,cant)
	select idMaterial,cantidad from TB_DETALLE_NOTA where idNota=@idNota
	--logica de inserta o elimina
	--tipo nota
	select @tipo=idTipoNota from TB_NOTAS where idNota=@idNota
	--ciclo
	select @totalItem=count(*) from #items
	WHILE @count <= @totalItem
	BEGIN
		--valores 
		select @material=idMat,@cantidad=cant from #items where idt=@count

		IF @tipo = 1
		begin
			--ingreso
			--update
				select @totalMataerial=total,@compras=totalCompras from TB_kARDEX where idMaterial=@material
				set @result = @totalMataerial + @cantidad
				set @compras = @compras-@cantidad
				update TB_kARDEX set total=@result,totalCompras=@compras,fechaModificacion=SYSDATETIME() where idMaterial=@material
		end
		ELSE IF @tipo = 2
		begin
			--salida
			-- 'resta'
			select @totalMataerial=Total,@pedidos=totalPedidos from TB_kARDEX where idMaterial=@material
			set @result=@totalMataerial - @cantidad --result
			set @pedidos=@pedidos - @cantidad
			update TB_kARDEX set Total=@result,totalPedidos=@pedidos,fechaModificacion=SYSDATETIME() where idMaterial=@material

		end
		ELSE IF @tipo = 3
		begin
			--retorno
			--update
				select @totalMataerial=total from TB_kARDEX where idMaterial=@material
				set @result = @totalMataerial + @cantidad
				update TB_kARDEX set total=@result,fechaModificacion=SYSDATETIME() where idMaterial=@material
		end--end if tipo

		set @count=@count+1
	END--end while
	--actualizacion de estado
	update TB_NOTAS set responde=@idUser,fechaRespuesta=SYSDATETIME(),idEstado=@idEstado where idNota=@idNota
	drop table #items
end
GO
/****** Object:  StoredProcedure [dbo].[SP_RESPUESTA_ORDEN_PEDIDO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_RESPUESTA_ORDEN_PEDIDO] 
(
@idOrdenPedido bigint,
@estado int,
@user int,
@detalle varchar(100)
)
as
declare 
@cicloTotal int=0,
@totalMaterial int=0,
@i int =0,
@encuentraMaterial int,
@idMaterialCiclo int,
@totalMatKardex int,
@estadoAct int
--validacion estado
select @estadoAct=idEstadoOrdenPedido from TB_ORDEN_PEDIDO where idOrdenPedido=@idOrdenPedido
if @estadoAct=1 or @estadoAct=2
begin
	--actualiza kardex totalPedidos++
	create table #items (
	idt int identity(1,1),
	idMaterial int,
	cantidad int
	)
	insert into #items (idMaterial,cantidad)
		select idMaterial,cantidad from TB_DETALLE_ORDEN_PEDIDO where idOrdenPedido=@idOrdenPedido;
	select @cicloTotal=count(*) from #items
	--inicia ciclo
	while @i <= @cicloTotal
	begin
		--datos
		select @idMaterialCiclo=idMaterial,@totalMaterial=cantidad from #items where idt=@i
		--update kardex
			select @totalMatKardex=totalPedidos from TB_kARDEX where idMaterial=@idMaterialCiclo
			set @totalMaterial=@totalMaterial+@totalMatKardex;
			update TB_kARDEX set totalPedidos=@totalMaterial, fechaModificacion=SYSDATETIME() where idMaterial=@idMaterialCiclo
		--incrementa ciclo
		set @i=@i+1
	end

	update TB_ORDEN_PEDIDO set idEstadoOrdenPedido=@estado,idResponde=@user,
	fechaCambioEstado=SYSDATETIME(),detalleRespuesta=@detalle
	where idOrdenPedido=@idOrdenPedido
end
GO
/****** Object:  StoredProcedure [dbo].[SP_VALIDA_PERMISOS]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--=============================================================================================
create procedure [dbo].[SP_VALIDA_PERMISOS]
(
@token varchar(80),
@ruta varchar(100)
)
as
declare
@role int
--buscar rol usuario
select top 1 @role=us.idRol from TB_USUARIOS us WHERE us.token=@token
--busca modulo
select  COUNT(*) as 'persmiso'
from TB_MODULO_ROL mdRl 
inner join TB_MODULO md on md.idModulo=mdRl.idModulo
where mdRl.idRol=@role and md.Ruta=@ruta 
GO
/****** Object:  StoredProcedure [dbo].[SP_VALIDAR_USUARIO]    Script Date: 23/08/2018 01:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--=============================================================================================
create procedure [dbo].[SP_VALIDAR_USUARIO] 
(
@token varchar(50) 
)
as
select us.idUsuario,us.nombres,us.Mail,us.token,rl.descripcion,us.idRol 
from TB_USUARIOS us inner join TB_ROLES rl on rl.idRol=us.idrol 
WHERE us.token=@token AND us.idrol != 1 AND us.Estado != 0
GO
