/* Para impedir possíveis problemas de perda de dados, analise este script detalhadamente antes de executá-lo fora do contexto do designer de banco de dados.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Endereco
	(
	id_endereco uniqueidentifier NOT NULL,
	nm_rua nvarchar(510) NOT NULL,
	nr_rua int NOT NULL,
	nm_bairro nvarchar(510) NOT NULL,
	nm_estado nvarchar(510) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Endereco ADD CONSTRAINT
	PK_Endereco PRIMARY KEY CLUSTERED 
	(
	id_endereco
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Endereco SET (LOCK_ESCALATION = TABLE)
GO
COMMIT