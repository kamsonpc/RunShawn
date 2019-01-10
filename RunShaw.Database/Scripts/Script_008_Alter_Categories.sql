ALTER TABLE [News].[Categories]
	ADD Color VARCHAR(255)  NULL
GO

UPDATE [News].[Categories] 
	SET Color = '#000000'
GO

ALTER TABLE [News].[Categories]
	ALTER COLUMN Color VARCHAR(255) NOT NULL
GO