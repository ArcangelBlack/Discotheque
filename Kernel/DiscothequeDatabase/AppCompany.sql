CREATE TABLE [dbo].[AppCompany]
(
	[Id]		INT				NOT NULL PRIMARY KEY IDENTITY, 
    [Name]		NVARCHAR(MAX)	NULL, 
    [Ruc]		NVARCHAR(50)	NULL, 
    [Email]		NVARCHAR(50)	NULL, 
    [Contact]	NVARCHAR(50)	NULL, 
    [Phone]		NVARCHAR(50)	NULL, 
    [Address]	NVARCHAR(50)	NULL, 
    [Logo]		NVARCHAR(50)	NULL,
	[CreatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedDate]		DATETIME2		NULL, 
    [CreatedDate]		DATETIME2		NULL
)
