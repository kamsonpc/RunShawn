CREATE SCHEMA [Pages]
GO

CREATE TABLE [Pages].[Pages] (
    [Id] [bigint]  IDENTITY NOT NULL,
    [Title] [nvarchar](256) NOT NULL,
	[Active] [tinyint] NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[UrlSlug] [nvarchar](256) NOT NULL,
	[CreatedBy] [nvarchar](128) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](128)  NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedBy] [nvarchar](128)  NULL,
	[DeletedDate] [datetime] NULL,

    CONSTRAINT [PK_Pages.Pages] PRIMARY KEY ([Id])
)
GO
