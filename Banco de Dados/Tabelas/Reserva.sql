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
ALTER TABLE dbo.Sala SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Responsavel SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Filial SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Reserva
	(
	id_reserva uniqueidentifier NOT NULL,
	id_filial uniqueidentifier NOT NULL,
	id_sala uniqueidentifier NOT NULL,
	dt_inicio datetime NOT NULL,
	dt_fim datetime NOT NULL,
	id_responsavel uniqueidentifier NOT NULL,
	dv_cafe bit NOT NULL,
	qt_cafe smallint NULL,
	nm_descricao nvarchar(510) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Reserva ADD CONSTRAINT
	PK_Reserva PRIMARY KEY CLUSTERED 
	(
	id_reserva
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Reserva ADD CONSTRAINT
	FK_Reserva_Filial FOREIGN KEY
	(
	id_filial
	) REFERENCES dbo.Filial
	(
	id_filial
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Reserva ADD CONSTRAINT
	FK_Reserva_Responsavel FOREIGN KEY
	(
	id_responsavel
	) REFERENCES dbo.Responsavel
	(
	id_responsavel
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Reserva ADD CONSTRAINT
	FK_Reserva_Sala FOREIGN KEY
	(
	id_sala
	) REFERENCES dbo.Sala
	(
	id_sala
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Reserva SET (LOCK_ESCALATION = TABLE)
GO
COMMIT