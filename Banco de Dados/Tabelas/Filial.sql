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
ALTER TABLE dbo.Endereco SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Filial
	(
	id_filial uniqueidentifier NOT NULL,
	nm_filial nvarchar(510) NOT NULL,
	nr_cnpj bigint NOT NULL,
	id_endereco uniqueidentifier NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Filial ADD CONSTRAINT
	PK_Filial PRIMARY KEY CLUSTERED 
	(
	id_filial
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Filial ADD CONSTRAINT
	FK_Filial_Endereco FOREIGN KEY
	(
	id_endereco
	) REFERENCES dbo.Endereco
	(
	id_endereco
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Filial SET (LOCK_ESCALATION = TABLE)
GO
COMMIT