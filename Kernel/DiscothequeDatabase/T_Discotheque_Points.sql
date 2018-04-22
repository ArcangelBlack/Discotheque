CREATE TABLE [dbo].[T_Discotheque_Points]
(
	[Id]				INT				NOT NULL PRIMARY KEY, 
    [IdUser]			INT				NULL, 
    [IdDiscotheque]		INT				NULL, 
    [Points]			INT				NULL, 
    [Observation]		NVARCHAR(MAX)	NULL
)
