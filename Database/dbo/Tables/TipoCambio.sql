CREATE TABLE [dbo].[TipoCambio] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [EmpresaId] INT             NOT NULL,
    [Fecha]     DATETIME2 (7)   NOT NULL,
    [Monto]     DECIMAL (15, 2) NOT NULL,
    [Activo]    BIT             DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([EmpresaId]) REFERENCES [dbo].[Empresa] ([Id])
);

