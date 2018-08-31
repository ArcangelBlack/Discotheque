CREATE TABLE [dbo].[AppUser]
(
	[Id]				INT				NOT NULL PRIMARY KEY IDENTITY, 
	[IdRol]				INT				NOT NULL, 
    [Name]				NVARCHAR(50)	NOT NULL, 
    [LastName]			NVARCHAR(50)	NOT NULL, 
    [Age]				INT				NOT NULL, 
	[BirthDate]			DATETIME		NOT NULL,
	[Address]			NVARCHAR(50)	NULL, 
    [Phone]				NCHAR(10)		NULL, 
    [Email]				NVARCHAR(50)	NULL, 
    [Gender]			INT	NOT NULL,   
	[Facebook]			NVARCHAR(50)	NULL, 
    [Gmail]				NVARCHAR(50)	NULL, 
    [Instagram]			NVARCHAR(50)	NULL, 
	[Status]			INT				NOT NULL ,
	[CreatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedDate]		DATETIME2		NULL, 
    [CreatedDate]		DATETIME2		NULL
    CONSTRAINT [FK_User_Role] FOREIGN KEY (IdRol) REFERENCES [AppRoles]([Id]), 
)