USE [Reunioes]
GO

/****** Object:  Table [dbo].[Endereco]    Script Date: 06/25/2017 15:37:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Endereco]') AND type in (N'U'))
DROP TABLE [dbo].[Endereco]
GO

USE [Reunioes]
GO

/****** Object:  Table [dbo].[Endereco]    Script Date: 06/25/2017 15:37:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Endereco](
	[id_endereco] [uniqueidentifier] ROWGUIDCOL NOT NULL,
	[nm_rua] [nvarchar](510) NOT NULL,
	[nr_rua] [int] NOT NULL,
	[nm_bairro] [nvarchar](510) NOT NULL,
	[nm_estado] [nvarchar](510) NOT NULL,
	[nm_cidade] [nvarchar](510) NOT NULL,
	[nr_cep] [bigint] NOT NULL,
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
	[id_endereco] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Endereco] ADD  CONSTRAINT [DF_Endereco_id_endereco]  DEFAULT (newid()) FOR [id_endereco]
GO


