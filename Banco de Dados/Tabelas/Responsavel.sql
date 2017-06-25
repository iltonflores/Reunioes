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
CREATE TABLE dbo.Responsavel
	(
	id_responsavel uniqueidentifier NOT NULL,
	nm_responsavel nvarchar(510) NOT NULL,
	nr_cpf bigint NOT NULL,
	nr_telefone bigint NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Responsavel ADD CONSTRAINT
	PK_Responsavel PRIMARY KEY CLUSTERED 
	(
	id_responsavel
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Responsavel SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
