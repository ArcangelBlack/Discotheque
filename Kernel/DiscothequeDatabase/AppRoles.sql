CREATE TABLE [dbo].[AppRoles]
(
	[Id]				INT				NOT NULL PRIMARY KEY IDENTITY, 
    [Description]		NVARCHAR(50)	NOT NULL,
	[CreatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedDate]		DATETIME2		NULL, 
    [CreatedDate]		DATETIME2		NULL
)
