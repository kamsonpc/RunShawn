CREATE SCHEMA [Activity]
GO

CREATE TABLE [Activity].[UsersActivity] (
    [Id] [bigint]  IDENTITY NOT NULL,
	[LocationId] [bigint] NOT NULL,
	[UserId] nvarchar(128) NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [nvarchar](128)  NULL,
    CONSTRAINT [PK_Activity.UsersActivity] PRIMARY KEY ([Id])
)
GO


CREATE TABLE [Activity].[Locations] (
    [Id] [bigint]  IDENTITY NOT NULL,
    [Location] [nvarchar](256) NOT NULL,
    [Boost] [bigint] NOT NULL,
    CONSTRAINT [PK_Activity.Location] PRIMARY KEY ([Id])
)
GO

ALTER TABLE 
		[Activity].[UsersActivity]
	ADD CONSTRAINT 
		[FK_Users_Activity] 
	FOREIGN KEY 
		([UserId]) 
	REFERENCES 
		[dbo].[AspNetUsers] ([Id])
GO


ALTER TABLE 
		[Activity].[UsersActivity]
	ADD CONSTRAINT 
		[FK_Users_Location] 
	FOREIGN KEY 
		([LocationId]) 
	REFERENCES 
		[Activity].[Locations] ([Id])
GO
