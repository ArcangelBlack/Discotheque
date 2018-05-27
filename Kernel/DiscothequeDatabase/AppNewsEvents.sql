CREATE TABLE [dbo].[AppNewsEvents]
(
	[Id]				INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description]		NCHAR(10) NOT NULL, 
    [StartDate]			DATETIME NOT NULL, 
    [EndDate]			DATETIME NOT NULL, 
    [Photo]				NVARCHAR(MAX) NOT NULL, 
    [Precio]			MONEY NOT NULL, 
    [Observation]		NVARCHAR(MAX) NOT NULL,
	[CreatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedDate]		DATETIME2		NULL, 
    [CreatedDate]		DATETIME2		NULL
)
