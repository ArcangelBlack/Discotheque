CREATE TABLE [dbo].[Employee]
(
	[Id]			INT				NOT NULL PRIMARY KEY, 
	[IdRol]			INT				NOT NULL, 
    [Name]			NVARCHAR(50)	NOT NULL, 
    [LastName]		NVARCHAR(50)	NOT NULL, 
    [Age]			INT				NOT NULL, 
	[BirthDate]		DATETIME		NOT NULL,
	[Address]		NVARCHAR(50)	NULL, 
    [Phone]			NCHAR(10)		NULL, 
    [Email]			NVARCHAR(50)	NULL, 
    [Gender]		INT	NULL,
    CONSTRAINT [FK_Employee_Role] FOREIGN KEY (IdRol) REFERENCES [Roles]([Id]), 
)
