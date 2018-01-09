CREATE TABLE [dbo].[Empresa] (
    [Id]     INT  IDENTITY (1, 1) NOT NULL,
    [Nombre] TEXT NOT NULL,
    [Activo] BIT  DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

