CREATE TABLE [dbo].[Company]
(
	[Id]		INT				NOT NULL PRIMARY KEY, 
    [Name]		NVARCHAR(MAX)	NULL, 
    [Ruc]		NVARCHAR(50)	NULL, 
    [Email]		NVARCHAR(50)	NULL, 
    [Contact]	NVARCHAR(50)	NULL, 
    [Phone]		NVARCHAR(50)	NULL, 
    [Address]	NVARCHAR(50)	NULL, 
    [Logo]		NVARCHAR(50)	NULL
)
