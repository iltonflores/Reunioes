USE [Reunioes]
GO

/****** Object:  Table [dbo].[Sala]    Script Date: 06/25/2017 15:36:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sala]') AND type in (N'U'))
DROP TABLE [dbo].[Sala]
GO

USE [Reunioes]
GO

/****** Object:  Table [dbo].[Sala]    Script Date: 06/25/2017 15:36:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Sala](
	[id_sala] [uniqueidentifier] ROWGUIDCOL NOT NULL,
	[nm_sala] [varchar](510) NOT NULL,
 CONSTRAINT [PK_Sala] PRIMARY KEY CLUSTERED 
(
	[id_sala] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Sala] ADD  CONSTRAINT [DF_Sala_id_sala]  DEFAULT (newid()) FOR [id_sala]
GO


