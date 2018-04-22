CREATE TABLE [dbo].[Login]
(
	[Id]			INT				NOT NULL PRIMARY KEY, 
    [IdUser]		INT				NULL, 
    [UserName]		NVARCHAR(50)	NULL, 
    [Password]		NVARCHAR(50)	NULL
)
