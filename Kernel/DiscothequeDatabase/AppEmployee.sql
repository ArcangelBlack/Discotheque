CREATE TABLE [dbo].[AppEmployee]
(
	[Id]				INT				NOT NULL PRIMARY KEY IDENTITY, 
	[IdRol]				INT				NOT NULL, 
    [Name]				NVARCHAR(50)	NOT NULL, 
    [LastName]			NVARCHAR(50)	NOT NULL, 
    [Age]				INT				NOT NULL, 
	[BirthDate]			DATETIME		NOT NULL,
	[Address]			NVARCHAR(50)	NULL, 
    [Phone]				NCHAR(10)		NULL, 
    [Email]				NVARCHAR(50)	NOT NULL, 
    [Gender]			INT				NOT NULL ,
	[Status]			INT				NOT NULL ,
	[CreatedBy]			NVARCHAR(50)	NOT NULL, 
    [UpdatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedDate]		DATETIME2		NULL, 
    [CreatedDate]		DATETIME2		NOT NULL
    CONSTRAINT [FK_Employee_Role] FOREIGN KEY (IdRol) REFERENCES [AppRoles]([Id]), 
)
