CREATE TABLE [dbo].[Material] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [EmpresaId]        INT             NOT NULL,
    [Nombre]           TEXT            NOT NULL,
    [Altura]           DECIMAL (10, 2) NULL,
    [Base]             DECIMAL (10, 2) NULL,
    [CodigoInventario] TEXT            NULL,
    [CostoInventario]  DECIMAL (15, 2) NULL,
    [Activo]           BIT             DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([EmpresaId]) REFERENCES [dbo].[Empresa] ([Id])
);

