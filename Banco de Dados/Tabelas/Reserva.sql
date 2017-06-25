USE [Reunioes]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reserva_Filial]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reserva]'))
ALTER TABLE [dbo].[Reserva] DROP CONSTRAINT [FK_Reserva_Filial]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reserva_Responsavel]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reserva]'))
ALTER TABLE [dbo].[Reserva] DROP CONSTRAINT [FK_Reserva_Responsavel]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Reserva_Sala]') AND parent_object_id = OBJECT_ID(N'[dbo].[Reserva]'))
ALTER TABLE [dbo].[Reserva] DROP CONSTRAINT [FK_Reserva_Sala]
GO

USE [Reunioes]
GO

/****** Object:  Table [dbo].[Reserva]    Script Date: 06/25/2017 15:36:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reserva]') AND type in (N'U'))
DROP TABLE [dbo].[Reserva]
GO

USE [Reunioes]
GO

/****** Object:  Table [dbo].[Reserva]    Script Date: 06/25/2017 15:36:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Reserva](
	[id_reserva] [uniqueidentifier] ROWGUIDCOL NOT NULL,
	[id_filial] [uniqueidentifier] NOT NULL,
	[id_sala] [uniqueidentifier] NOT NULL,
	[dt_inicio] [datetime] NOT NULL,
	[dt_fim] [datetime] NOT NULL,
	[id_responsavel] [uniqueidentifier] NOT NULL,
	[dv_cafe] [bit] NOT NULL,
	[qt_cafe] [smallint] NULL,
	[nm_descricao] [nvarchar](510) NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[id_reserva] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Filial] FOREIGN KEY([id_filial])
REFERENCES [dbo].[Filial] ([id_filial])
GO

ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Filial]
GO

ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Responsavel] FOREIGN KEY([id_responsavel])
REFERENCES [dbo].[Responsavel] ([id_responsavel])
GO

ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Responsavel]
GO

ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Sala] FOREIGN KEY([id_sala])
REFERENCES [dbo].[Sala] ([id_sala])
GO

ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Sala]
GO

ALTER TABLE [dbo].[Reserva] ADD  CONSTRAINT [DF_Reserva_id_reserva]  DEFAULT (newid()) FOR [id_reserva]
GO


