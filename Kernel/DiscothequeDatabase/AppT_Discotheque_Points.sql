CREATE TABLE [dbo].[AppT_Discotheque_Points]
(
	[Id]				INT				NOT NULL PRIMARY KEY IDENTITY, 
    [IdUser]			INT				NULL, 
    [IdDiscotheque]		INT				NULL, 
    [Points]			INT				NULL, 
    [Observation]		NVARCHAR(MAX)	NULL,
	[CreatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedBy]			NVARCHAR(50)	NULL, 
    [UpdatedDate]		DATETIME2		NULL, 
    [CreatedDate]		DATETIME2		NULL
)
