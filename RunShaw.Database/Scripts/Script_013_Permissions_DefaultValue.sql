ALTER TABLE 
	[Permissions].[Permissions] 
ADD CONSTRAINT 
	Permissions_DF_ID
DEFAULT 
	LOWER(NEWID())
FOR 
	[Id]
GO