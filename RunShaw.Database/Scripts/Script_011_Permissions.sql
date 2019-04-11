CREATE SCHEMA [Permissions]
GO

CREATE TABLE [Permissions].[Permissions] (
    [Id] [nvarchar](128) NOT NULL,
    [Title] [nvarchar](256) NOT NULL,
    [Value] [bigint] NOT NULL,
	CONSTRAINT [PK_Permissions_Permissions] PRIMARY KEY ([Id])
)
GO

CREATE TABLE [Permissions].[RolesPermissions] (
    [Id] [bigint]  IDENTITY NOT NULL,
    [RoleId] [nvarchar](128) NOT NULL,
    [PermissionId] [nvarchar](128) NOT NULL,

	CONSTRAINT [PK_Permissions_RolesPermissions] PRIMARY KEY ([Id])
)
GO

ALTER TABLE [Permissions].[RolesPermissions] 
ADD CONSTRAINT [FK_Permissions_RolesPermissions_dbo.AspNetRoles_RoleId] 
FOREIGN KEY ([RoleId]) 
REFERENCES [dbo].[AspNetRoles] ([Id])
GO

ALTER TABLE [Permissions].[RolesPermissions] 
ADD CONSTRAINT [FK_Permissions_RolesPermissions_Permissions_Permissions_PermissionId] 
FOREIGN KEY ([PermissionId]) 
REFERENCES [Permissions].[Permissions] ([Id]) 
GO
