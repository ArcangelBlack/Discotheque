CREATE TABLE [dbo].[Project]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProjectName] NVARCHAR(50) NOT NULL, 
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NOT NULL
)
