﻿CREATE TABLE [dbo].[tbAlumnos]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[Nombre] NVARCHAR (50) NOT NULL,
	[Apellidos] NVARCHAR (100) NULL,
	[Edad] INT NULL,
	[FechaNac] DATETIME NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC)
)
