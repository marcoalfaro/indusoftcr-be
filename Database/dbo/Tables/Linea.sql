CREATE TABLE [dbo].[Linea] (
    [Id]        INT  IDENTITY (1, 1) NOT NULL,
    [EmpresaId] INT  NOT NULL,
    [Nombre]    TEXT NOT NULL,
    [Activo]    BIT  DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([EmpresaId]) REFERENCES [dbo].[Empresa] ([Id])
);

