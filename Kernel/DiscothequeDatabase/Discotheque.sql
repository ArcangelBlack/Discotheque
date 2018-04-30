CREATE TABLE [dbo].[Discotheque]
(
	[Id]			INT				NOT NULL PRIMARY KEY, 
	[IdCompany]		INT				NOT NULL,
    [Name]			NVARCHAR(50)	NOT NULL, 
    [Address]		NVARCHAR(50)	NOT NULL, 
    [Cp]			NCHAR(10)		NOT NULL, 
    [Phone]		NVARCHAR(50)	NOT NULL, 
    [Email]			NVARCHAR(50)	NOT NULL, 
    [WebSite]			NVARCHAR(50)	NULL, 
    [Latitud]		DECIMAL(18, 3)	NOT NULL, 
    [Longitud]		DECIMAL(18, 3)	NOT NULL, 
    [Estatus]		INT				NOT NULL, 
    [Facebook]		NVARCHAR(50)	NULL, 
    CONSTRAINT [FK_Discotheque_Company] FOREIGN KEY ([IdCompany]) REFERENCES [Company]([Id])
)
