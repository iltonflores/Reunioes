USE [Reunioes]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Filial_Endereco]') AND parent_object_id = OBJECT_ID(N'[dbo].[Filial]'))
ALTER TABLE [dbo].[Filial] DROP CONSTRAINT [FK_Filial_Endereco]
GO

USE [Reunioes]
GO

/****** Object:  Table [dbo].[Filial]    Script Date: 06/25/2017 15:37:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Filial]') AND type in (N'U'))
DROP TABLE [dbo].[Filial]
GO

USE [Reunioes]
GO

/****** Object:  Table [dbo].[Filial]    Script Date: 06/25/2017 15:37:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Filial](
	[id_filial] [uniqueidentifier] ROWGUIDCOL NOT NULL,
	[nm_filial] [nvarchar](510) NOT NULL,
	[nr_cnpj] [bigint] NOT NULL,
	[id_endereco] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Filial] PRIMARY KEY CLUSTERED 
(
	[id_filial] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Filial]  WITH CHECK ADD  CONSTRAINT [FK_Filial_Endereco] FOREIGN KEY([id_endereco])
REFERENCES [dbo].[Endereco] ([id_endereco])
GO

ALTER TABLE [dbo].[Filial] CHECK CONSTRAINT [FK_Filial_Endereco]
GO

ALTER TABLE [dbo].[Filial] ADD  CONSTRAINT [DF_Filial_id_filial]  DEFAULT (newid()) FOR [id_filial]
GO


