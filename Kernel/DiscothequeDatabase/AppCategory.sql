CREATE TABLE [dbo].[AppDiscothequeCategory]
(
	[Id]				INT				NOT NULL PRIMARY KEY IDENTITY, 
    [Description]		NVARCHAR(50)	NULL,
	[CreatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedDate]		DATETIME2		NULL, 
    [CreatedDate]		DATETIME2		NULL
)
