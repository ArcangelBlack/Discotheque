CREATE TABLE [dbo].[AppCalendar]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CreatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedDate]		DATETIME2		NULL, 
    [CreatedDate]		DATETIME2		NULL
)
