CREATE TABLE [dbo].[Vendedor] (
    [Id]        INT  IDENTITY (1, 1) NOT NULL,
    [EmpresaId] INT  NOT NULL,
    [Nombre]    TEXT NOT NULL,
    [Email]     TEXT NULL,
    [Telefono]  TEXT NULL,
    [Beeper]    TEXT NULL,
    [Activo]    BIT  DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([EmpresaId]) REFERENCES [dbo].[Empresa] ([Id])
);

