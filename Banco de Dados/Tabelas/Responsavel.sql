USE [Reunioes]
GO

/****** Object:  Table [dbo].[Responsavel]    Script Date: 06/25/2017 15:36:52 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Responsavel]') AND type in (N'U'))
DROP TABLE [dbo].[Responsavel]
GO

USE [Reunioes]
GO

/****** Object:  Table [dbo].[Responsavel]    Script Date: 06/25/2017 15:36:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Responsavel](
	[id_responsavel] [uniqueidentifier] ROWGUIDCOL NOT NULL,
	[nm_responsavel] [nvarchar](510) NOT NULL,
	[nr_cpf] [bigint] NOT NULL,
	[nr_telefone] [bigint] NOT NULL,
 CONSTRAINT [PK_Responsavel] PRIMARY KEY CLUSTERED 
(
	[id_responsavel] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Responsavel] ADD  CONSTRAINT [DF_Responsavel_id_responsavel]  DEFAULT (newid()) FOR [id_responsavel]
GO


