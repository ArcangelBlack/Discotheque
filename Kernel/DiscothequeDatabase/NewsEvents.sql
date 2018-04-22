CREATE TABLE [dbo].[NewsEvents]
(
	[Id]				INT NOT NULL PRIMARY KEY, 
    [Description]		NCHAR(10) NOT NULL, 
    [StartDate]			DATETIME NOT NULL, 
    [EndDate]			DATETIME NOT NULL, 
    [Photo]				NVARCHAR(MAX) NOT NULL, 
    [Precio]			MONEY NOT NULL, 
    [Observation]		NVARCHAR(MAX) NOT NULL
)
