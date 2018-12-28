CREATE SCHEMA [News]
GO


CREATE TABLE [News].[Categories] (
    [Id] [bigint] IDENTITY  NOT NULL,
	[ParentId] [bigint] NULL,
    [Title] [nvarchar](256) NOT NULL,
	[CreatedBy] [nvarchar](128) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](128)  NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedBy] [nvarchar](128)  NULL,
	[DeletedDate] [datetime] NULL,

    CONSTRAINT [PK_News.Categories] PRIMARY KEY ([Id])
)
GO

CREATE TABLE [News].[News] (
    [Id] [bigint]  IDENTITY NOT NULL,
    [Title] [nvarchar](256) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[CategoryId] [bigint] NOT NULL,
	[PublishDate] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](128) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](128)  NULL,
	[ModifiedDate] [datetime] NULL,
	[DeletedBy] [nvarchar](128)  NULL,
	[DeletedDate] [datetime] NULL,

    CONSTRAINT [PK_News.News] PRIMARY KEY ([Id])
)
GO

ALTER TABLE 
		[News].[News]
	ADD CONSTRAINT 
		[FK_News_Categories] 
	FOREIGN KEY 
		([CategoryId]) 
	REFERENCES 
		[News].[Categories] ([Id])
GO