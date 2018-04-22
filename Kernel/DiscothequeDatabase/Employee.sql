CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [Designation] NVARCHAR(50) NULL, 
    [Skills] NVARCHAR(50) NULL, 
    [IdProject] INT NULL, 
    CONSTRAINT [FK_Employee_Project] FOREIGN KEY ([IdProject]) REFERENCES [Project]([Id])
)
