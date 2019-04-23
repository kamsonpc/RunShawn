CREATE PROCEDURE [Permissions].[GetByRole] @RoleId nvarchar(128)
AS
SELECT 
	[Permissions].[Permissions].[Value]
FROM 
	[Permissions].[RolesPermissions]
INNER JOIN 
	[Permissions].[Permissions]
ON 
	[Permissions].[RolesPermissions].[PermissionId] = [Permissions].[Permissions].[Id]
WHERE 
	[Permissions].[RolesPermissions].[RoleId] = @RoleId
GO