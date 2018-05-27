CREATE TABLE [dbo].[AppMusic]
(
	[Id]				INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description]		NCHAR(10) NULL, 
    [IdUser]			INT NULL,
	[CreatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedDate]		DATETIME2		NULL, 
    [CreatedDate]		DATETIME2		NULL, 
    CONSTRAINT [FK_Music_User] FOREIGN KEY ([IdUser]) REFERENCES [AppUser]([Id])
)
