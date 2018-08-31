CREATE TABLE [dbo].[AppCalendar]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[IdDiscotheque]		INT				NOT NULL,
	[Title]				NVARCHAR(50)	NOT NULL,
	[DateStart]			DATETIME2		NOT NULL, 
	[DateEnd]			DATETIME2		NOT NULL, 
	[Color]				NVARCHAR(50)	NOT NULL,
	[IsSameDay]			FLOAT			NOT NULL,
	[IsSameMonth]		FLOAT			NOT NULL,
    [CreatedBy]			NVARCHAR(50)	NOT NULL, 
    [UpdatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedDate]		DATETIME2		NULL, 
    [CreatedDate]		DATETIME2		NOT NULL,
	CONSTRAINT [FK_Calendar_Discotheque] FOREIGN KEY ([IdDiscotheque]) REFERENCES [AppDiscotheque]([Id])
)
