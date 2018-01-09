CREATE TABLE [dbo].[Usuario] (
    [Id]            INT  IDENTITY (1, 1) NOT NULL,
    [EmpresaId]     INT  NOT NULL,
    [Nombre]        TEXT NOT NULL,
    [NombreUsuario] TEXT NOT NULL,
    [Clave]         TEXT NOT NULL,
    [Cotizar]       BIT  NOT NULL,
    [Borrar]        BIT  NOT NULL,
    [Crear]         BIT  NOT NULL,
    [Activo]        BIT  DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([EmpresaId]) REFERENCES [dbo].[Empresa] ([Id])
);

