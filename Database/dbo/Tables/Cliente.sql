CREATE TABLE [dbo].[Cliente] (
    [Id]                INT  IDENTITY (1, 1) NOT NULL,
    [EmpresaId]         INT  NOT NULL,
    [Nombre]            TEXT NOT NULL,
    [Cedula]            TEXT NULL,
    [Telefono]          TEXT NULL,
    [ContactoNombre]    TEXT NULL,
    [ContactoTelefono]  TEXT NULL,
    [ContactoExtension] TEXT NULL,
    [ContactoCorreo]    TEXT NULL,
    [Activo]            BIT  DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([EmpresaId]) REFERENCES [dbo].[Empresa] ([Id])
);

