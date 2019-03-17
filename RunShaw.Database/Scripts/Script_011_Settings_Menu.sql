CREATE SCHEMA [Settings]
GO

CREATE TABLE [Settings].[Menu] (
    [Id] [bigint]  IDENTITY NOT NULL,
	[ParentId] [bigint]  NULL,
    [Text] [nvarchar](256) NOT NULL,
    [Icon] [nvarchar](80) NOT NULL,
	[PageId] [BIGINT] NOT NULL

    CONSTRAINT [PK_Settings.Menu] PRIMARY KEY ([Id])
)
GO

ALTER TABLE 
		[Settings].[Menu]
	ADD CONSTRAINT 
		[FK_Menu_Pages] 
	FOREIGN KEY 
		([PageId]) 
	REFERENCES 
		[Pages].[Pages] ([Id])
GO


CREATE VIEW Settings.MenuPagesView
AS
SELECT  
	Settings.Menu.Id,
	Settings.Menu.[Order],
	Settings.Menu.ParentId,
	Settings.Menu.[Text],
	Settings.Menu.Icon,
	Pages.Pages.UrlSlug
FROM	
	Settings.Menu
CROSS JOIN
    Pages.Pages
GO
