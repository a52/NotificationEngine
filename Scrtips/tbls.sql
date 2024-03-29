USE [NotificationEngine]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CamposEntidadTipoNotificacion](
	[IdCampoEntidadTipoNotificacion] [int] IDENTITY(1,1) NOT NULL,
	[IdEntidadTipoNotificacion] [int] NOT NULL,
	[PalabraClave] [varchar](50) NULL,
	[CampoReferencia] [varchar](50) NULL,
 CONSTRAINT [PK_CamposEntidadTipoNotificacion] PRIMARY KEY CLUSTERED 
(
	[IdCampoEntidadTipoNotificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntidadesTipoNotificacion](
	[IdEntidadTipoNotificacion] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoNotificacion] [int] NOT NULL,
	[NombreEntidad] [varchar](100) NOT NULL,
	[ConsultaDB] [varchar](max) NULL,
	[UsoCreacionMensaje] [bit] NULL,
	[UsoEnvioMensaje] [bit] NULL,
 CONSTRAINT [PK_EntidadesTipoNotificacion] PRIMARY KEY CLUSTERED 
(
	[IdEntidadTipoNotificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MensajesNotificacion](
	[IdMensajeNotificacion] [int] IDENTITY(1,1) NOT NULL,
	[IdTipoNotificacion] [int] NOT NULL,
	[IdReferencia] [int] NOT NULL,
	[Asunto] [varchar](500) NOT NULL,
	[Mensaje] [text] NOT NULL,
	[Adjunto] [varchar](1000) NULL,
	[Activo] [bit] NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
 CONSTRAINT [PK_MensajeNotificacion] PRIMARY KEY CLUSTERED 
(
	[IdMensajeNotificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notificaciones](
	[IdNotificacion] [int] IDENTITY(1,1) NOT NULL,
	[IdMensajeNotificacion] [int] NOT NULL,
	[IdReferencia] [int] NOT NULL,
	[Email] [varchar](250) NOT NULL,
	[Enviado] [bit] NULL,
	[FechaNotificacion] [datetime] NULL,
 CONSTRAINT [PK_Notificaciones] PRIMARY KEY CLUSTERED 
(
	[IdNotificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposNotificacion](
	[IdTipoNotificacion] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](500) NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
	[QConsulta] [varchar](max) NULL,
	[QEnvio] [varchar](max) NULL,
	[QActualizar] [varchar](max) NULL,
	[Asunto] [varchar](1000) NOT NULL,
	[Plantilla] [text] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_TipoNotificacion] PRIMARY KEY CLUSTERED 
(
	[IdTipoNotificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[MensajesNotificacion] ADD  CONSTRAINT [DF_MensajesNotificacion_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[MensajesNotificacion] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Notificaciones] ADD  DEFAULT (getdate()) FOR [FechaNotificacion]
GO
ALTER TABLE [dbo].[TiposNotificacion] ADD  CONSTRAINT [DF_TiposNotificacion_Activo]  DEFAULT ((1)) FOR [Activo]
GO
ALTER TABLE [dbo].[CamposEntidadTipoNotificacion]  WITH CHECK ADD  CONSTRAINT [FK_CamposEntidadTipoNotificacion_EntidadesTipoNotificacion] FOREIGN KEY([IdEntidadTipoNotificacion])
REFERENCES [dbo].[EntidadesTipoNotificacion] ([IdEntidadTipoNotificacion])
GO
ALTER TABLE [dbo].[CamposEntidadTipoNotificacion] CHECK CONSTRAINT [FK_CamposEntidadTipoNotificacion_EntidadesTipoNotificacion]
GO
ALTER TABLE [dbo].[EntidadesTipoNotificacion]  WITH CHECK ADD  CONSTRAINT [FK_EntidadesTipoNotificacion_TiposNotificacion] FOREIGN KEY([IdTipoNotificacion])
REFERENCES [dbo].[TiposNotificacion] ([IdTipoNotificacion])
GO
ALTER TABLE [dbo].[EntidadesTipoNotificacion] CHECK CONSTRAINT [FK_EntidadesTipoNotificacion_TiposNotificacion]
GO
ALTER TABLE [dbo].[MensajesNotificacion]  WITH CHECK ADD  CONSTRAINT [FK_MensajeNotificacionTipoNotificacion] FOREIGN KEY([IdTipoNotificacion])
REFERENCES [dbo].[TiposNotificacion] ([IdTipoNotificacion])
GO
ALTER TABLE [dbo].[MensajesNotificacion] CHECK CONSTRAINT [FK_MensajeNotificacionTipoNotificacion]
GO
ALTER TABLE [dbo].[Notificaciones]  WITH CHECK ADD  CONSTRAINT [FK_Notificaciones_MensajesNotificacion] FOREIGN KEY([IdMensajeNotificacion])
REFERENCES [dbo].[MensajesNotificacion] ([IdMensajeNotificacion])
GO
ALTER TABLE [dbo].[Notificaciones] CHECK CONSTRAINT [FK_Notificaciones_MensajesNotificacion]
GO
