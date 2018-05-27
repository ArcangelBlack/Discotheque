CREATE TABLE [dbo].[AppLogin]
(
	[Id]				INT				NOT NULL PRIMARY KEY IDENTITY, 
    [IdUser]			INT				NULL, 
    [UserName]			NVARCHAR(50)	NULL, 
    [Password]			NVARCHAR(50)	NULL,
	[CreatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedDate]		DATETIME2		NULL, 
    [CreatedDate]		DATETIME2		NULL
)
